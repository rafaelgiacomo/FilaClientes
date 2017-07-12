using CampanhaBD.Interface;
using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace CampanhaBD.RepositoryADO
{
   public class CampanhaImportacaoRepositoryAdo : IRepository<CampanhaImportacaoModel>
    {
        private Context _context;

        public CampanhaImportacaoRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(CampanhaImportacaoModel entidade)
        {
        }

        public void Alterar(CampanhaImportacaoModel entidade)
        {
        }

        public void Excluir(CampanhaImportacaoModel entidade)
        {
        }

        public List<CampanhaImportacaoModel> ListarTodos()
        {
            return new List<CampanhaImportacaoModel>();
        }

        public CampanhaImportacaoModel ListarPorId(CampanhaImportacaoModel entidade)
        {
            return new CampanhaImportacaoModel();
        }

        private List<CampanhaImportacaoModel> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<CampanhaImportacaoModel>();
            while (reader.Read())
            {
                var temObjeto = new CampanhaImportacaoModel()
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
