using CampanhaBD.UI.WEB.ViewModel;
using CampanhaBD.RepositoryADO;
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
        private readonly UnityOfWorkAdo _unityOfWork = new UnityOfWorkAdo();
        
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
            Hash hash = new Hash(SHA512.Create());
            Usuario usuario = _unityOfWork.Usuarios.ListarTodos().Where(x => x.Login == model.Login).FirstOrDefault();

            if (usuario != null)
            {
                if (hash.VerificarSenha(model.Senha, usuario.Senha))
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usuario.Login, DateTime.Now,
                        DateTime.Now.AddMinutes(30), false, null, FormsAuthentication.FormsCookiePath);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                        FormsAuthentication.Encrypt(ticket));

                    Response.Cookies.Add(cookie);
                    //FormsAuthentication.SetAuthCookie();
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Mensagem = "Login ou Senha inválido";
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(UsuarioViewModel usuario)
        {
            Hash hash = new Hash(SHA512.Create());
            if (ModelState.IsValid)
            {
                usuario.Senha = hash.CriptografarSenha(usuario.Senha);
                _unityOfWork.Usuarios.Inserir(usuario.ParaUsuarioModel());
                ViewBag.Mensagem = "Usuario registrado com sucesso!";
            }
            else
            {
                ViewBag.Mensagem = "Erro ao salvar usuario";
            }
            
            return View();
        }
    }
}