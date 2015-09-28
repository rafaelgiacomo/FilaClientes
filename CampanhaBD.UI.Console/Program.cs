using System.Collections.Generic;
using System.Linq;
using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;

namespace CampanhaBD.UI.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Com o padrão unidade de trabalho, minimiza-se o risco de problemas de concorrência, mantendo uma unica
            //instância do contexto da conexão
            UnityOfWorkAdo unityOfWork = new UnityOfWorkAdo();

            //Método que gera uma lista de Clientes a serem inseridos no banco de dados
            var clientsList = GenerateClientsList();

            //Adicionando os clientes no banco de dados
            System.Console.WriteLine("Adicionando Clientes...");
            foreach (var clie in clientsList)
            {
                unityOfWork.Clients.Inserir(clie);
            }

            //Listando clientes cadastrados
            clientsList = unityOfWork.Clients.ListarTodos().ToList();
            ListClients("Clientes Cadastrados", clientsList);

            //Alterando o telefone do Segundo objeto da lista
            System.Console.WriteLine();
            System.Console.WriteLine("Alterando telefone do Cliente Rafael");
            clientsList.ElementAt(1).Telefone = "29638367";
            unityOfWork.Clients.Alterar(clientsList.ElementAt(1));

            //Listando Clientes apos alteração de um dos registros
            clientsList = unityOfWork.Clients.ListarTodos().ToList();
            ListClients("Clientes cadastrados depois de alteração de registros", clientsList);

            //Excluindo o ultimo registro da lista
            System.Console.WriteLine();
            System.Console.WriteLine("Excluindo o Cliente Rubens");
            unityOfWork.Clients.Excluir(clientsList.ElementAt(3));
            clientsList.RemoveAt(3);

            //Listando Clientes apos exclusao
            clientsList = unityOfWork.Clients.ListarTodos().ToList();
            ListClients("clientes cadastrados depois de exclusão de registros", clientsList);

            //Efetuando o Commit no banco de dados
            //unityOfWork.Commit();

            System.Console.ReadKey();
        }

        private static void ListClients(string titulo, List<ClientModel> list)
        {
            System.Console.WriteLine();
            System.Console.WriteLine(titulo);
            System.Console.WriteLine("---------------------");
            foreach (var client in list)
            {
                System.Console.WriteLine(
                    string.Format("{0}, {1}, {2}, {3}", client.Cpf, client.Nome, client.Ddd, client.Telefone));
            }
        }

        //Preenchendo uma lista com diversos Clientes
        private static List<ClientModel> GenerateClientsList()
        {
            var clientsList = new List<ClientModel>()
            {
                new ClientModel()
                {
                    Nome = "Bruno Feiteiro",
                    Cpf = "37646598700",
                    Ddd = "11",
                    Telefone = "9937350237"
                },
                new ClientModel()
                {
                    Nome = "Rafael Rodrigues Giacomo",
                    Cpf = "42422443800",
                    Ddd = "11",
                    Telefone = "981002906"
                },
                new ClientModel()
                {
                    Nome = "Thiago Mayllart",
                    Cpf = "93475649476",
                    Ddd = "11",
                    Telefone = "3085464203"
                },
                new ClientModel()
                {
                    Nome = "Rubens",
                    Cpf = "20446544763",
                    Ddd = "11",
                    Telefone = "094743856"
                }
            };
            return clientsList;
        }

    }
}
