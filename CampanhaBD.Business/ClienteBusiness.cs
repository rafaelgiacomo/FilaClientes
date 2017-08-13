using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Business
{
    public class ClienteBusiness
    {
        private string _connectionString;

        public ClienteBusiness(string connectionString)
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

        public void AdicionarCliente(ClienteModel entidade)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Clientes.Inserir(entidade);
                }                    
            }
            catch
            {
                throw;
            }
        }

        public void AlterarCliente(ClienteModel entidade)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Clientes.Alterar(entidade);
                }                    
            }
            catch
            {
                throw;
            }
        }

        public void ExcluirCliente(int codigo)
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

        public List<ClienteModel> ListarTodos()
        {
            try
            {
                List<ClienteModel> listaRetorno = new List<ClienteModel>();

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    var retorno = unit.Clientes.ListarTodos();
                }

                return listaRetorno;
            }
            catch
            {
                throw;
            }
        }

        public ClienteModel SelecionarPorId(int id)
        {
            try
            {
                ClienteModel retorno = null;

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    ClienteModel entidade = new ClienteModel();
                    entidade.Id = id;

                    retorno = unit.Clientes.ListarPorId(entidade);
                }

                return retorno;
            }
            catch
            {
                throw;
            }
        }

        public ClienteModel SelecionarPorCpf(int id)
        {
            try
            {
                ClienteModel retorno = null;

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    ClienteModel entidade = new ClienteModel();
                    entidade.Id = id;

                    retorno = unit.Clientes.ListarPorCpf(entidade);
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
