using CampanhaBD.Business;
using CampanhaBD.Model;
using CampanhaBD.UI.WEB.ViewModel;
using System;
using System.IO;
using System.Web.Mvc;

namespace CampanhaBD.UI.WEB.Controllers
{
    [Authorize]
    public class ExportacaoController : BaseController
    {
        private readonly BancoBusiness _bancoBus;
        private readonly ExportacaoBusiness _expBus;

        public ExportacaoController()
        {
            _bancoBus = new BancoBusiness(_core);
            _expBus = new ExportacaoBusiness(_core);
        }

        public ActionResult Index()
        {
            try
            {
                var listaBancos = _bancoBus.ListarTodos();

                ExportacaoViewModel viewModel = new ExportacaoViewModel(listaBancos);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ExportacaoViewModel viewModel)
        {
            try
            {
                CampanhaModel campanha = viewModel.ViewModelParaCampanha();

                #region Exportar Planilha
                if (BotoesExportacaoViewModel.ExportarPlanilha.Equals(viewModel.Submit))
                {
                    string caminho = Path.Combine(Server.MapPath("~/Content/Exportados"), "Exportacao" + ".csv");

                    if (viewModel.LayoutArquivo == LayoutArquivoModel.CODIGO_PROCESSA)
                    {
                        _expBus.ExportarPlanilhaProcessa(campanha, caminho);
                    }
                    return File(caminho, "text/CSV", "Teste.csv");
                }
                #endregion

                #region Exportar Processa
                if (BotoesExportacaoViewModel.ExportarProcessa.Equals(viewModel.Submit))
                {
                    _expBus.ExportarProcessa(campanha);
                    return View(viewModel);
                }
                #endregion

                return RedirectToAction("Erro");                
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

    }
}