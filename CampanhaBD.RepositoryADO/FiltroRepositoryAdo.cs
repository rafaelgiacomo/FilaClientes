using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampanhaBD.Model;
using CampanhaBD.Util;

namespace CampanhaBD.RepositoryADO
{
    public class FiltroRepositoryAdo
    {

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

        public List<BaseOriginalDadoModel> FiltroImportacaoBaseOriginal(FiltroModel filtro)
        {
            try
            {
                List<BaseOriginalDadoModel> listaClientes = new List<BaseOriginalDadoModel>();
                string sql = GerarSqlImportacaoClientes(filtro);

                var reader = _context.ExecuteSqlCommandWithReturn(sql);

                while (reader.Read())
                {
                    BaseOriginalDadoModel cl = new BaseOriginalDadoModel();

                    cl.PreencheId(reader[BaseOriginalDadoModel.COLUMN_ID].ToString());
                    cl.PreencheBaseId(reader[BaseOriginalDadoModel.COLUMN_BASE_ID].ToString());
                    cl.NumBeneficio = reader[BaseOriginalDadoModel.COLUMN_NUM_BENEFICIO].ToString();
                    cl.Nome = reader[BaseOriginalDadoModel.COLUMN_NOME].ToString();
                    cl.DataNascimento = reader[BaseOriginalDadoModel.COLUMN_DATA_NASCIMENTO].ToString();
                    cl.Cpf = reader[BaseOriginalDadoModel.COLUMN_CPF].ToString();
                    cl.Especie = reader[BaseOriginalDadoModel.COLUMN_ESPECIE].ToString();
                    cl.DataInicioBeneficio = reader[BaseOriginalDadoModel.COLUMN_DATA_INICIO_BENEFICIO].ToString();
                    cl.ValorBeneficio = reader[BaseOriginalDadoModel.COLUMN_VALOR_BENEFICIO].ToString();
                    cl.BancoPagamento = reader[BaseOriginalDadoModel.COLUMN_BANCO_PAGAMENTO].ToString();
                    cl.AgenciaPagamento = reader[BaseOriginalDadoModel.COLUMN_AGENCIA_PAGAMENTO].ToString();
                    cl.OrgaoPagador = reader[BaseOriginalDadoModel.COLUMN_ORGAO_PAGADOR].ToString();
                    cl.ContaCorrente = reader[BaseOriginalDadoModel.COLUMN_CONTA_CORRENTE].ToString();
                    cl.ApsBenef = reader[BaseOriginalDadoModel.COLUMN_ASP_BENEF].ToString();
                    cl.CsMeioPgto = reader[BaseOriginalDadoModel.COLUMN_CS_MEIO_PAGTO].ToString();
                    cl.BancoEmprestimo = reader[BaseOriginalDadoModel.COLUMN_BANCO_EMPRESTIMO].ToString();
                    cl.ContratoEmprestimo = reader[BaseOriginalDadoModel.COLUMN_CONTRATO_EMPRESTIMO].ToString();
                    cl.ValorEmprestimo = reader[BaseOriginalDadoModel.COLUMN_VALOR_EMPRESTIMO].ToString();
                    cl.DataInicioPagamento = reader[BaseOriginalDadoModel.COLUMN_DATA_INICIO_PAGAMENTO].ToString();
                    cl.DataFimPagamento = reader[BaseOriginalDadoModel.COLUMN_DATA_FIM_PAGAMENTO].ToString();
                    cl.ParcelasNoContrato = reader[BaseOriginalDadoModel.COLUMN_PARCELAS_CONTRATO].ToString();
                    cl.ValorParcela = reader[BaseOriginalDadoModel.COLUMN_VALOR_PARCELA].ToString();
                    cl.TipoEmprestimo = reader[BaseOriginalDadoModel.COLUMN_TIPO_EMPRESTIMO].ToString();
                    cl.Endereco = reader[BaseOriginalDadoModel.COLUMN_ENDERECO].ToString();
                    cl.Bairro = reader[BaseOriginalDadoModel.COLUMN_BAIRRO].ToString();
                    cl.Municipio = reader[BaseOriginalDadoModel.COLUMN_MUNICIPIO].ToString();
                    cl.Uf = reader[BaseOriginalDadoModel.COLUMN_UF].ToString();
                    cl.Cep = reader[BaseOriginalDadoModel.COLUMN_CEP].ToString();
                    cl.SituacaoEmprestimo = reader[BaseOriginalDadoModel.COLUMN_SITUACAO_EMPRESTIMO].ToString();
                    cl.DataIncluidoInss = reader[BaseOriginalDadoModel.COLUMN_DATA_INCLUIDO_INSS].ToString();
                    cl.DataExcluidoInss = reader[BaseOriginalDadoModel.COLUMN_DATA_EXCLUIDO_INSS].ToString();
                    cl.DataImportado = reader[BaseOriginalDadoModel.COLUMN_DATA_IMPORTADO].ToString();
                    cl.ResultadoImportacao = reader[BaseOriginalDadoModel.COLUMN_RESULTADO_IMPORTACAO].ToString();
                    cl.MsgLogImportacao = reader[BaseOriginalDadoModel.COLUMN_MSG_LOG_IMPORTACAO].ToString();

                    listaClientes.Add(cl);
                }

                return listaClientes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public bool LerDadosClienteBaseOriginal(ClienteModel cl)
        //{
        //    try
        //    {
        //        if (Reader.Read())
        //        {
        //            EmprestimoModel emp = new EmprestimoModel();
        //            BeneficioModel ben = new BeneficioModel();

        //            #region Dados Cliente
        //            cl.PreencheCpf(Reader[BaseOriginalDadoModel.COLUMN_CPF].ToString());
        //            cl.PreencheDataNascimento(Reader[BaseOriginalDadoModel.COLUMN_DATA_NASCIMENTO].ToString());
        //            cl.PreencheCep(Reader[BaseOriginalDadoModel.COLUMN_CEP].ToString());

        //            cl.Uf = Reader[BaseOriginalDadoModel.COLUMN_UF].ToString();
        //            cl.Cidade = Reader[BaseOriginalDadoModel.COLUMN_MUNICIPIO].ToString();
        //            cl.Logradouro = Reader[BaseOriginalDadoModel.COLUMN_ENDERECO].ToString();
        //            //cl.Numero = Reader[BaseOriginalDadoModel.COLUMN_NUM_BENEFICIO].ToString();
        //            cl.Ddd = Reader[BaseOriginalDadoModel.COLUMN_DDD].ToString();
        //            cl.Telefone = Reader[BaseOriginalDadoModel.COLUMN_TELEFONE].ToString();
        //            cl.Nome = Reader[BaseOriginalDadoModel.COLUMN_NOME].ToString();
        //            cl.Bairro = Reader[BaseOriginalDadoModel.COLUMN_BAIRRO].ToString();
        //            //cl.Complemento = Reader[BaseOriginalDadoModel.COLUMN_COMPLEMENTO].ToString();
        //            #endregion

        //            #region Dados Emprestimo
        //            emp.ClienteId = cl.Id;
        //            emp.PreencheValorParcela(Reader[BaseOriginalDadoModel.COLUMN_VALOR_PARCELA].ToString());
        //            emp.PreencheValorBruto(Reader[BaseOriginalDadoModel.COLUMN_VALOR_EMPRESTIMO].ToString());
        //            emp.PreencheNumBeneficio(Reader[BaseOriginalDadoModel.COLUMN_NUM_BENEFICIO].ToString());
        //            emp.PreencheDataInicioPagamento(Reader[BaseOriginalDadoModel.COLUMN_DATA_INICIO_PAGAMENTO].ToString());
        //            emp.PreencheDataFimPagamento(Reader[BaseOriginalDadoModel.COLUMN_DATA_FIM_PAGAMENTO].ToString());
        //            emp.PreencheParcelasContrato(Reader[BaseOriginalDadoModel.COLUMN_PARCELAS_CONTRATO].ToString());
        //            emp.PreencheBancoId(Reader[BaseOriginalDadoModel.COLUMN_BANCO_EMPRESTIMO].ToString());
        //            emp.PreencheTipoEmprestimo(Reader[BaseOriginalDadoModel.COLUMN_TIPO_EMPRESTIMO].ToString());
        //            emp.PreencheSituacaoEmprestimo(Reader[BaseOriginalDadoModel.COLUMN_SITUACAO_EMPRESTIMO].ToString());
        //            #endregion

        //            #region DadosBeneficio
        //            ben.IdCliente = cl.Id;
        //            ben.PreencheNumBeneficio(Reader[BaseOriginalDadoModel.COLUMN_NUM_BENEFICIO].ToString());
        //            ben.PreencheBancoPagamento(Reader[BaseOriginalDadoModel.COLUMN_BANCO_PAGAMENTO].ToString());
        //            ben.PreencheAgenciaPagamento(Reader[BaseOriginalDadoModel.COLUMN_AGENCIA_PAGAMENTO].ToString());
        //            ben.PreencheOrgaoPagador(Reader[BaseOriginalDadoModel.COLUMN_ORGAO_PAGADOR].ToString());
        //            ben.PreencheSalario(Reader[BaseOriginalDadoModel.COLUMN_VALOR_BENEFICIO].ToString());
        //            ben.PreencheDataInicioBeneficio(Reader[BaseOriginalDadoModel.COLUMN_DATA_INICIO_BENEFICIO].ToString());
        //            ben.PreencheDataIncluidoInss(Reader[BaseOriginalDadoModel.COLUMN_DATA_INCLUIDO_INSS].ToString());
        //            ben.PreencheDataExcluidoInss(Reader[BaseOriginalDadoModel.COLUMN_DATA_EXCLUIDO_INSS].ToString());
        //            #endregion

        //            cl.Emprestimos.Clear();
        //            cl.Beneficios.Clear();

        //            cl.Emprestimos.Add(emp);
        //            cl.Beneficios.Add(ben);

        //            return true;
        //        }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public void ExportaCompleto(FiltroModel campanha, ref ExportacaoModel exportacao, bool atualizarDataTrabalhado)
        {
            try
            {
                string sql = GerarSqlFiltroExportacaoCompleto(campanha);

                var reader = _context.ExecuteSqlCommandWithReturn(sql);

                CsvRow row = new CsvRow();
                while (reader.Read())
                {
                    row.Add(reader[EmprestimoModel.COLUMN_NUM_BENEFICIO].ToString());
                    row.Add(reader[BeneficioModel.COLUMN_ESPECIE].ToString());
                    
                    row.Add(reader[ClienteModel.COLUMN_CPF].ToString());
                    row.Add(string.Format("{0:dd/MM/yyy}", DateTime.Parse(reader[ClienteModel.COLUMN_DATANASCIMENTO].ToString())));
                    row.Add(reader[ClienteModel.COLUMN_NOME].ToString());
                    row.Add(reader[ClienteModel.COLUMN_UF].ToString());
                    row.Add(reader[ClienteModel.COLUMN_CIDADE].ToString());
                    row.Add(reader[ClienteModel.COLUMN_BAIRRO].ToString());
                    row.Add(reader[ClienteModel.COLUMN_CEP].ToString());
                    row.Add(reader[ClienteModel.COLUMN_LOGRADOURO].ToString());
                    row.Add(reader[ClienteModel.COLUMN_NUMERO].ToString());
                    row.Add(reader[ClienteModel.COLUMN_COMPLEMENTO].ToString());
                    row.Add(reader[ClienteModel.COLUMN_DDD].ToString());
                    row.Add(reader[ClienteModel.COLUMN_TELEFONE].ToString());
                    row.Add(reader[ClienteModel.COLUMN_DDD2].ToString());
                    row.Add(reader[ClienteModel.COLUMN_TELEFONE2].ToString());
                    row.Add(reader[ClienteModel.COLUMN_DATA_EMP_ATUALIZADOS].ToString());
                    row.Add(reader[ClienteModel.COLUMN_DATA_TEL_ATUALIZADO].ToString());
                    row.Add(reader[ClienteModel.COLUMN_DATA_TRABALHADO].ToString());
                    row.Add(reader[ClienteModel.COLUMN_DATA_EXP_PROCESSA].ToString());
                    row.Add(reader[ClienteModel.COLUMN_DATA_IMPORTADO].ToString());
                    row.Add(reader[ClienteModel.COLUMN_ATIVADO].ToString());

                    row.Add(reader[EmprestimoModel.COLUMN_DATA_EXCLUIDO_INSS].ToString());
                    row.Add(reader[EmprestimoModel.COLUMN_BANCO_ID].ToString());
                    row.Add(reader[EmprestimoModel.COLUMN_FIM_PAGAMENTO].ToString());
                    row.Add(reader[EmprestimoModel.COLUMN_INICIO_PAGAMENTO].ToString());
                    row.Add(reader[EmprestimoModel.COLUMN_PARCELAS_NO_CONTRATO].ToString());
                    row.Add(reader[EmprestimoModel.COLUMN_PARCELAS_EM_ABERTO].ToString());
                    row.Add(reader[EmprestimoModel.COLUMN_SALDO].ToString());
                    row.Add(reader[EmprestimoModel.COLUMN_SITUACAO_EMPRESTIMO].ToString());
                    row.Add(reader[EmprestimoModel.COLUMN_TIPO_EMPRESTIMO].ToString());
                    row.Add(reader[EmprestimoModel.COLUMN_VALOR_BRUTO].ToString());
                    row.Add(reader[EmprestimoModel.COLUMN_VALOR_PARCELA].ToString());

                    exportacao.EscreverLinha(row);

                    row.Clear();
                }

                reader.Close();

                if (atualizarDataTrabalhado)
                {
                    string sqlAtualizacao = GerarSqlAtualizarDataTrabalhado(campanha);

                    _context.ExecuteSqlCommandNoReturn(sqlAtualizacao);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ExportaTelefone(FiltroModel campanha, ref ExportacaoModel exportacao)
        {
            try
            {
                string sql = GerarSqlFiltroExportacaoTelefone(campanha);

                var reader = _context.ExecuteSqlCommandWithReturn(sql);

                CsvRow row = new CsvRow();
                while (reader.Read())
                {
                    row.Add(reader[ClienteModel.COLUMN_CPF].ToString());

                    exportacao.EscreverLinha(row);

                    row.Clear();
                }

                reader.Close();

                string sqlAtualizacao = GerarSqlAtualizarDataTelefone(campanha);

                _context.ExecuteSqlCommandNoReturn(sqlAtualizacao);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExportaProcessa(FiltroModel campanha, ref ExportacaoModel exportacao)
        {
            try
            {
                string sql = GerarSqlFiltroExportacaoProcessa(campanha);
                var reader = _context.ExecuteSqlCommandWithReturn(sql);

                CsvRow row = new CsvRow();
                while (reader.Read())
                {

                    row.Add(reader[EmprestimoModel.COLUMN_NUM_BENEFICIO].ToString());
                    row.Add(string.Format("{0:dd/MM/yyy}", DateTime.Parse(reader[ClienteModel.COLUMN_DATANASCIMENTO].ToString())));
                    row.Add(reader[ClienteModel.COLUMN_CPF].ToString());
                    row.Add(reader[ClienteModel.COLUMN_NOME].ToString());
                    row.Add(string.Empty);
                    row.Add(reader[ClienteModel.COLUMN_UF].ToString());
                    row.Add(string.Empty);
                    row.Add(string.Empty);
                    row.Add(string.Empty);

                    exportacao.EscreverLinha(row);

                    row.Clear();
                }

                reader.Close();

                string sqlAtualizacao = GerarSqlAtualizarDataExpProcessa(campanha);

                _context.ExecuteSqlCommandNoReturn(sqlAtualizacao);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ClienteModel> ExportaProcessa(FiltroModel campanha)
        {
            try
            {
                List<ClienteModel> lista = new List<ClienteModel>();
                string sql = GerarSqlFiltroExportacaoProcessa(campanha);

                var reader = _context.ExecuteSqlCommandWithReturn(sql);

                while (reader.Read())
                {
                    ClienteModel cl = new ClienteModel();
                    BeneficioModel ben = new BeneficioModel();

                    cl.PreencheCpf(reader[ClienteModel.COLUMN_CPF].ToString());
                    cl.Id = long.Parse(reader[ClienteModel.COLUMN_ID].ToString());
                    cl.Nome = reader[ClienteModel.COLUMN_NOME].ToString();
                    cl.PreencheDataNascimento(reader[ClienteModel.COLUMN_DATANASCIMENTO].ToString());
                    ben.PreencheNumBeneficio(reader[EmprestimoModel.COLUMN_NUM_BENEFICIO].ToString());

                    cl.Beneficios.Add(ben);

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

        //Gera SQL para Estimar QTD de clientes com Filtro na tabela BaseOriginalDados
        private string GerarSqlImportacaoQuantidade(FiltroModel filtro)
        {
            try
            {
                string sql_command = "SELECT COUNT(*) FROM BaseOriginalDados WHERE [Id] = [Id]";

                sql_command += GerarFiltrosImportacao(filtro);

                return sql_command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Gera SQL para importação da Tabela BaseOriginalDados
        private string GerarSqlImportacaoClientes(FiltroModel filtro)
        {
            try
            {
                string sql_command = "SELECT * FROM BaseOriginalDados WHERE [Id] = [Id]";

                sql_command += GerarFiltrosImportacao(filtro);

                return sql_command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Gera Filtros para SQL de importação
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

        //Gera SQL para Exportação de Telefone
        private string GerarSqlFiltroExportacaoTelefone(FiltroModel filtro)
        {
            try
            {
                string sql_command = "SELECT DISTINCT c.Cpf from Cliente c, Emprestimo e, Beneficio b where c.Id = e.ClienteId "
                    + "AND c.Id = b.ClienteId AND e.NumBeneficio = b.Numero AND c.Ativado = 'true' ";

                return sql_command += SqlFiltrosExportacao(filtro);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Gera SQL para exportação Processa
        private string GerarSqlFiltroExportacaoProcessa(FiltroModel filtro)
        {
            try
            {
                string sql_command = "SELECT DISTINCT c.Id, c.Cpf, c.DataNascimento, c.Nome, c.Uf, e.NumBeneficio "
                + "from Cliente c, Emprestimo e, Beneficio b where c.Id = e.ClienteId AND c.Id = b.ClienteId AND e.NumBeneficio = b.Numero AND c.Ativado = 'true' ";

                return sql_command += SqlFiltrosExportacao(filtro);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Gera SQL para exportação Completa
        private string GerarSqlFiltroExportacaoCompleto(FiltroModel filtro)
        {
            try
            {
                string sql_command = "SELECT * from Cliente c, Emprestimo e, Beneficio b where c.Id = e.ClienteId AND c.Id = b.ClienteId AND "
                    + "e.NumBeneficio = b.Numero AND c.Ativado = 'true' ";

                return sql_command += SqlFiltrosExportacao(filtro);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Gera Filtro de Ids para atualizacao
        private string GerarSqlFiltroIdParaAtualizacao(FiltroModel filtro)
        {
            try
            {
                string sql_command = "SELECT DISTINCT [Id] from Cliente c, Emprestimo e, Beneficio b where c.Id = e.ClienteId "
                    + "AND c.Id = b.ClienteId AND e.NumBeneficio = b.Numero AND c.Ativado = 'true' ";

                return sql_command += SqlFiltrosExportacao(filtro);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Gera Filtros para Exportação
        private string SqlFiltrosExportacao(FiltroModel filtro)
        {
            try
            {
                string sql_command = "";

                sql_command += " AND e.DataExcluidoInss IS NULL ";

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
                if (filtro.Importacoes.Count > 0)
                {
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
                }
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

                #region Tipo Empréstimo

                if (filtro.TiposEmprestimos.Count > 0)
                {
                    sql_command += string.Format(" AND ( ");

                    if (filtro.NaoImportarTipo)
                    {
                        for (int i = 0; i < filtro.TiposEmprestimos.Count; i++)
                        {
                            var tipo = filtro.TiposEmprestimos[i];

                            if (i > 0)
                            {
                                sql_command += "AND";
                            }
                            sql_command += string.Format(" {0} <> '{1}'", EmprestimoModel.COLUMN_TIPO_EMPRESTIMO, tipo);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < filtro.TiposEmprestimos.Count; i++)
                        {
                            var tipo = filtro.TiposEmprestimos[i];

                            if (i > 0)
                            {
                                sql_command += "OR";
                            }
                            sql_command += string.Format(" {0} = '{1}'", EmprestimoModel.COLUMN_TIPO_EMPRESTIMO, tipo);
                        }
                    }

                    sql_command += string.Format(" )");
                }

                #endregion

                #region Especie beneficio

                if (filtro.Especies.Count > 0)
                {
                    sql_command += string.Format(" AND ( ");

                    if (filtro.NaoImportarEspecie)
                    {
                        for (int i = 0; i < filtro.Especies.Count; i++)
                        {
                            var espe = filtro.Especies[i];

                            if (i > 0)
                            {
                                sql_command += "AND";
                            }
                            sql_command += string.Format(" {0} <> '{1}'", BeneficioModel.COLUMN_ESPECIE, espe);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < filtro.Especies.Count; i++)
                        {
                            var esp = filtro.Especies[i];

                            if (i > 0)
                            {
                                sql_command += "OR";
                            }
                            sql_command += string.Format(" {0} = '{1}'", BeneficioModel.COLUMN_ESPECIE, esp);
                        }
                    }

                    sql_command += string.Format(" )");
                }

                #endregion

                return sql_command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Gera SQL para atualizar DataTrabalhado
        private string GerarSqlAtualizarDataTrabalhado(FiltroModel filtro)
        {
            try
            {
                string sql_command = string.Empty;
                sql_command += "UPDATE Cliente SET DataTrabalhado = CONVERT(date, GETDATE()) WHERE[Id] in ";
                sql_command += "(";
                sql_command += GerarSqlFiltroIdParaAtualizacao(filtro);
                sql_command += ")";

                return sql_command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Gera SQL para atualizar DataTrabalhado
        private string GerarSqlAtualizarDataExpProcessa(FiltroModel filtro)
        {
            try
            {
                string sql_command = string.Empty;
                sql_command += "UPDATE Cliente SET DataExpProcessa = CONVERT(date, GETDATE()) WHERE[Id] in ";
                sql_command += "(";
                sql_command += GerarSqlFiltroIdParaAtualizacao(filtro);
                sql_command += ")";

                return sql_command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Gera SQL para atualizar DataTelAtualizado
        private string GerarSqlAtualizarDataTelefone(FiltroModel filtro)
        {
            try
            {
                string sql_command = string.Empty;
                sql_command += "UPDATE Cliente SET DataTelAtualizado = CONVERT(date, GETDATE()) WHERE[Id] in ";
                sql_command += "(";
                sql_command += GerarSqlFiltroIdParaAtualizacao(filtro);
                sql_command += ")";

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
