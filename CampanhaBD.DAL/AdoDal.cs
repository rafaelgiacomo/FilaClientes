using System.Linq.Expressions;
using CampanhaBD.RepositoryADO;

namespace CampanhaBD.DAL
{
    public class AdoDal
    {
        private readonly UnityOfWorkAdo _unityOfWork = new UnityOfWorkAdo();
    }
}
