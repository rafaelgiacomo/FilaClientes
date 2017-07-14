using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Business
{
    public class BancoBusiness
    {
        private CoreBusiness _core;

        public BancoBusiness(CoreBusiness core)
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

        public void AdicionarBanco(BancoModel entidade)
        {
            try
            {
                _core.UnityOfWorkAdo.Bancos.Inserir(entidade);
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
                _core.UnityOfWorkAdo.Bancos.Alterar(entidade);
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
                BancoModel entidade = new BancoModel();
                entidade.Codigo = codigo;
                _core.UnityOfWorkAdo.Bancos.Excluir(entidade);
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
                var retorno = _core.UnityOfWorkAdo.Bancos.ListarTodos();

                return retorno;
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
                BancoModel entidade = new BancoModel();
                entidade.Codigo = codigo;

                var retorno = _core.UnityOfWorkAdo.Bancos.ListarPorId(entidade);

                return retorno;
            }
            catch
            {
                throw;
            }
        }

    }
}
