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
            ViewBag.UsuarioID = _unityOfWork.Usuarios.ListarPorLogin(User.Identity.Name).Id;
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

        public ActionResult Detalhes(int usuarioId, int camId)
        {
            Campanha campanha = _unityOfWork.Campanhas.ListarPorId(camId.ToString(), usuarioId.ToString());
            ViewBag.UsuarioID = _unityOfWork.Usuarios.ListarPorLogin(User.Identity.Name).Id;
            return View(campanha);
        }

        [HttpGet]
        public ActionResult Excluir(int usuarioId, int camId)
        {
            Campanha campanha = _unityOfWork.Campanhas.ListarPorId(camId.ToString(), usuarioId.ToString());

            if (campanha == null)
            {
                return HttpNotFound();
            }

            return View(campanha);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int usuarioId, int camId)
        {
            Campanha campanha = _unityOfWork.Campanhas.ListarPorId(camId.ToString(), usuarioId.ToString());
            _unityOfWork.Campanhas.Excluir(campanha);
            ViewBag.Message = "Campanha \"" + campanha.Nome + "\" removida.";
            return RedirectToAction("Index");
        }
    }
}