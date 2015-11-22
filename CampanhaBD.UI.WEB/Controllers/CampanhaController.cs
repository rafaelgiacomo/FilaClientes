using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;
using CampanhaBD.UI.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CampanhaBD.UI.WEB.Controllers
{
    [Authorize]
    public class CampanhaController : Controller
    {
        private readonly UnityOfWorkAdo _unityOfWork = new UnityOfWorkAdo();

        // GET: Campanha
        public ActionResult Index()
        {
            return View(new List<Campanha>());
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(CampanhaViewModel modelo)
        {
            return View();
        }
    }
}