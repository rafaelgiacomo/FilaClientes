using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Business
{
    public class BaseOriginalBusiness
    {
        private string _connectionString;

        public BaseOriginalBusiness(string connectionString)
        {
            try
            {
                _connectionString = connectionString;
            }
            catch
            {
                throw;
            }
        }

        public List<BaseOriginalModel> ListarBases()
        {
            try
            {
                List<BaseOriginalModel> listaBases = new List<BaseOriginalModel>();

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    listaBases = unit.BasesOriginais.ListarBases();
                }                    

                return listaBases;
            }
            catch
            {
                throw;
            }
        }

    }
}
