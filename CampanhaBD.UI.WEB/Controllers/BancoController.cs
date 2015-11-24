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
        private readonly UnityOfWorkAdo _unityOfWork = new UnityOfWorkAdo();

        // GET: Banco
        public ActionResult Index()
        {
            return View(_unityOfWork.Bancos.ListarTodos());
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
                _unityOfWork.Bancos.Inserir(modelo.ParaBancoModel());
                return RedirectToAction("Index");
            }
            ViewBag.Mensagem = "Erro ao salvar usuario";
            return View();
        }

        public ActionResult Editar(int codigo)
        {
            var banco = _unityOfWork.Bancos.ListarPorId(codigo.ToString());

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
                _unityOfWork.Bancos.Alterar(modelo.ParaBancoModel());
                return RedirectToAction("Index");
            }
            ViewBag.Mensagem = "Erro ao salvar dados";
            return View(modelo);
        }

        public ActionResult Excluir(int codigo)
        {
            var banco = _unityOfWork.Bancos.ListarPorId(codigo.ToString());

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
            var modelo = _unityOfWork.Bancos.ListarPorId(codigo.ToString());
            _unityOfWork.Bancos.Excluir(modelo);
            return RedirectToAction("Index");
        }
    }
}