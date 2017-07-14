using CampanhaBD.Business;
using CampanhaBD.Model;
using CampanhaBD.UI.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampanhaBD.UI.WEB.Controllers
{
    [Authorize]
    public class ExportacaoController : BaseController
    {
        public ExportacaoController()
        {

        }

        public ActionResult Index()
        {
            try
            {
                ExportacaoViewModel viewModel = new ExportacaoViewModel();
                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

    }
}