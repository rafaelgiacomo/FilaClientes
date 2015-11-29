using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace CampanhaBD.RepositoryADO
{
   public class Campanha_ImportacaoRepositoryAdo
    {
        private Context _context;

        public Campanha_ImportacaoRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(Campanha_Importacao entidade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Campanha_Importacao (cam_id, imp_id, usuario_id) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}') ",
                entidade.CampanhaId, entidade.ImportacaoId, entidade.UsuarioId);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Campanha_Importacao entidade)
        {
            var strQuery = string.Format(" DELETE FROM Campanha_Importacao WHERE  cam_id = '{0}' AND imp_id = '{1}' " +
                                         "AND usuario_id = '{2}' ", entidade.CampanhaId, entidade.ImportacaoId,
                                         entidade.UsuarioId);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Campanha_Importacao> ListarTodos()
        {
            var strQuery = " SELECT * FROM Campanha_Importacao ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Campanha_Importacao ListarPorId(string id, string numero, string usuario_id)
        {
            var strQuery = string.Format(" SELECT * FROM Campanha_Importacao  WHERE camp_id = '{0}' AND  imp_id = '{1}' AND  usuario_id = '{2}' ", id, numero, usuario_id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<Campanha_Importacao> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Campanha_Importacao>();
            while (reader.Read())
            {
                var temObjeto = new Campanha_Importacao()
                {
                    UsuarioId = int.Parse(reader["usuario_id"].ToString()),
                    ImportacaoId = int.Parse(reader["imp_id"].ToString()),
                    CampanhaId = int.Parse(reader["cam_id"].ToString()),
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }





    }
}
