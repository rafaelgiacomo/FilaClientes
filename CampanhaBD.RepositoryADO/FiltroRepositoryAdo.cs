using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class FiltroRepositoryAdo
    {

        public SqlDataReader Reader { get; set; }

        private Context _context;

        #region Método públicos
        public FiltroRepositoryAdo(Context context)
        {
            _context = context;
        }

        public int EstimarQtdFiltroBaseOriginal(FiltroModel filtro)
        {
            try
            {
                int qtd = 0;
                string sql = GerarSqlImportacaoQuantidade(filtro);

                var reader = _context.ExecuteSqlCommandWithReturn(sql);

                if (reader.Read())
                {
                    var ultimoId = reader[0].ToString();

                    if (!string.IsNullOrEmpty(ultimoId))
                        qtd = int.Parse(ultimoId);
                }

                reader.Close();

                return qtd;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void FiltroImportacaoBaseOriginal(FiltroModel filtro)
        {
            try
            {
                string sql = GerarSqlImportacaoClientes(filtro);

                Reader = _context.ExecuteSqlCommandWithReturn(sql);                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool LerDadosClienteBaseOriginal(ClienteModel cl)
        {
            try
            {
                if (Reader.Read())
                {
                    EmprestimoModel emp = new EmprestimoModel();
                    BeneficioModel ben = new BeneficioModel();

                    #region Dados Cliente
                    cl.PreencheCpfEId(Reader[BaseOriginalDadoModel.COLUMN_CPF].ToString());
                    cl.PreencheDataNascimento(Reader[BaseOriginalDadoModel.COLUMN_DATA_NASCIMENTO].ToString());
                    cl.PreencheCep(Reader[BaseOriginalDadoModel.COLUMN_CEP].ToString());

                    cl.Uf = Reader[BaseOriginalDadoModel.COLUMN_UF].ToString();
                    cl.Cidade = Reader[BaseOriginalDadoModel.COLUMN_MUNICIPIO].ToString();
                    cl.Logradouro = Reader[BaseOriginalDadoModel.COLUMN_ENDERECO].ToString();
                    //cl.Numero = Reader[BaseOriginalDadoModel.COLUMN_NUM_BENEFICIO].ToString();
                    cl.Ddd = Reader[BaseOriginalDadoModel.COLUMN_DDD].ToString();
                    cl.Telefone = Reader[BaseOriginalDadoModel.COLUMN_TELEFONE].ToString();
                    cl.Nome = Reader[BaseOriginalDadoModel.COLUMN_NOME].ToString();
                    cl.Bairro = Reader[BaseOriginalDadoModel.COLUMN_BAIRRO].ToString();
                    //cl.Complemento = Reader[BaseOriginalDadoModel.COLUMN_COMPLEMENTO].ToString();
                    #endregion

                    #region Dados Emprestimo
                    emp.ClienteId = cl.Id;
                    emp.PreencheValorParcela(Reader[BaseOriginalDadoModel.COLUMN_VALOR_PARCELA].ToString());
                    emp.PreencheValorBruto(Reader[BaseOriginalDadoModel.COLUMN_VALOR_EMPRESTIMO].ToString());
                    emp.PreencheNumBeneficio(Reader[BaseOriginalDadoModel.COLUMN_NUM_BENEFICIO].ToString());
                    emp.PreencheDataInicioPagamento(Reader[BaseOriginalDadoModel.COLUMN_DATA_INICIO_PAGAMENTO].ToString());
                    emp.PreencheDataFimPagamento(Reader[BaseOriginalDadoModel.COLUMN_DATA_FIM_PAGAMENTO].ToString());
                    emp.PreencheParcelasContrato(Reader[BaseOriginalDadoModel.COLUMN_PARCELAS_CONTRATO].ToString());
                    emp.PreencheBancoId(Reader[BaseOriginalDadoModel.COLUMN_BANCO_EMPRESTIMO].ToString());
                    emp.PreencheTipoEmprestimo(Reader[BaseOriginalDadoModel.COLUMN_TIPO_EMPRESTIMO].ToString());
                    emp.PreencheSituacaoEmprestimo(Reader[BaseOriginalDadoModel.COLUMN_SITUACAO_EMPRESTIMO].ToString());
                    #endregion

                    #region DadosBeneficio
                    ben.IdCliente = cl.Id;
                    ben.PreencheNumBeneficio(Reader[BaseOriginalDadoModel.COLUMN_NUM_BENEFICIO].ToString());
                    ben.PreencheBancoPagamento(Reader[BaseOriginalDadoModel.COLUMN_BANCO_PAGAMENTO].ToString());
                    ben.PreencheAgenciaPagamento(Reader[BaseOriginalDadoModel.COLUMN_AGENCIA_PAGAMENTO].ToString());
                    ben.PreencheOrgaoPagador(Reader[BaseOriginalDadoModel.COLUMN_ORGAO_PAGADOR].ToString());
                    ben.PreencheSalario(Reader[BaseOriginalDadoModel.COLUMN_VALOR_BENEFICIO].ToString());
                    ben.PreencheDataInicioBeneficio(Reader[BaseOriginalDadoModel.COLUMN_DATA_INICIO_BENEFICIO].ToString());
                    ben.PreencheDataIncluidoInss(Reader[BaseOriginalDadoModel.COLUMN_DATA_INCLUIDO_INSS].ToString());
                    ben.PreencheDataExcluidoInss(Reader[BaseOriginalDadoModel.COLUMN_DATA_EXCLUIDO_INSS].ToString());
                    #endregion

                    cl.Emprestimos.Clear();
                    cl.Beneficios.Clear();

                    cl.Emprestimos.Add(emp);
                    cl.Beneficios.Add(ben);

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void FecharReader()
        {
            try
            {
                Reader.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public List<ClienteModel> FiltroExportacao(FiltroModel campanha)
        {
            try
            {
                List<ClienteModel> lista = new List<ClienteModel>();
                string sql = GerarSqlFiltroExportacao(campanha);

                var reader = _context.ExecuteSqlCommandWithReturn(sql);

                while (reader.Read())
                {
                    ClienteModel cl = new ClienteModel();

                    cl.PreencheCpfEId(reader[ClienteModel.COLUMN_CPF].ToString());
                    cl.Id = long.Parse(reader[ClienteModel.COLUMN_ID].ToString());
                    cl.Nome = reader[ClienteModel.COLUMN_NOME].ToString();
                    cl.PreencheDataNascimento(reader[ClienteModel.COLUMN_DATANASCIMENTO].ToString());

                    lista.Add(cl);
                }

                reader.Close();

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Métodos privados

        private string GerarSqlImportacaoQuantidade(FiltroModel filtro)
        {
            try
            {
                string sql_command = "SELECT COUNT(*) FROM BaseOriginalDados WHERE Id = Id";

                sql_command += GerarFiltrosImportacao(filtro);

                return sql_command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GerarSqlImportacaoClientes(FiltroModel filtro)
        {
            try
            {
                string sql_command = "SELECT * FROM BaseOriginalDados WHERE Id = Id";

                sql_command += GerarFiltrosImportacao(filtro);

                return sql_command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GerarFiltrosImportacao(FiltroModel filtro)
        {
            try
            {
                string sql_command = string.Empty;

                #region Base Original

                if (filtro.BasesOriginais.Count > 0)
                {
                    sql_command += string.Format(" AND (");
                    for (int i = 0; i < filtro.BasesOriginais.Count; i++)
                    {
                        var baseOri = filtro.BasesOriginais[i];
                        if (i > 0)
                        {
                            sql_command += " OR ";
                        }
                        sql_command += string.Format("{0} = '{1}'", BaseOriginalDadoModel.COLUMN_BASE_ID, baseOri);
                    }
                    sql_command += string.Format(")");
                }

                #endregion

                #region Codigo Banco

                if (filtro.Bancos.Count > 0)
                {
                    sql_command += string.Format(" AND (");
                    for (int i = 0; i < filtro.Bancos.Count; i++)
                    {
                        var banco = filtro.Bancos[i];
                        if (i > 0)
                        {
                            sql_command += "OR";
                        }
                        sql_command += string.Format(" {0} = '{1}'", BaseOriginalDadoModel.COLUMN_BANCO_EMPRESTIMO, banco);
                    }
                    sql_command += string.Format(")");
                }

                #endregion

                #region Tipo Emprestimo

                if (filtro.TiposEmprestimos.Count > 0)
                {
                    sql_command += string.Format(" AND (");
                    for (int i = 0; i < filtro.TiposEmprestimos.Count; i++)
                    {
                        var emp = filtro.TiposEmprestimos[i];
                        if (i > 0)
                        {
                            sql_command += "OR";
                        }
                        sql_command += string.Format(" {0} = '{1}'", BaseOriginalDadoModel.COLUMN_TIPO_EMPRESTIMO, emp);
                    }
                    sql_command += string.Format(")");
                }

                #endregion

                return sql_command;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string GerarSqlFiltroExportacao(FiltroModel filtro)
        {
            try
            {
                string sql_command = "SELECT DISTINCT c.Id, c.Cpf, c.DataNascimento, c.Nome "
                + "from Cliente c, Emprestimo e where c.Id = e.ClienteId ";

                #region Valor Parcela

                if (filtro.MinParcela != 0)
                {
                    sql_command += "and " + "'" + filtro.MinParcela.ToString().Replace(',', '.') + "'"
                        + " <= e.ValorParcela ";
                }

                if (filtro.MaxParcela != 0)
                {
                    sql_command += "and " + "'" + filtro.MaxParcela.ToString().Replace(',', '.') + "'"
                        + " >= e.ValorParcela ";
                }

                #endregion

                #region Parcelas pagas

                if (filtro.MinParcelasPagas != 0)
                {
                    sql_command += "and " + "'" + filtro.MinParcelasPagas + "'"
                        + " <= (e.ParcelasNoContrato - e.ParcelasEmAberto) ";
                }

                if (filtro.MaxParcelasPagas != 0)
                {
                    sql_command += "and " + "'" + filtro.MaxParcelasPagas
                        + "'" + " >= (e.ParcelasNoContrato - e.ParcelasEmAberto) ";
                }

                #endregion

                #region Parcelas no contrato

                if (filtro.MinParcelasContrato != 0)
                {
                    sql_command += "and " + "'" + filtro.MinParcelasContrato + "'" + " <= e.ParcelasNoContrato ";
                }

                if (filtro.MaxParcelasContrato != 0)
                {
                    sql_command += "and " + "'" + filtro.MaxParcelasContrato + "'" + " >= e.ParcelasNoContrato ";
                }

                #endregion

                #region Parcelas em aberto

                if (filtro.MinParcelasEmAberto != 0)
                {
                    sql_command += "and " + "'" + filtro.MinParcelasEmAberto + "'" + " <= e.ParcelasEmAberto ";
                }

                if (filtro.MaxParcelasEmAberto != 0)
                {
                    sql_command += "and " + "'" + filtro.MaxParcelasEmAberto + "'" + " >= e.ParcelasEmAberto ";
                }

                #endregion

                #region Data Inicio Pagamento

                if (filtro.MinDataInicioPag != null)
                {
                    sql_command += "and " + "'" + filtro.MinDataInicioPag + "'" + " <= e.InicioPagamento ";
                }

                if (filtro.MaxDataInicioPag != null)
                {
                    sql_command += "and " + "'" + filtro.MaxDataInicioPag + "'" + " >= e.InicioPagamento ";
                }

                #endregion

                #region Data Nascimento

                if (filtro.MinDataNascimento != null)
                {
                    sql_command += "and " + "'" + filtro.MinDataNascimento + "'" + " <= c.DataNascimento ";
                }

                if (filtro.MaxDataNascimento != null)
                {
                    sql_command += "and " + "'" + filtro.MaxDataNascimento + "'" + " >= c.DataNascimento ";
                }

                #endregion

                #region Data Exportados Processa

                if (filtro.NuncaExpProcessa)
                {
                    sql_command += "and c.DataExpProcessa IS NULL ";
                }
                else
                {
                    if (filtro.MinDataExpProcessa != null)
                    {
                        sql_command += "and " + "'" + filtro.MinDataExpProcessa + "'" + " <= c.DataExpProcessa ";
                    }

                    if (filtro.MaxDataExpProcessa != null)
                    {
                        sql_command += "and " + "'" + filtro.MaxDataExpProcessa + "'" + " >= c.DataExpProcessa ";
                    }

                }

                #endregion

                #region Data Telefones Atualizados

                if (filtro.NuncaExpTelefone)
                {
                    sql_command += "and c.DataTelAtualizado IS NULL ";
                }
                else
                {
                    if (filtro.MinDataAtualTel != null)
                    {
                        sql_command += "and " + "'" + filtro.MinDataAtualTel + "'" + " <= c.DataTelAtualizado ";
                    }

                    if (filtro.MaxDataAtualTel != null)
                    {
                        sql_command += "and " + "'" + filtro.MaxDataAtualTel + "'" + " >= c.DataTelAtualizado ";
                    }
                }

                #endregion

                #region Data Emprestimos Atualizados

                if (filtro.MinDataAtualEmp != null)
                {
                    sql_command += "and " + "'" + filtro.MinDataAtualEmp + "'" + " <= c.DataEmpAtualizados ";
                }

                if (filtro.MaxDataAtualEmp != null)
                {
                    sql_command += "and " + "'" + filtro.MaxDataAtualEmp + "'" + " >= c.DataEmpAtualizados ";
                }

                #endregion

                #region DataTrabalhado
                if (filtro.NuncaTrabalhado)
                {
                    sql_command += "and c.DataTrabalhado IS NULL ";
                }
                else
                {
                    if (filtro.MinDataTrabalhado != null)
                    {
                        sql_command += "and " + "'" + filtro.MinDataTrabalhado + "'" + " <= c.DataTrabalhado ";
                    }

                    if (filtro.MaxDataTrabalhado != null)
                    {
                        sql_command += "and " + "'" + filtro.MaxDataTrabalhado + "'" + " >= c.DataTrabalhado ";
                    }
                }
                #endregion

                #region Cep
                if (filtro.MinCep != null)
                {
                    sql_command += "and " + "'" + filtro.MinCep + "'" + " <= c.Cep ";
                }

                if (filtro.MaxCep != null)
                {
                    sql_command += "and " + "'" + filtro.MaxCep + "'" + " >= c.Cep ";
                }
                #endregion

                #region Importacao
                sql_command += string.Format(" AND ( ");
                for (int i = 0; i < filtro.Importacoes.Count; i++)
                {
                    var imp = filtro.Importacoes[i];
                    if (i > 0)
                    {
                        sql_command += "OR";
                    }
                    sql_command += string.Format(" {0} = '{1}'", ClienteModel.COLUMN_IMPORTACAO_ID, imp);
                }
                sql_command += string.Format(" )");
                #endregion

                #region Codigo Banco
                sql_command += string.Format(" AND ( ");
                for (int i = 0; i < filtro.Bancos.Count; i++)
                {
                    var banco = filtro.Bancos[i];
                    if (i > 0)
                    {
                        sql_command += "OR";
                    }
                    sql_command += string.Format(" {0} = '{1}'", EmprestimoModel.COLUMN_BANCO_ID, banco);
                }
                sql_command += string.Format(" )");
                #endregion

                #region Filtro Calculo
                if (filtro.Coeficiente != 0)
                {

                    sql_command += "and " + "'" + filtro.MinBruto.ToString().Replace(',', '.') + "'"
                        + " <= (e.ValorParcela/'" + filtro.Coeficiente.ToString().Replace(',', '.') + "') ";

                    if (filtro.MaxBruto != 0)
                    {
                        sql_command += "and " + "'" + filtro.MinBruto.ToString().Replace(',', '.') + "'"
                            + " >= (e.ValorParcela/'" + filtro.Coeficiente.ToString().Replace(',', '.') + "') ";
                    }

                    if (filtro.MinLiquido != 0)
                    {
                        sql_command += "and " + "'" + filtro.MinLiquido.ToString().Replace(',', '.') + "'"
                            + " <= ((e.ValorParcela/'" + filtro.Coeficiente.ToString().Replace(',', '.') + "') - e.Saldo) ";
                    }

                    if (filtro.MaxLiquido != 0)
                    {
                        sql_command += "and " + "'" + filtro.MaxLiquido.ToString().Replace(',', '.') + "'"
                            + " >= ((e.ValorParcela/'" + filtro.Coeficiente.ToString().Replace(',', '.') + "') - e.Saldo) ";
                    }
                }
                #endregion

                return sql_command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private BaseOriginalDadoModel TransformaReaderEmObjeto(SqlDataReader reader)
        {
            try
            {
                var temObjeto = new BaseOriginalDadoModel();
                //temObjeto.BancoId = int.Parse(reader[EmprestimoModel.COLUMN_BANCO_ID].ToString());
                //temObjeto.NumEmprestimo = int.Parse(reader[EmprestimoModel.COLUMN_NUM_EMPRESTIMO].ToString());
                //temObjeto.NumBeneficio = long.Parse(reader[EmprestimoModel.COLUMN_NUM_BENEFICIO].ToString());
                //temObjeto.ParcelasNoContrato = int.Parse(reader[EmprestimoModel.COLUMN_PARCELAS_NO_CONTRATO].ToString());
                //temObjeto.ParcelasEmAberto = int.Parse(reader[EmprestimoModel.COLUMN_PARCELAS_EM_ABERTO].ToString());
                //temObjeto.Saldo = float.Parse(reader[EmprestimoModel.COLUMN_SALDO].ToString());
                //temObjeto.ValorParcela = float.Parse(reader[EmprestimoModel.COLUMN_VALOR_PARCELA].ToString());
                //temObjeto.InicioPagamento = reader[EmprestimoModel.COLUMN_INICIO_PAGAMENTO].ToString();

                return temObjeto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        #endregion
    }
}
