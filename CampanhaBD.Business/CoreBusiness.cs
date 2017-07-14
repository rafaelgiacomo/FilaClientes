using CampanhaBD.RepositoryADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Business
{
    public class CoreBusiness
    {
        private readonly string _connectionString;
        private readonly UnityOfWorkAdo _unit;
        private static CoreBusiness _core;

        private CoreBusiness(string connectionString)
        {
            try
            {
                _connectionString = connectionString;
                _unit = UnityOfWorkAdo.getInstance(connectionString);
            }
            catch
            {
                throw;
            }
        }

        public static CoreBusiness GetInstance(string connectionString)
        {
            try
            {
                if (_core == null)
                    _core = new CoreBusiness(connectionString);

                return _core;
            }
            catch
            {
                throw;
            }
        }

        public void AbrirConexao()
        {
            try
            {
                _unit.AbrirConexao();
            }
            catch
            {
                throw;
            }
        }

        public void FecharConexao()
        {
            try
            {
                _unit.FecharConexao();
            }
            catch
            {
                throw;
            }
        }

        public UnityOfWorkAdo UnityOfWorkAdo { get { return _unit; } }

    }
}
