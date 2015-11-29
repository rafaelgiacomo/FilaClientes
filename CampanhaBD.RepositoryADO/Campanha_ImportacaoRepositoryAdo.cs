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
        private Campanha_Importacao novo;

        public Campanha_ImportacaoRepositoryAdo(Context context, Campanha cam, Importacao imp)
        {
            _context = context;
            novo.CampanhaId = cam.Id;
            novo.ImportacaoId = imp.Id;
            novo.ClienteId = imp.UsuarioId;
        }

        public void Inserir(Campanha_Importacao entidade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Campanha_Importacao (emp_id, numero, pessoa_id) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}') ",
                entidade.CampanhaId, entidade.ImportacaoId, entidade.ClienteId);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Campanha_Importacao entidade)
        {
            var strQuery = string.Format(" DELETE FROM Campanha_Importacao WHERE  cam_id = '{0}' AND imp_id = '{1}' " +
                                         "AND pessoa_id = '{2}' ", entidade.CampanhaId, entidade.ImportacaoId,
                                         entidade.ClienteId);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Emprestimo> ListarTodos()
        {
            var strQuery = " SELECT * FROM Campanha_Importacao ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Emprestimo ListarPorId(string id, string numero, string pessoa_id)
        {
            var strQuery = string.Format(" SELECT * FROM Campanha_Importacao  WHERE camp_id = '{0}' AND  imp_id = '{1}' AND  pessoa_id = '{2}' ", id, numero, pessoa_id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<Emprestimo> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Emprestimo>();
            while (reader.Read())
            {
                var temObjeto = new Emprestimo()
                {
                    NumEmprestimo = int.Parse(reader["camp_id"].ToString()),
                    NumBeneficio = int.Parse(reader["imp_id"].ToString()),
                    ClienteId = int.Parse(reader["pessoa_id"].ToString()),
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }





    }
}
