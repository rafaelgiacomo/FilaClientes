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
            strQuery += " INSERT INTO Banco (ban_id, nome) ";
            strQuery += string.Format(" VALUES ('{0}','{1}') ", entidade.Codigo, entidade.Nome);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Banco entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Banco SET ";
            strQuery += string.Format(" nome = '{0}' ", entidade.Nome);
            strQuery += string.Format(" WHERE ban_id = '{0}' ", entidade.Codigo);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Banco entidade)
        {
            var strQuery = string.Format(" DELETE FROM Banco WHERE ban_id = {0}", entidade.Codigo);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Banco> ListarTodos()
        {
            var strQuery = " SELECT * FROM Banco ORDER BY nome";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Banco ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Banco WHERE ban_id = {0} ", id);
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
                    Codigo = int.Parse(reader["ban_id"].ToString()),
                    Nome = reader["nome"].ToString()
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    
    }
}
