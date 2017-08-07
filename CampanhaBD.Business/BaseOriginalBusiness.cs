using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Business
{
    public class BaseOriginalBusiness
    {
        private CoreBusiness _core;

        public BaseOriginalBusiness(CoreBusiness core)
        {
            try
            {
                _core = core;
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
                var retorno = _core.UnityOfWorkAdo.BasesOriginais.ListarBases();

                return retorno;
            }
            catch
            {
                throw;
            }
        }

    }
}
