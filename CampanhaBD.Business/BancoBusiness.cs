using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Business
{
    public class BancoBusiness
    {
        private string _connectionString;

        public BancoBusiness(string connectionString)
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

        public void AdicionarBanco(BancoModel entidade)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Bancos.Inserir(entidade);
                }                    
            }
            catch
            {
                throw;
            }
        }

        public void AlterarBanco(BancoModel entidade)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Bancos.Alterar(entidade);
                }                
            }
            catch
            {
                throw;
            }
        }

        public void ExcluirBanco(int codigo)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    BancoModel entidade = new BancoModel();
                    entidade.Codigo = codigo;
                    unit.Bancos.Excluir(entidade);
                }                
            }
            catch
            {
                throw;
            }
        }

        public List<BancoModel> ListarTodos()
        {
            try
            {
                List<BancoModel> listaRetorno = new List<BancoModel>();

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    listaRetorno = unit.Bancos.ListarTodos();
                }                

                return listaRetorno;
            }
            catch
            {
                throw;
            }
        }

        public BancoModel ListarPorCodigo(int codigo)
        {
            try
            {
                BancoModel retorno = null;

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    BancoModel entidade = new BancoModel();
                    entidade.Codigo = codigo;

                    retorno = unit.Bancos.ListarPorId(entidade);
                }                

                return retorno;
            }
            catch
            {
                throw;
            }
        }

    }
}
