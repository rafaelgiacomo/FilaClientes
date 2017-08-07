using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;
using System;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class BaseOriginalRepositoryAdo
    {
        private Context _context;

        public BaseOriginalRepositoryAdo(Context context)
        {
            _context = context;
        }

        public List<BaseOriginalModel> ListarBases()
        {
            try
            {
                List<BaseOriginalModel> lista = new List<BaseOriginalModel>();
                SqlDataReader reader = null;

                string[] parameters = { };
                object[] values = { };

                reader = _context.ExecuteProcedureWithReturn(
                    BaseOriginalModel.PROCEDURE_SELECT_ALL, parameters, values);

                while (reader.Read())
                {
                    var entidade = new BaseOriginalModel();

                    entidade.Id = int.Parse(reader[BaseOriginalModel.COLUMN_ID].ToString());
                    entidade.Descricao = reader[BaseOriginalModel.COLUMN_DESCRICAO].ToString();

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
    
    }
}
