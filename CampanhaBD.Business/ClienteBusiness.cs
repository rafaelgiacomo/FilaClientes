using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Business
{
    public class ClienteBusiness
    {
        private CoreBusiness _core;

        public ClienteBusiness(CoreBusiness core)
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

        public void AdicionarCliente(ClienteModel entidade)
        {
            try
            {
                _core.UnityOfWorkAdo.Clientes.Inserir(entidade);
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
                _core.UnityOfWorkAdo.Clientes.Alterar(entidade);
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
                BancoModel entidade = new BancoModel();
                entidade.Codigo = codigo;
                _core.UnityOfWorkAdo.Bancos.Excluir(entidade);
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
                var retorno = _core.UnityOfWorkAdo.Clientes.ListarTodos();

                return retorno;
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
                ClienteModel entidade = new ClienteModel();
                entidade.Id = id;

                var retorno = _core.UnityOfWorkAdo.Clientes.ListarPorId(entidade);

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
                ClienteModel entidade = new ClienteModel();
                entidade.Id = id;

                var retorno = _core.UnityOfWorkAdo.Clientes.ListarPorCpf(entidade);

                return retorno;
            }
            catch
            {
                throw;
            }
        }

    }
}
