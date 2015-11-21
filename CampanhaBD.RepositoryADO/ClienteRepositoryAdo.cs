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
            strQuery += " INSERT INTO CLIENTES (Cpf, DataNascimento, Uf, Cidade, Bairro, Ddd, Telefone, Logradouro, Numero," +
                        " Cep, Trabalhado) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}'," +
                " '{10}') ", entidade.Cpf, entidade.DataNascimento, entidade.Uf, entidade.Cidade, entidade.Bairro, entidade.Ddd, 
                entidade.Telefone, entidade.Logradouro, entidade.Numero, entidade.Cep, entidade.Trabalhado);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Cliente entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Clientes SET ";
            strQuery += string.Format(" Cpf = '{0}', ", entidade.DataNascimento);
            strQuery += string.Format(" DataNascimento = '{0}', ", entidade.DataNascimento);
            strQuery += string.Format(" Uf = '{0}', ", entidade.Uf);
            strQuery += string.Format(" Cidade = '{0}', ", entidade.Cidade);
            strQuery += string.Format(" Bairro = '{0}', ", entidade.Bairro);
            strQuery += string.Format(" Ddd = '{0}', ", entidade.Ddd);
            strQuery += string.Format(" Telefone = '{0}', ", entidade.Telefone);
            strQuery += string.Format(" Logradouro = '{0}', ", entidade.Logradouro);
            strQuery += string.Format(" Numero = '{0}', ", entidade.Numero);
            strQuery += string.Format(" Cep = '{0}', ", entidade.Cep);
            strQuery += string.Format(" Trabalhado = '{0}' ", entidade.Trabalhado);
            strQuery += string.Format(" WHERE Id = {0} ", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Cliente entidade)
        {
            var strQuery = string.Format(" DELETE FROM Clientes WHERE Id = {0}", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Cliente> ListarTodos()
        {
            var strQuery = " SELECT * FROM Clientes ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Cliente ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Clientes WHERE Id = {0} ", id);
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
                    Id = int.Parse(reader["Id"].ToString()),
                    Cpf = reader["Cpf"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString()),
                    Uf = reader["Uf"].ToString(),
                    Cidade = reader["Cidade"].ToString(),
                    Bairro = reader["Bairro"].ToString(),
                    Ddd = reader["Ddd"].ToString(),
                    Telefone = reader["Telefone"].ToString(),
                    Logradouro = reader["Logradouro"].ToString(),
                    Numero = reader["Numero"].ToString(),
                    Cep = reader["Cep"].ToString(),
                    Trabalhado = bool.Parse(reader["trabalhado"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }

    }
}
