using CampanhaBD.Business;
using CampanhaBD.Model;
using CampanhaBD.UI.WEB.Models;
using CampanhaBD.UI.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampanhaBD.UI.WEB.Controllers
{
    [Authorize]
    public class BaseController : Controller, IDisposable
    {
        public readonly CoreBusiness _core = CoreBusiness.GetInstance(
            ConfigurationManager.ConnectionStrings["CampanhaBD"].ConnectionString);

        public BaseController()
        {
            _core.AbrirConexao();
        }

        public ActionResult Erro()
        {
            ViewBag.mensagem = TempData["mensagem"];
            return View();
        }

        void IDisposable.Dispose()
        {
            _core.FecharConexao();
        }
    }
}