using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Interface
{
    public interface IRepository<T> where T : class
    {
        void Inserir(T entidade);

        void Alterar(T entidade);

        void Excluir(T entidade);

        IEnumerable<T> ListarTodos();

        T ListarPorId(string id);
    }
}

