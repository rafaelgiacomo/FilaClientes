using CampanhaBD.UI.WEB.ViewModel;
using CampanhaBD.Model;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CampanhaBD.UI.WEB.Controllers
{
    public class ContaController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            //Hash hash = new Hash(SHA512.Create());
            //UsuarioModel usuario = _unityOfWork.Usuarios.ListarTodos().Where(x => x.Login == model.Login).FirstOrDefault();

            //if (usuario != null)
            //{
            //    if (hash.VerificarSenha(model.Senha, usuario.Senha))
            //    {
                    FormsAuthentication.SetAuthCookie(model.Login, false);
                    return RedirectToAction("Index", "Importacao");
            //    }
            //}
            //ViewBag.Mensagem = "Login ou Senha inválido";
            //return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(UsuarioViewModel usuario)
        {
            //Hash hash = new Hash(SHA512.Create());
            //if (ModelState.IsValid)
            //{
            //    usuario.Senha = hash.CriptografarSenha(usuario.Senha);
            //    _unityOfWork.Usuarios.Inserir(usuario.ParaUsuarioModel());
            //    ViewBag.Mensagem = "Usuario registrado com sucesso!";
            //    return RedirectToAction("LogIn");
            //}
            //else
            //{
            //    ViewBag.Mensagem = "Erro ao salvar usuario";
            //}
            
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}