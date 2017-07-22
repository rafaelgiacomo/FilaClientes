using CampanhaBD.UI.WEB.ViewModel;
using System;
using System.Web.Mvc;
using CampanhaBD.Model;
using System.IO;
using CampanhaBD.Business;
using System.Collections.Generic;

namespace CampanhaBD.UI.WEB.Controllers
{

    [Authorize]
    public class ImportacaoController : BaseController
    {
        private readonly ImportacaoBusiness _impBus;

        public ImportacaoController()
        {
            _impBus = new ImportacaoBusiness(_core);
        }

        public ActionResult Index()
        {
            try
            {
                List<ImportacaoModel> lista = _impBus.ListarTodos();
                return View(lista);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        public ActionResult Importar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Importar(ImportarViewModel viewModel)
        {
            try
            {
                if (viewModel.File != null)
                {
                    string caminho = Path.Combine(Server.MapPath("~/Content/Importados"), viewModel.File.FileName);
                    viewModel.File.SaveAs(caminho);

                    ImportacaoModel imp = new ImportacaoModel();
                    imp.UsuarioId = 1;
                    imp.Nome = viewModel.Nome;
                    imp.Data = DateTime.Now;
                    imp.Terminado = false;
                    imp.NumImportados = 0;
                    imp.NumAtualizados = 0;
                    imp.CaminhoArquivo = caminho;

                    _impBus.AdicionarImportacao(imp);

                    return RedirectToAction("Associar", new { impId = imp.Id });
                }
                else
                {
                    ViewBag.Mensagem = "Adicione uma planilha para importação";
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        public ActionResult Associar(int impId)
        {
            try
            {
                ImportacaoModel imp = _impBus.ListarPorId(impId);
                StreamReader stream = new StreamReader(imp.CaminhoArquivo);
                string[] linhaSeparada = null;

                //Le colunas do csv
                string linha = null;
                if ((linha = stream.ReadLine()) != null)
                {
                    linhaSeparada = linha.Split(';');
                }

                ImportacaoClienteViewModel viewModel = new ImportacaoClienteViewModel();
                viewModel.UsuarioId = imp.UsuarioId;
                viewModel.ImpId = impId;
                viewModel.Colunas = linhaSeparada;

                stream.Close();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        [HttpPost]
        public ActionResult Associar(ImportacaoClienteViewModel model)
        {
            try
            {
                ImportacaoModel imp = _impBus.ListarPorId(model.ImpId);

                _impBus.ImportarClientes(imp, criaVetorValores(model));

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        public int[] criaVetorValores(ImportacaoClienteViewModel model)
        {
            try
            {
                int[] vet = new int[19];
                vet[ClienteModel.INDICE_NOME] = model.Nome - 1;
                vet[ClienteModel.INDICE_DATA_NASCIMENTO] = model.DataNascimento - 1;
                vet[ClienteModel.INDICE_CPF] = model.Cpf - 1;
                vet[ClienteModel.INDICE_DDD] = model.Ddd - 1;
                vet[ClienteModel.INDICE_TELEFONE] = model.Telefone - 1;
                vet[ClienteModel.INDICE_UF] = model.Uf - 1;
                vet[ClienteModel.INDICE_CIDADE] = model.Cidade - 1;
                vet[ClienteModel.INDICE_BAIRRO] = model.Bairro - 1;
                vet[ClienteModel.INDICE_CEP] = model.Cep - 1;
                vet[ClienteModel.INDICE_DIGITO_CPF] = model.DigitoCpf - 1;
                vet[ClienteModel.INDICE_BANCO] = model.BancoId - 1;
                vet[ClienteModel.INDICE_SALDO] = model.Saldo - 1;
                vet[ClienteModel.INDICE_VALOR_PARCELA] = model.ValorParcela - 1;
                vet[ClienteModel.INDICE_PARCELAS_NO_CONTRATO] = model.ParcelasNoContrato - 1;
                vet[ClienteModel.INDICE_INICIO_PAGAMENTO] = model.InicioPagamento - 1;
                vet[ClienteModel.INDICE_BENEFICIO] = model.NumBeneficio - 1;
                vet[ClienteModel.INDICE_LOGRADOURO] = model.Logradouro - 1;
                vet[ClienteModel.INDICE_VALOR_BENEFICIO] = model.ValorBeneficio - 1;
                vet[ClienteModel.INDICE_COMPLEMENTO] = model.Complemento - 1;
                return vet;
            }
            catch
            {
                throw;
            }
        }

    }
}