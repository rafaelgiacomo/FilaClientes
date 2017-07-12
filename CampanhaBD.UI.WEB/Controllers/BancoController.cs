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
    public class BancoController : Controller
    {

        // GET: Banco
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(BancoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Mensagem = "Erro ao salvar usuario";
            return View();
        }

        public ActionResult Editar(int codigo)
        {
            var banco = new BancoModel();

            if (banco == null)
            {
                return HttpNotFound();
            }

            BancoViewModel bvm = new BancoViewModel();
            bvm.ParaViewModel(banco);

            return View(bvm);
        }

        [HttpPost]
        public ActionResult Editar(BancoViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Mensagem = "Erro ao salvar dados";
            return View(modelo);
        }

        public ActionResult Excluir(int codigo)
        {
            var banco = new BancoModel();

            if (banco == null)
            {
                return HttpNotFound();
            }

            return View(banco);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int codigo)
        {
            return RedirectToAction("Index");
        }
    }
}