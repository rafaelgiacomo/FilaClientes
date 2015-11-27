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
            Campanha camp = new Campanha();
            camp.ApenasNaoExportados = true;
            camp.CodigoBanco = 707;
            camp.Id = 12;
            camp.MaxCep = "10000000";
            camp.MaxInicioPag = null;
            camp.MaxParcela = 180;
            camp.MaxParcelasPagas = 40;
            camp.MinCep = "99999999";
            camp.MinDataNascimento = DateTime.Parse("01/01/1900");
            camp.MinInicioPag = "01/01/1900";
            camp.MinParcela = 10;
            camp.MinParcelasPagas = 10;
            camp.Nome = "Zé";
            string teste = sqlString(camp);
           
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

        public String sqlString(Campanha File)
        {
            string sql_command = "SELECT * FROM Cliente c, Emprestimo e WHERE c.pessoa_id = e.pessoa_id and e.saldo > 0 and " + "'" + File.ApenasNaoExportados+"'" + " = c.trabalhado ";
            if (File.MinParcela != 0)
            {
                sql_command = sql_command + "and " +"'" + File.MinParcela + "'" + " < e.parcelasContrato ";
            }

            if (File.MaxParcela != 0)
            {
                sql_command = sql_command + "and " + "'" + File.MinParcela + "'" + " > e.parcelasContrato ";
            }

            if (File.MinParcelasPagas != 0)
            {
                sql_command = sql_command + "and " + "'" + File.MinParcela + "'" + " < e.parcelasPagas ";
            }

            if (File.MinParcelasPagas != 0)
            {
                sql_command = sql_command + "and " + "'" + File.MaxParcela + "'" + " > e.parcelasPagas ";
            }

            if (File.MinInicioPag != null)
            {
                sql_command = sql_command + "and " + "'" + File.MinInicioPag + "'" + " < e.inicioPag ";
            }

            if (File.MaxInicioPag != null)
            {
                sql_command = sql_command + "and " + "'" + File.MaxInicioPag + "'" + " > e.inicioPag ";
            }

            if (File.MinDataNascimento != null)
            {
                sql_command = sql_command + "and " + "'" + File.MinDataNascimento + "'" + " < c.dataNasc ";
            }

            if (File.MinCep != null)
            {
                sql_command = sql_command + "and " + "'" + File.MinCep + "'" + " < c.cep ";
            }

            if (File.MaxCep != null)
            {
                sql_command = sql_command + "and " + "'" + File.MaxCep + "'" + " > c.cep ";
            }

            if (File.CodigoBanco != 0)
            {
                sql_command = sql_command + "and " + "'" + File.CodigoBanco + "'" + " = e.ban_id ";
            }
            return sql_command;
        }
    }
}