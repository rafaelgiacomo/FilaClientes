using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Interface;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class ClienteRepositoryAdo : IRepository<ClienteModel>
    {
        private Context _context;

        public ClienteRepositoryAdo(Context context)
        {
            _context = context;
        }

        #region Metodos Publicos
        public void Inserir(ClienteModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ClienteModel.COLUMN_IMPORTACAO_ID, ClienteModel.COLUMN_NOME, ClienteModel.COLUMN_CPF,
                    ClienteModel.COLUMN_UF, ClienteModel.COLUMN_CIDADE, ClienteModel.COLUMN_BAIRRO, ClienteModel.COLUMN_DDD,
                    ClienteModel.COLUMN_TELEFONE, ClienteModel.COLUMN_DATANASCIMENTO, ClienteModel.COLUMN_LOGRADOURO,
                    ClienteModel.COLUMN_NUMERO, ClienteModel.COLUMN_COMPLEMENTO, ClienteModel.COLUMN_CEP
                };

                object[] values =
                {
                    entidade.ImportacaoId, entidade.Nome, entidade.Cpf, entidade.Uf, entidade.Cidade, entidade.Bairro,
                    entidade.Ddd, entidade.Telefone, entidade.DataNascimento, entidade.Logradouro, entidade.Numero,
                    entidade.Complemento, entidade.Cep
                };

                var reader = _context.ExecuteProcedureWithReturn(
                    ClienteModel.PROCEDURE_INSERT, parameters, values);

                if (reader.Read())
                {
                    var ultimoId = reader[0].ToString();

                    if (!string.IsNullOrEmpty(ultimoId))
                        entidade.Id = Convert.ToInt32(ultimoId);
                }

                reader.Close();

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void Alterar(ClienteModel entidade)
        {
            try
            {
                var strQuery = "UPDATE Cliente SET";

                strQuery += string.Format(" {0} = '{1}'", ClienteModel.COLUMN_IMPORTACAO_ID, entidade.ImportacaoId);

                if ("".Equals(entidade.Nome))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_NOME, entidade.Nome);
                if (!"".Equals(entidade.Uf))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_UF, entidade.Uf);
                if (!"".Equals(entidade.Cidade))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_CIDADE, entidade.Cidade);
                if (!"".Equals(entidade.Bairro))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_BAIRRO, entidade.Bairro);
                if (!"".Equals(entidade.Ddd))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_DDD, entidade.Ddd);
                if (!"".Equals(entidade.Telefone))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_TELEFONE, entidade.Telefone);
                if (!"".Equals(entidade.DataNascimento))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_DATANASCIMENTO, entidade.DataNascimento);
                if (!"".Equals(entidade.Logradouro))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_LOGRADOURO, entidade.Logradouro);
                if (!"".Equals(entidade.Numero))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_NUMERO, entidade.Numero);
                if (!"".Equals(entidade.Complemento))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_COMPLEMENTO, entidade.Complemento);
                if (!"".Equals(entidade.Cep))
                    strQuery += string.Format(", {0} = '{1}'", ClienteModel.COLUMN_CEP, entidade.Cep);

                strQuery += string.Format(" WHERE {0} = '{1}' ", ClienteModel.COLUMN_ID, entidade.Id);

                _context.ExecuteSqlCommandNoReturn(strQuery);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AtualizarDataExpProcessa(ClienteModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ClienteModel.COLUMN_ID
                };

                object[] values =
                {
                    entidade.Id
                };

                _context.ExecuteProcedureNoReturn(
                    ClienteModel.PROCEDURE_UPDATE_DATA_EXP_PROCESSA, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void AtualizarDataTelefone(ClienteModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ClienteModel.COLUMN_IMPORTACAO_ID, ClienteModel.COLUMN_DATA_TEL_ATUALIZADO
                };

                object[] values =
                {
                    entidade.ImportacaoId, entidade.DataTelAtualizado
                };

                _context.ExecuteProcedureNoReturn(
                    ClienteModel.PROCEDURE_UPDATE_DATA_TELEFONE, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void AtualizarDataEmprestimo(ClienteModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ClienteModel.COLUMN_IMPORTACAO_ID, ClienteModel.COLUMN_DATA_EMP_ATUALIZADOS
                };

                object[] values =
                {
                    entidade.ImportacaoId, entidade.DataEmpAtualizado
                };

                _context.ExecuteProcedureNoReturn(
                    ClienteModel.PROCEDURE_UPDATE_DATA_EMPRESTIMO, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void AtualizarDataTrabalhado(ClienteModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ClienteModel.COLUMN_ID
                };

                object[] values =
                {
                    entidade.Id
                };

                _context.ExecuteProcedureNoReturn(
                    ClienteModel.PROCEDURE_UPDATE_DATA_TRABALHADO, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void AlterarImportacao(ClienteModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ClienteModel.COLUMN_ID, ClienteModel.COLUMN_IMPORTACAO_ID
                };

                object[] values =
                {
                    entidade.Id, entidade.ImportacaoId
                };

                _context.ExecuteProcedureNoReturn(
                    ClienteModel.PROCEDURE_UPDATE_IMPORTACAO, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void Excluir(ClienteModel entidade)
        {
            //var strQuery = string.Format(" DELETE FROM Cliente WHERE pessoa_id = {0}", entidade.Id);
            //_context.ExecutaComando(strQuery);
        }

        public List<ClienteModel> ListarTodos()
        {
            return new List<ClienteModel>();
            //var strQuery = " SELECT * FROM Cliente ";
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public ClienteModel ListarPorId(ClienteModel entidade)
        {
            try
            {
                ClienteModel retorno = null;

                string[] parameters = { ClienteModel.COLUMN_ID };

                object[] values = { entidade.Id };

                var reader = _context.ExecuteProcedureWithReturn(
                    ClienteModel.PROCEDURE_SELECT_BY_ID, parameters, values);

                if (reader.Read())
                {
                    retorno = TransformaReaderEmObjeto(reader);
                }

                reader.Close();

                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ClienteModel ListarPorCpf(ClienteModel entidade)
        {
            try
            {
                ClienteModel retorno = null;

                string[] parameters = { ClienteModel.COLUMN_CPF };

                object[] values = { entidade.Cpf };

                var reader = _context.ExecuteProcedureWithReturn(
                    ClienteModel.PROCEDURE_SELECT_BY_CPF, parameters, values);

                if (reader.Read())
                {
                    retorno = TransformaReaderEmObjeto(reader);
                }

                reader.Close();

                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long SelecionarIdPorCpf(ClienteModel entidade)
        {
            try
            {
                long retorno = 0;

                string[] parameters = { ClienteModel.COLUMN_CPF };

                object[] values = { entidade.Cpf };

                var reader = _context.ExecuteProcedureWithReturn(
                    ClienteModel.PROCEDURE_SELECT_ID_BY_CPF, parameters, values);

                if (reader.Read())
                {
                    retorno = long.Parse(reader[ClienteModel.COLUMN_ID].ToString());
                }

                reader.Close();

                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ClienteModel> TransformaSqlEmLista(string sql)
        {
            try
            {
                List<ClienteModel> lista = new List<ClienteModel>();

                SqlDataReader reader = _context.ExecuteSqlCommandWithReturn(sql);

                while (reader.Read())
                {
                    var entidade = TransformaReaderEmObjeto(reader);

                    lista.Add(entidade);
                }

                reader.Close();

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public static ClienteModel TransformaReaderEmObjeto(SqlDataReader reader)
        {
            try
            {
                var temObjeto = new ClienteModel();
                temObjeto.Id = long.Parse(reader[ClienteModel.COLUMN_ID].ToString());
                temObjeto.Nome = reader[ClienteModel.COLUMN_NOME].ToString();
                temObjeto.Uf = reader[ClienteModel.COLUMN_UF].ToString();
                temObjeto.Cidade = reader[ClienteModel.COLUMN_CIDADE].ToString();
                temObjeto.Bairro = reader[ClienteModel.COLUMN_BAIRRO].ToString();
                temObjeto.Ddd = reader[ClienteModel.COLUMN_DDD].ToString();
                temObjeto.Telefone = reader[ClienteModel.COLUMN_TELEFONE].ToString();
                temObjeto.Logradouro = reader[ClienteModel.COLUMN_LOGRADOURO].ToString();
                temObjeto.Cep = reader[ClienteModel.COLUMN_CEP].ToString();
                temObjeto.Numero = reader[ClienteModel.COLUMN_NUMERO].ToString();
                temObjeto.Complemento = reader[ClienteModel.COLUMN_COMPLEMENTO].ToString();
                temObjeto.Cpf = reader[ClienteModel.COLUMN_CPF].ToString();
                temObjeto.ImportacaoId = int.Parse(reader[ClienteModel.COLUMN_IMPORTACAO_ID].ToString());

                var dataNascimento = reader[ClienteModel.COLUMN_DATANASCIMENTO].ToString();
                var dataTrabalhado = reader[ClienteModel.COLUMN_DATA_TRABALHADO].ToString();
                var dataEmpAtualizado = reader[ClienteModel.COLUMN_DATA_EMP_ATUALIZADOS].ToString();
                var dataTelAtualizado = reader[ClienteModel.COLUMN_DATA_TEL_ATUALIZADO].ToString();
                var dataImportado = reader[ClienteModel.COLUMN_DATA_IMPORTADO].ToString();

                if (!"".Equals(dataTrabalhado))
                {
                    temObjeto.DataTrabalhado = Convert.ToDateTime(dataTrabalhado).ToString("dd/MM/yyy");
                    Console.WriteLine("Teste");
                }

                if (!"".Equals(dataEmpAtualizado))
                {
                    temObjeto.DataEmpAtualizado = Convert.ToDateTime(dataEmpAtualizado).ToString("dd/MM/yyy");
                }

                if (!"".Equals(dataTelAtualizado))
                {
                    temObjeto.DataTelAtualizado = Convert.ToDateTime(dataTelAtualizado).ToString("dd/MM/yyy");
                }

                if (!"".Equals(dataImportado))
                {
                    temObjeto.DataImportado = Convert.ToDateTime(dataImportado).ToString("dd/MM/yyy");
                }

                if (!"".Equals(dataNascimento))
                {
                    temObjeto.DataNascimento = Convert.ToDateTime(dataNascimento).ToString("dd/MM/yyy");
                }

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
