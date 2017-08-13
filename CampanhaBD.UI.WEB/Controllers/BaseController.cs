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
        public readonly string _connectionString = ConfigurationManager.ConnectionStrings["CampanhaBD"].ConnectionString;

        public BaseController()
        {
        }

        public ActionResult Erro()
        {
            ViewBag.mensagem = TempData["mensagem"];
            return View();
        }

        void IDisposable.Dispose()
        {
        }
    }
}