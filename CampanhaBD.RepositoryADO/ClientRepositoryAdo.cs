using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Interface;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class ClientRepositoryAdo : IRepository<ClientModel>
    {
        private Context _context;

        public ClientRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(ClientModel entidade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Clientes (Cpf, Nome, Ddd, Telefone) ";
            strQuery += string.Format(" VALUES ('{0}','{1}', '{2}', '{3}') ",
                entidade.Cpf, entidade.Nome, entidade.Ddd, entidade.Telefone);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(ClientModel entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Clientes SET ";
            strQuery += string.Format(" Cpf = '{0}', ", entidade.Cpf);
            strQuery += string.Format(" Nome = '{0}', ", entidade.Nome);
            strQuery += string.Format(" Ddd = '{0}', ", entidade.Ddd);
            strQuery += string.Format(" Telefone = '{0}' ", entidade.Telefone);
            strQuery += string.Format(" WHERE Id = {0} ", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(ClientModel entidade)
        {
            var strQuery = string.Format(" DELETE FROM Clientes WHERE Id = {0}", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<ClientModel> ListarTodos()
        {
            var strQuery = " SELECT * FROM Clientes ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public ClientModel ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Clientes WHERE Id = {0} ", id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<ClientModel> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<ClientModel>();
            while (reader.Read())
            {
                var temObjeto = new ClientModel()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Cpf = reader["Cpf"].ToString(),
                    Ddd = reader["Ddd"].ToString(),
                    Telefone = reader["Telefone"].ToString()
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }

    }
}
