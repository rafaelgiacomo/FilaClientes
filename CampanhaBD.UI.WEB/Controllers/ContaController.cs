using CampanhaBD.UI.WEB.ViewModel;
using System.Web.Mvc;
using CampanhaBD.RepositoryADO;

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
            if (ModelState.IsValid)
            {
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