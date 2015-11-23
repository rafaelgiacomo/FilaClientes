using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Interface;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class ClienteRepositoryAdo : IRepository<Cliente>
    {
        private Context _context;
        private readonly PessoaRepositoryAdo _pessoaRepositorioADO;

        public ClienteRepositoryAdo(Context context)
        {
            _context = context;
            _pessoaRepositorioADO = new PessoaRepositoryAdo(context);
        }

        public void Inserir(Cliente entidade)
        {
            entidade.Classificacao = Pessoa.CLIENTE;
            _pessoaRepositorioADO.Inserir((Pessoa)entidade);
            entidade.Id = _pessoaRepositorioADO.UltimoId;

            var strQuery = "";
            strQuery += " INSERT INTO CLIENTE (dataNasc, estado, cidade, bairro, ddd, telefone, logradouro" +
                        " cep, trabalhado, numero, complemento, CPF, imp_id) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', " +
                " '{10}', '{11}', '{12}') ", entidade.DataNascimento, entidade.Uf, entidade.Cidade, entidade.Bairro, entidade.Ddd, 
                entidade.Telefone, entidade.Logradouro, entidade.Cep, entidade.Trabalhado, entidade.Numero, entidade.Complemento, entidade.Cpf, entidade.ImportacaoId);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Cliente entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Cliente SET ";
            strQuery += string.Format(" dataNasc = '{0}', ", entidade.DataNascimento);
            strQuery += string.Format(" estado = '{0}', ", entidade.Uf);
            strQuery += string.Format(" cidade = '{0}', ", entidade.Cidade);
            strQuery += string.Format(" bairro = '{0}', ", entidade.Bairro);
            strQuery += string.Format(" ddd = '{0}', ", entidade.Ddd);
            strQuery += string.Format(" telefone = '{0}', ", entidade.Telefone);
            strQuery += string.Format(" logradouro = '{0}', ", entidade.Logradouro);
            strQuery += string.Format(" cep = '{0}', ", entidade.Cep);
            strQuery += string.Format(" trabalhado = '{0}' ", entidade.Trabalhado);
            strQuery += string.Format(" numero = '{0}', ", entidade.Numero);
            strQuery += string.Format(" complemento = '{0}', ", entidade.Complemento);
            strQuery += string.Format(" CPF = '{0}', ", entidade.Cpf);
            strQuery += string.Format(" imp_id = '{0}', ", entidade.ImportacaoId);
            strQuery += string.Format(" WHERE pessoa_id = {0} ", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Cliente entidade)
        {
            var strQuery = string.Format(" DELETE FROM Cliente WHERE pessoa_id = {0}", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            var strQuery = " SELECT * FROM Cliente ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Cliente ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Cliente WHERE pessoa_id = {0} ", id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<Cliente> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Cliente>();
            while (reader.Read())
            {
                var temObjeto = new Cliente()
                {
                    Id = int.Parse(reader["pessoa_id"].ToString()),
                    DataNascimento = DateTime.Parse(reader["dataNasc"].ToString()),
                    Uf = reader["estado"].ToString(),
                    Cidade = reader["cidade"].ToString(),
                    Bairro = reader["bairro"].ToString(),
                    Ddd = reader["ddd"].ToString(),
                    Telefone = reader["telefone"].ToString(),
                    Logradouro = reader["logradouro"].ToString(),
                    Numero = reader["numero"].ToString(),
                    Cep = reader["cep"].ToString(),
                    Trabalhado = bool.Parse(reader["trabalhado"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }

    }
}
