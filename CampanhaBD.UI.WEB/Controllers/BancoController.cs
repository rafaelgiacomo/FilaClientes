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
    public class BancoController : BaseController
    {
        private readonly BancoBusiness _bancoBus;

        public BancoController()
        {
            _bancoBus = new BancoBusiness(_core);
        }

        // GET: Banco
        public ActionResult Index()
        {
            try
            {
                var listaBancos = _bancoBus.ListarTodos();

                return View(listaBancos);
            }
            catch(Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(BancoViewModel modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BancoModel entidade = modelo.ParaBancoModel();

                    _bancoBus.AdicionarBanco(entidade);

                    return RedirectToAction("Index");
                }
                ViewBag.Mensagem = "Erro ao salvar banco";
                return View();
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        public ActionResult Editar(int codigo)
        {
            try
            {
                var banco = _bancoBus.ListarPorCodigo(codigo);

                if (banco == null)
                {
                    return HttpNotFound();
                }

                BancoViewModel bvm = new BancoViewModel();
                bvm.ParaViewModel(banco);

                return View(bvm);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        [HttpPost]
        public ActionResult Editar(BancoViewModel modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bancoBus.AlterarBanco(modelo.ParaBancoModel());
                    return RedirectToAction("Index");
                }
                ViewBag.Mensagem = "Erro ao salvar dados";
                return View(modelo);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

        public ActionResult Excluir(int codigo)
        {
            try
            {
                var banco = _bancoBus.ListarPorCodigo(codigo);

                if (banco == null)
                {
                    return HttpNotFound();
                }

                return View(banco);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
            
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int codigo)
        {
            try
            {
                var banco = _bancoBus.ListarPorCodigo(codigo);

                if (banco == null)
                {
                    return HttpNotFound();
                }

                _bancoBus.ExcluirBanco(codigo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = ex.Message;
                return RedirectToAction("Erro");
            }
        }

    }
}