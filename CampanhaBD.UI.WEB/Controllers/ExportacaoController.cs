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
        private readonly ImportacaoBusiness _impBus;

        public ExportacaoController()
        {
            _bancoBus = new BancoBusiness(_connectionString);
            _expBus = new ExportacaoBusiness(_connectionString);
            _impBus = new ImportacaoBusiness(_connectionString);
        }

        public ActionResult Index()
        {
            try
            {
                var listaBancos = _bancoBus.ListarTodos();
                var listaImportacoes = _impBus.ListarTodos();

                listaImportacoes.Add(new ImportacaoModel() { Id = 0, Nome = "" } );

                ExportacaoViewModel viewModel = new ExportacaoViewModel(listaBancos, listaImportacoes);

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
                FiltroModel campanha = viewModel.ViewModelParaCampanha();

                #region Exportar Planilha
                if (BotoesViewModel.ExportarPlanilha.Equals(viewModel.Submit))
                {
                    string caminho = Path.Combine(Server.MapPath("~/Content/Exportados"), viewModel.Nome + ".csv");

                    if (viewModel.LayoutArquivo == LayoutArquivoModel.CODIGO_PROCESSA)
                    {
                        _expBus.ExportarPlanilhaProcessa(campanha, caminho);
                    }

                    if (viewModel.LayoutArquivo == LayoutArquivoModel.CODIGO_PANORAMA)
                    {
                        _expBus.ExportarPlanilhaPanorama(campanha, caminho);
                    }

                    if (viewModel.LayoutArquivo == LayoutArquivoModel.CODIGO_TELEFONE)
                    {
                        _expBus.ExportarPlanilhaTelefone(campanha, caminho);
                    }

                    return File(caminho, "text/CSV", viewModel.Nome + ".csv");
                }
                #endregion

                #region Ver Filtro
                if (BotoesViewModel.VerFiltro.Equals(viewModel.Submit))
                {
                    string caminho = Path.Combine(Server.MapPath("~/Content/Filtros"), viewModel.Nome + ".csv");

                    _expBus.ExportarPlanilhaFiltro(campanha, caminho);

                    return File(caminho, "text/CSV", viewModel.Nome + ".csv");
                }
                #endregion

                #region Exportar Processa
                if (BotoesViewModel.ExportarProcessa.Equals(viewModel.Submit))
                {
                    _expBus.ExportarProcessa(campanha);

                    return RedirectToAction("Index");
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