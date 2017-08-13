using CampanhaBD.Business;
using CampanhaBD.Model;
using CampanhaBD.UI.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampanhaBD.UI.WEB.Controllers
{
    [Authorize]
    public class AtualizacaoController : BaseController
    {
        private readonly AtualizacaoBusiness _atuBus;

        public AtualizacaoController()
        {
            _atuBus = new AtualizacaoBusiness(_connectionString);
        }

        public ActionResult Index()
        {
            try
            {
                var listaConsultasProcessa = _atuBus.ListaConsultasProcessa();

                AtualizarViewModel viewModel = new AtualizarViewModel(listaConsultasProcessa);

                return View(viewModel);
            }
            catch(Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        [HttpPost]
        public ActionResult Index(AtualizarViewModel viewModel)
        {
            try
            {
                #region Atualizar Planilha
                if (BotoesViewModel.AtualizarPlanilha.Equals(viewModel.Submit))
                {
                    if (viewModel.File != null)
                    {
                        string caminho = Path.Combine(Server.MapPath("~/Content/Atualizados"), viewModel.File.FileName);
                        viewModel.File.SaveAs(caminho);

                        if (viewModel.LayoutArquivo == LayoutArquivoModel.CODIGO_PROCESSA)
                        {
                            _atuBus.AtualizarEmprestimosProcessaPlanilha(caminho);
                        }

                    }

                    return RedirectToAction("Index");
                }
                #endregion

                #region Atualizar Processa
                if (BotoesViewModel.AtualizarProcessa.Equals(viewModel.Submit))
                {
                    _atuBus.AtualizarEmprestimosProcessa(viewModel.ConsultaProcessa);

                    return RedirectToAction("Index");
                }
                #endregion

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

    }
}