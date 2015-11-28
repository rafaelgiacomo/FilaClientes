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
                Colunas = linhaSeparada,
                NumBeneficio = 1,
                Nome = 2,
                DataNascimento = 3,
                Cpf = 4,
                BancoId = 13,
                Saldo = 15,
                InicioPagamento = 16,
                ParcelasNoContrato = 17,
                ValorParcela = 18,
                Logradouro = 20,
                Bairro = 21,
                Cidade = 22,
                Uf = 23, 
                Cep = 24
            };

            stream.Close();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Associar(ImportacaoClienteViewModel model)
        {
            Importacao imp = _unityOfWork.Importacoes.ListarPorId(model.ImpId, model.UsuarioId);
            StreamReader stream = new StreamReader(imp.CaminhoArquivo);
            int[] valores = criaVetorValores(model);
            string[] linhaSeparada = null;

            string linha = stream.ReadLine(); //Le o cabeçalho
            while ((linha = stream.ReadLine()) != null)
            {
                linhaSeparada = linha.Split(';');
                Cliente cliente = new Cliente();

                cliente.ImportacaoId = model.ImpId; //Pegar Id da importação
                cliente.Classificacao = Cliente.CLIENTE;

                for (int i = 0; i < valores.Length; i++)
                {
                    if (valores[i] > -1)
                    {
                        cliente.preencheCampo(i, linhaSeparada[valores[i]]);
                    }
                }

                //_unityOfWork.Clients.Inserir(cliente);

            }

            stream.Close();
            _unityOfWork.Importacoes.Terminar(model.ImpId, model.UsuarioId);

            return View("Associar", model);
        }

        public int[] criaVetorValores(ImportacaoClienteViewModel model)
        {
            int[] vet = new int[16];
            vet[Cliente.INDICE_NOME] = model.Nome - 1;
            vet[Cliente.INDICE_DATA_NASCIMENTO] = model.DataNascimento - 1;
            vet[Cliente.INDICE_CPF] = model.Cpf - 1;
            vet[Cliente.INDICE_DDD] = model.Ddd - 1;
            vet[Cliente.INDICE_TELEFONE] = model.Telefone - 1;
            vet[Cliente.INDICE_UF] = model.Uf - 1;
            vet[Cliente.INDICE_CIDADE] = model.Cidade - 1;
            vet[Cliente.INDICE_BAIRRO] = model.Bairro - 1;
            vet[Cliente.INDICE_CEP] = model.Cep - 1;
            vet[Cliente.INDICE_DIGITO_CPF] = model.DigitoCpf - 1;
            vet[Cliente.INDICE_BANCO] = model.BancoId - 1;
            vet[Cliente.INDICE_SALDO] = model.Saldo - 1;
            vet[Cliente.INDICE_VALOR_PARCELA] = model.ValorParcela - 1;
            vet[Cliente.INDICE_PARCELAS_NO_CONTRATO] = model.ParcelasNoContrato - 1;
            vet[Cliente.INDICE_INICIO_PAGAMENTO] = model.InicioPagamento - 1;
            vet[Cliente.INDICE_BENEFICIO] = model.NumBeneficio - 1;
            return vet;
        }
    }
}