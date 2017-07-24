using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class CampanhaRepositoryAdo : IRepository<CampanhaModel>
    {
        private Context _context;

        public CampanhaRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(CampanhaModel entidade)
        {
            //entidade.Id = NumeroCampanha(entidade.UsuarioId);
            
            //var strQuery = " INSERT INTO Campanha (cam_id, usuario_id, nome, minParcela, maxParcela, minInicioPag," +  
            //    "maxInicioPag, minParcelasPagas, maxParcelasPagas, minDataNascimento, apenasNaoExportados, ban_id) ";

            //strQuery += string.Format("VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}') ",
            //        entidade.Id,
            //        entidade.UsuarioId,
            //        entidade.Nome,
            //        entidade.MinParcela,
            //        entidade.MaxParcela, 
            //        entidade.MinInicioPag,
            //        entidade.MaxInicioPag,
            //        entidade.MinParcelasPagas,
            //        entidade.MaxParcelasPagas,
            //        entidade.MinDataNascimento,
            //        Convert.ToByte(entidade.ApenasNaoExportados),
            //        entidade.CodigoBanco
            //    );

            ////_context.ExecutaComando(strQuery);

            ////Inserção na tabela de relacionamento entre campanha e importacao
            //foreach (ImportacaoModel imp in entidade.Importacoes)
            //{
            //    CampanhaImportacaoModel rel = new CampanhaImportacaoModel()
            //    {
            //        CampanhaId = entidade.Id,
            //        UsuarioId = entidade.UsuarioId,
            //        ImportacaoId = imp.Id
            //    };
            //    _relacionamentoRepositorioADO.Inserir(rel);
            //}
        }

        public void Alterar(CampanhaModel entidade)
        {
            //var strQuery = "";
            //strQuery += " UPDATE Campanha SET ";
            //strQuery += string.Format(" nome = '{0}', ",                          entidade.Nome);
            //strQuery += string.Format(" minParcela = '{0}', ",                    entidade.MinParcela);
            //strQuery += string.Format(" maxParcela = '{0}', ",                    entidade.MaxParcela);
            //strQuery += string.Format(" minInicioPag = '{0}', ",                  entidade.MinInicioPag);
            //strQuery += string.Format(" maxInicioPag = '{0}', ",                  entidade.MaxInicioPag);
            //strQuery += string.Format(" maxParcelasPagas = '{0}', ",              entidade.MaxParcelasPagas);
            //strQuery += string.Format(" minDataNascimento = '{0}', ",             entidade.MinDataNascimento == default(DateTime) ? null : entidade.MinDataNascimento.ToString("yyyy-MM-dd HH:mm:ss"));
            //strQuery += string.Format(" apenasNaoExportados = '{0}', ",           Convert.ToByte(entidade.ApenasNaoExportados));
            //strQuery += string.Format(" ban_id = '{0}' ",                        entidade.CodigoBanco);

            //strQuery += string.Format(" WHERE cam_id = {0} AND usuario_id = {1}", entidade.Id, entidade.UsuarioId);
            //_context.ExecutaComando(strQuery);
        }

        public void Excluir(CampanhaModel entidade)
        {
            //var strQuery = string.Format(" DELETE FROM Campanha WHERE cam_id = {0} AND usuario_id = '{1}'", entidade.Id, entidade.UsuarioId);
            //_context.ExecutaComando(strQuery);
        }

        public List<CampanhaModel> ListarTodos()
        {
            return new List<CampanhaModel>();

            //var strQuery = " SELECT * FROM Campanha ";
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public CampanhaModel ListarPorId(CampanhaModel entidade)
        {
            //var strQuery = string.Format(" SELECT * FROM Campanha WHERE cam_id = {0} AND usuario_id = {1} ", id, usuarioId);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();

            return new CampanhaModel();
        }

        public List<ClienteModel> FiltroExportacao(CampanhaModel campanha)
        {
            try
            {
                List<ClienteModel> lista = new List<ClienteModel>();
                string sql = GerarSqlFiltro(campanha);

                var reader = _context.ExecuteSqlCommandWithReturn(sql);

                while (reader.Read())
                {
                    ClienteModel cl = new ClienteModel();

                    cl.Beneficios[0].Numero = long.Parse(reader[EmprestimoModel.COLUMN_NUM_BENEFICIO].ToString());
                    cl.Id = long.Parse(reader[ClienteModel.COLUMN_ID].ToString());
                    cl.Cpf = reader[ClienteModel.COLUMN_CPF].ToString();
                    cl.Nome = reader[ClienteModel.COLUMN_NOME].ToString();

                    var dataNasc = reader[ClienteModel.COLUMN_DATANASCIMENTO].ToString();

                    if (!"".Equals(dataNasc))
                    {
                        cl.DataNascimento = Convert.ToDateTime(dataNasc).ToString("dd/MM/yyyy");
                    }       

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

        private string GerarSqlFiltro(CampanhaModel campanha)
        {
            try
            {
                string sql_command = "SELECT DISTINCT e.NumBeneficio, c.Id, c.Cpf, c.DataNascimento, c.Nome "
                + "from Cliente c, Emprestimo e where c.Id = e.ClienteId ";

                #region Valor Parcela

                if (campanha.MinParcela != 0)
                {
                    sql_command += "and " + "'" + campanha.MinParcela.ToString().Replace(',', '.') + "'" 
                        + " <= e.ValorParcela ";
                }

                if (campanha.MaxParcela != 0)
                {
                    sql_command += "and " + "'" + campanha.MaxParcela.ToString().Replace(',', '.') + "'" 
                        + " >= e.ValorParcela ";
                }

                #endregion

                #region Parcelas pagas

                if (campanha.MinParcelasPagas != 0)
                {
                    sql_command += "and " + "'" + campanha.MinParcelasPagas + "'" 
                        + " <= (e.ParcelasNoContrato - e.ParcelasEmAberto) ";
                }

                if (campanha.MaxParcelasPagas != 0)
                {
                    sql_command += "and " + "'" + campanha.MaxParcelasPagas 
                        + "'" + " >= (e.ParcelasNoContrato - e.ParcelasEmAberto) ";
                }

                #endregion

                #region Parcelas no contrato

                if (campanha.MinParcelasContrato != 0)
                {
                    sql_command += "and " + "'" + campanha.MinParcelasContrato + "'" + " <= e.ParcelasNoContrato ";
                }

                if (campanha.MaxParcelasContrato != 0)
                {
                    sql_command += "and " + "'" + campanha.MaxParcelasContrato + "'" + " >= e.ParcelasNoContrato ";
                }

                #endregion

                #region Parcelas em aberto

                if (campanha.MinParcelasEmAberto != 0)
                {
                    sql_command += "and " + "'" + campanha.MinParcelasEmAberto + "'" + " <= e.ParcelasEmAberto ";
                }

                if (campanha.MaxParcelasEmAberto != 0)
                {
                    sql_command += "and " + "'" + campanha.MaxParcelasEmAberto + "'" + " >= e.ParcelasEmAberto ";
                }

                #endregion

                #region Data Inicio Pagamento

                if (campanha.MinDataInicioPag != null)
                {
                    sql_command += "and " + "'" + campanha.MinDataInicioPag + "'" + " <= e.InicioPagamento ";
                }

                if (campanha.MaxDataInicioPag != null)
                {
                    sql_command += "and " + "'" + campanha.MaxDataInicioPag + "'" + " >= e.InicioPagamento ";
                }

                #endregion

                #region Data Nascimento

                if (campanha.MinDataNascimento != null)
                {
                    sql_command += "and " + "'" + campanha.MinDataNascimento + "'" + " <= c.DataNascimento ";
                }

                if (campanha.MaxDataNascimento != null)
                {
                    sql_command += "and " + "'" + campanha.MaxDataNascimento + "'" + " >= c.DataNascimento ";
                }

                #endregion

                #region Data Exportados Processa

                if (campanha.NuncaExpProcessa)
                {
                    sql_command += "and c.DataExpProcessa IS NULL ";
                }
                else
                {
                    if (campanha.MinDataExpProcessa != null)
                    {
                        sql_command += "and " + "'" + campanha.MinDataExpProcessa + "'" + " <= c.DataExpProcessa ";
                    }

                    if (campanha.MaxDataExpProcessa != null)
                    {
                        sql_command += "and " + "'" + campanha.MaxDataExpProcessa + "'" + " >= c.DataExpProcessa ";
                    }

                }

                #endregion

                #region Data Telefones Atualizados

                if (campanha.NuncaExpTelefone)
                {
                    sql_command += "and c.DataTelAtualizado IS NULL ";
                }
                else
                {
                    if (campanha.MinDataAtualTel != null)
                    {
                        sql_command += "and " + "'" + campanha.MinDataAtualTel + "'" + " <= c.DataTelAtualizado ";
                    }

                    if (campanha.MaxDataAtualTel != null)
                    {
                        sql_command += "and " + "'" + campanha.MaxDataAtualTel + "'" + " >= c.DataTelAtualizado ";
                    }
                }                

                #endregion

                #region Data Emprestimos Atualizados

                if (campanha.MinDataAtualEmp != null)
                {
                    sql_command += "and " + "'" + campanha.MinDataAtualEmp + "'" + " <= c.DataEmpAtualizados ";
                }

                if (campanha.MaxDataAtualEmp != null)
                {
                    sql_command += "and " + "'" + campanha.MaxDataAtualEmp + "'" + " >= c.DataEmpAtualizados ";
                }

                #endregion

                #region DataTrabalhado
                if (campanha.NuncaTrabalhado)
                {
                    sql_command += "and c.DataTrabalhado IS NULL ";
                }
                else
                {
                    if (campanha.MinDataTrabalhado != null)
                    {
                        sql_command += "and " + "'" + campanha.MinDataTrabalhado + "'" + " <= c.DataTrabalhado ";
                    }

                    if (campanha.MaxDataTrabalhado != null)
                    {
                        sql_command += "and " + "'" + campanha.MaxDataTrabalhado + "'" + " >= c.DataTrabalhado ";
                    }
                }
                #endregion

                #region Cep
                if (campanha.MinCep != null)
                {
                    sql_command += "and " + "'" + campanha.MinCep + "'" + " <= c.Cep ";
                }

                if (campanha.MaxCep != null)
                {
                    sql_command += "and " + "'" + campanha.MaxCep + "'" + " >= c.Cep ";
                }
                #endregion

                #region Codigo Banco
                if (campanha.CodigoBanco != 0)
                {
                    sql_command += "and " + "'" + campanha.CodigoBanco + "'" + " = e.BancoId ";
                }
                #endregion

                #region Filtro Calculo
                if (campanha.Coeficiente != 0)
                {

                    sql_command += "and " + "'" + campanha.MinBruto.ToString().Replace(',', '.') + "'" 
                        + " <= (e.ValorParcela/'" + campanha.Coeficiente.ToString().Replace(',', '.') + "') ";

                    if (campanha.MaxBruto != 0)
                    {
                        sql_command += "and " + "'" + campanha.MinBruto.ToString().Replace(',', '.') + "'" 
                            + " >= (e.ValorParcela/'" + campanha.Coeficiente.ToString().Replace(',', '.') + "') ";
                    }

                    if (campanha.MinLiquido != 0)
                    {
                        sql_command += "and " + "'" + campanha.MinLiquido.ToString().Replace(',', '.') + "'" 
                            + " <= ((e.ValorParcela/'" + campanha.Coeficiente.ToString().Replace(',','.') + "') - e.Saldo) ";
                    }

                    if (campanha.MaxLiquido != 0)
                    {
                        sql_command += "and " + "'" + campanha.MaxLiquido.ToString().Replace(',', '.') + "'" 
                            + " >= ((e.ValorParcela/'" + campanha.Coeficiente.ToString().Replace(',', '.') + "') - e.Saldo) ";
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

        private List<CampanhaModel> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            return new List<CampanhaModel>();

            //var usuarios = new List<CampanhaModel>();
            //while (reader.Read())
            //{
            //    var temObjeto = new CampanhaModel()
            //    {
            //        Id = int.Parse(reader["cam_id"].ToString()),
            //        UsuarioId = int.Parse(reader["usuario_id"].ToString()),
            //        Nome = reader["nome"].ToString(),
            //        MinParcela = float.Parse(reader["minParcela"].ToString()),
            //        MaxParcela = float.Parse(reader["maxParcela"].ToString()),
            //        MinInicioPag = reader["minInicioPag"].ToString(),
            //        MaxInicioPag = reader["maxInicioPag"].ToString(),
            //        MinParcelasPagas = int.Parse(reader["minParcelasPagas"].ToString()),
            //        MaxParcelasPagas = int.Parse(reader["maxParcelasPagas"].ToString()),
            //        MinDataNascimento = DateTime.Parse(reader["minDataNascimento"].ToString()),
            //        ApenasNaoExportados = bool.Parse(reader["apenasNaoExportados"].ToString()),
            //        CodigoBanco = int.Parse(reader["ban_id"].ToString())
            //    };
            //    usuarios.Add(temObjeto);
            //}
            //reader.Close();
            //return usuarios;
        }

    }
}
