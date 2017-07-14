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
    public class AtualizacaoController : BaseController
    {

        public AtualizacaoController()
        {
        }

        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }
    }
}