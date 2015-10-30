using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class BancoRepositoryAdo
    {
        private Context _context;

        public BancoRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(Banco entidade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Bancos (Id, Nome) ";
            strQuery += string.Format(" VALUES ('{0}','{1}') ", entidade.Id, entidade.Nome);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Banco entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Bancos SET ";
            strQuery += string.Format(" Nome = '{0}' ", entidade.Nome);
            strQuery += string.Format(" WHERE Id = '{0}' ", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Banco entidade)
        {
            var strQuery = string.Format(" DELETE FROM Bancos WHERE Id = {0}", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Banco> ListarTodos()
        {
            var strQuery = " SELECT * FROM Bancos ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Banco ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Bancos WHERE Id = {0} ", id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<Banco> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Banco>();
            while (reader.Read())
            {
                var temObjeto = new Banco()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nome = reader["Nome"].ToString()
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    
    }
}
