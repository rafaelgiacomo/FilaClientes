using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;
using CampanhaBD.UI.WEB.ViewModel;
using Microsoft.AspNet.Identity;
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

        // GET: Banco
        public ActionResult Index()
        {
            return View(_unityOfWork.Campanhas.ListarTodos());
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(CampanhaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                _unityOfWork.Campanhas.Inserir(modelo.ParaCampanhaModel());
                return RedirectToAction("Index");
            }

            ViewBag.Mensagem = "Erro ao salvar usuario";
            return View();
        }

        public ActionResult Editar(int usuarioId, int camId)
        {
            var banco = _unityOfWork.Campanhas.ListarPorId(usuarioId.ToString(), camId.ToString());

            if (banco == null)
            {
                return HttpNotFound();
            }

            CampanhaViewModel bvm = new CampanhaViewModel();
            bvm.ParaViewModel(banco);

            return View(bvm);
        }

        [HttpPost]
        public ActionResult Editar(CampanhaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                _unityOfWork.Campanhas.Alterar(modelo.ParaCampanhaModel());
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