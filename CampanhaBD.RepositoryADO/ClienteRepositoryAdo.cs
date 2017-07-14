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

        public void Inserir(ClienteModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ClienteModel.COLUMN_IMPORTACAO_ID, ClienteModel.COLUMN_NOME, ClienteModel.COLUMN_CPF,
                    ClienteModel.COLUMN_UF, ClienteModel.COLUMN_CIDADE, ClienteModel.COLUMN_BAIRRO, ClienteModel.COLUMN_DDD,
                    ClienteModel.COLUMN_TELEFONE, ClienteModel.COLUMN_DATANASCIMENTO, ClienteModel.COLUMN_LOGRADOURO,
                    ClienteModel.COLUMN_NUMERO, ClienteModel.COLUMN_COMPLEMENTO, ClienteModel.COLUMN_CEP,
                    ClienteModel.COLUMN_TEL_ATUALIZADO, ClienteModel.COLUMN_EMP_ATUALIZADO, ClienteModel.COLUMN_TRABALHADO
                };

                object[] values =
                {
                    entidade.ImportacaoId, entidade.Nome, entidade.Cpf, entidade.Uf, entidade.Cidade, entidade.Bairro,
                    entidade.Ddd, entidade.Telefone, entidade.DataNascimento, entidade.Logradouro, entidade.Numero,
                    entidade.Complemento, entidade.Cep, entidade.TelAtualizado, entidade.EmpAtualizado, entidade.Trabalhado
                };

                var reader = _context.ExecuteProcedureWithReturn(
                    ClienteModel.PROCEDURE_INSERT, parameters, values);

                if (reader.Read())
                {
                    var ultimoId = reader[0].ToString();

                    if (!String.IsNullOrEmpty(ultimoId))
                        entidade.Id = Convert.ToInt32(ultimoId);
                }

                reader.Close();
            }
            catch
            {
                throw;
            }
        }

        public void Alterar(ClienteModel entidade)
        {
            //var strQuery = "";
            //strQuery += " UPDATE Cliente SET ";
            //strQuery += string.Format(" dataNasc = '{0}', ", entidade.DataNascimento);
            //strQuery += string.Format(" estado = '{0}', ", entidade.Uf);
            //strQuery += string.Format(" cidade = '{0}', ", entidade.Cidade);
            //strQuery += string.Format(" bairro = '{0}', ", entidade.Bairro);
            //strQuery += string.Format(" ddd = '{0}', ", entidade.Ddd);
            //strQuery += string.Format(" telefone = '{0}', ", entidade.Telefone);
            //strQuery += string.Format(" logradouro = '{0}', ", entidade.Logradouro);
            //strQuery += string.Format(" cep = '{0}', ", entidade.Cep);
            //strQuery += string.Format(" trabalhado = '{0}' ", entidade.Trabalhado);
            //strQuery += string.Format(" numero = '{0}', ", entidade.Numero);
            //strQuery += string.Format(" complemento = '{0}', ", entidade.Complemento);
            //strQuery += string.Format(" CPF = '{0}', ", entidade.Cpf);
            //strQuery += string.Format(" imp_id = '{0}', ", entidade.ImportacaoId);
            //strQuery += string.Format(" WHERE pessoa_id = {0} ", entidade.Id);
            //_context.ExecutaComando(strQuery);
        }

        public void AlterarImportacao(ClienteModel entidade)
        {
            //var strQuery = "";
            //strQuery += " UPDATE Cliente SET ";
            //strQuery += string.Format(" imp_id = '{0}' ", entidade.ImportacaoId);
            //strQuery += string.Format(" WHERE pessoa_id = {0} ", entidade.Id);
            //_context.ExecutaComando(strQuery);
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
            return new ClienteModel();
            //var strQuery = string.Format(" SELECT * FROM Cliente WHERE pessoa_id = {0} ", id);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
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

        private ClienteModel TransformaReaderEmObjeto(SqlDataReader reader)
        {
            try
            {
                var temObjeto = new ClienteModel();
                temObjeto.Id = long.Parse(reader["Id"].ToString());
                temObjeto.DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString());
                temObjeto.Uf = reader["Uf"].ToString();
                temObjeto.Cidade = reader["Cidade"].ToString();
                temObjeto.Bairro = reader["Bairro"].ToString();
                temObjeto.Ddd = reader["Ddd"].ToString();
                temObjeto.Telefone = reader["Telefone"].ToString();
                temObjeto.Logradouro = reader["Logradouro"].ToString();
                temObjeto.Cep = reader["Cep"].ToString();
                temObjeto.Numero = reader["Numero"].ToString();
                temObjeto.Trabalhado = bool.Parse(reader["Trabalhado"].ToString());
                temObjeto.Complemento = reader["Complemento"].ToString();
                temObjeto.Cpf = reader["Cpf"].ToString();
                temObjeto.ImportacaoId = int.Parse(reader["ImportacaoId"].ToString());

                return temObjeto;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
