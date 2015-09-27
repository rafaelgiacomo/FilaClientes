using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;

namespace CampanhaBD.UI.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnityOfWorkAdo unityOfWork = new UnityOfWorkAdo();

            System.Console.WriteLine("Adicionando Cliente...");
            var client = new ClientModel()
            {
                Nome = "Rafael Rodrigues Giacomo",
                Cpf = "42422443800",
                Ddd = "11",
                Telefone = "981002906"
            };

            foreach (var clie in unityOfWork.Clients.ListarTodos())
            {
                System.Console.WriteLine(string.Format("{0} - {1}", clie.Cpf, clie.Nome));
            }

            unityOfWork.Clients.Inserir(client);
            //unityOfWork.Commit();
        }
    }
}
