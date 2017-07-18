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
            _atuBus = new AtualizacaoBusiness(_core);
        }

        public ActionResult Index()
        {
            try
            {
                AtualizarViewModel viewModel = new AtualizarViewModel();

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
                if (viewModel.File != null)
                {
                    string caminho = Path.Combine(Server.MapPath("~/Content/Atualizados"), viewModel.File.FileName);
                    viewModel.File.SaveAs(caminho);

                    if (viewModel.LayoutArquivo == LayoutArquivoModel.CODIGO_PROCESSA)
                    {
                        _atuBus.AtualizarEmprestimos(caminho);
                    }

                    return View();
                }
                else
                {
                    ViewBag.Mensagem = "Adicione uma planilha para atualização";
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

    }
}