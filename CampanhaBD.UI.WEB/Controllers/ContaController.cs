using CampanhaBD.UI.WEB.ViewModel;
using System.Web.Mvc;
using CampanhaBD.RepositoryADO;
using CampanhaBD.Model;
using System.Security.Cryptography;

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