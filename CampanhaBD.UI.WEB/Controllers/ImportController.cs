using CampanhaBD.UI.WEB.ViewModel;
using System;
using System.Web.Mvc;
using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;
using System.IO;

namespace CampanhaBD.UI.WEB.Controllers
{

    [Authorize]
    public class ImportController : Controller
    {
        private readonly UnityOfWorkAdo _unityOfWork = new UnityOfWorkAdo();

        // GET: Import
        public ActionResult Index()
        {
            return View(_unityOfWork.Importacoes.ListarTodos());
        }

        public ActionResult Importar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Importar(ImportarViewModel viewModel)
        {
            if (viewModel.File != null)
            {
                string caminho = Path.Combine(Server.MapPath("~/Content/Uploads"), viewModel.File.FileName);
                viewModel.File.SaveAs(caminho);

                Importacao imp = new Importacao()
                {
                    UsuarioId = _unityOfWork.Usuarios.ListarPorLogin(User.Identity.Name).Id,
                    Nome = viewModel.Nome,
                    Data = DateTime.Now,
                    Terminado = false,
                    NumImportados = 0,
                    NumAtualizados = 0,
                    CaminhoArquivo = caminho
                };

                _unityOfWork.Importacoes.Inserir(imp);

                return RedirectToAction("Associar", new { impId = imp.Id, usuarioId = imp.UsuarioId });
            }
            else
            {
                ViewBag.Mensagem = "Adicione uma planilha para importação";
            }
            return View();
        }

        public ActionResult Associar(int impId, int usuarioId)
        {
            Importacao imp = _unityOfWork.Importacoes.ListarPorId(impId, usuarioId);
            StreamReader stream = new StreamReader(imp.CaminhoArquivo);
            string[] linhaSeparada = null;

            string linha = null;
            if ((linha = stream.ReadLine()) != null)
            {
                linhaSeparada = linha.Split(';');
            }

            ImportacaoClienteViewModel viewModel = new ImportacaoClienteViewModel()
            {
                UsuarioId = usuarioId,
                ImpId = impId,
                Colunas = linhaSeparada
            };

            stream.Close();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Associar(ImportacaoClienteViewModel model)
        {
            Importacao imp = _unityOfWork.Importacoes.ListarPorId(model.ImpId, model.UsuarioId);
            StreamReader stream = new StreamReader(imp.CaminhoArquivo);
            string[] linhaSeparada = null;

            string linha = stream.ReadLine(); //Le o cabeçalho
            while ((linha = stream.ReadLine()) != null)
            {
                Cliente cliente = new Cliente();

                cliente.ImportacaoId = model.ImpId; //Pegar Id da importação
                cliente.Nome = linhaSeparada[model.Nome];
                cliente.Classificacao = Cliente.CLIENTE;

                _unityOfWork.Clients.Inserir(cliente);
            }

            return View("Associar", model);
        }

        public int[] criaVetorValores(ImportacaoClienteViewModel model)
        {
            int[] vet = new int[11];

            

            return vet;
        }
    }
}