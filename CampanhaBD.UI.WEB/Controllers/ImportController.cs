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

                //cliente.preencheCampo();

                cliente.ImportacaoId = model.ImpId; //Pegar Id da importação
                cliente.Nome = linhaSeparada[model.Nome];
                cliente.Classificacao = Cliente.CLIENTE;

                _unityOfWork.Clients.Inserir(cliente);
            }

            return View("Associar", model);
        }

        public int[] criaVetorValores(ImportacaoClienteViewModel model)
        {
            int[] vet = new int[16];
            vet[Cliente.INDICE_NOME] = model.Nome;
            vet[Cliente.INDICE_DATA_NASCIMENTO] = model.DataNascimento;
            vet[Cliente.INDICE_CPF] = model.Cpf;
            vet[Cliente.INDICE_DDD] = model.Ddd;
            vet[Cliente.INDICE_TELEFONE] = model.Telefone;
            vet[Cliente.INDICE_UF] = model.Uf;
            vet[Cliente.INDICE_CIDADE] = model.Cidade;
            vet[Cliente.INDICE_BAIRRO] = model.Bairro;
            vet[Cliente.INDICE_CEP] = model.Cep;
            vet[Cliente.INDICE_DIGITO_CPF] = model.Nome;
            vet[Cliente.INDICE_BANCO] = model.BancoId;
            vet[Cliente.INDICE_SALDO] = model.Saldo;
            vet[Cliente.INDICE_VALOR_PARCELA] = model.ValorParcela;
            vet[Cliente.INDICE_PARCELAS_NO_CONTRATO] = model.ParcelasNoContrato;
            vet[Cliente.INDICE_NOME] = model.Nome;
            vet[Cliente.INDICE_NOME] = model.Nome;
            return vet;
        }
    }
}