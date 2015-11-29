﻿using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;
using CampanhaBD.UI.WEB.ViewModel;
using System;
using CampanhaBD.UI.WEB.Models;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.IO;

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
            ViewBag.Bancos = new SelectList(_unityOfWork.Bancos.ListarTodos(), "Codigo", "Nome");

            ViewBag.Importacoes = new MultiSelectList(_unityOfWork.Importacoes.ListarTodos(), "Id", "Nome", null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(CampanhaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                modelo.UsuarioId = _unityOfWork.Usuarios.ListarPorLogin(User.Identity.Name).Id;
                Campanha cmp = modelo.ParaCampanhaModel();
                cmp.Importacoes.Add(_unityOfWork.Importacoes.ListarPorId(modelo.ImpId, modelo.UsuarioId));

                _unityOfWork.Campanhas.Inserir(cmp);
                return RedirectToAction("Index");
            }

            // ViewBag.Mensagem = "Erro ao salvar usuario";
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

        public FileResult Executar(int usuarioId, int camId)
        {  
            Campanha campanha = _unityOfWork.Campanhas.ListarPorId(camId.ToString(), usuarioId.ToString());
            string[] cabecalho = { "BENEFICIO", "CPF", "NOME", "DATA_NASC", "UF", "CIDADE", "BAIRRO", "CEP", "ENDERECO",
                "DDD", "TELEFONE", "PARC_CONTRATO", "SALDO", "INICIO_PAG", "BANCO", "VALOR_PARCELA" };
            string sql = sqlString(campanha);
            string caminho = Path.Combine(Server.MapPath("~/Content/Export"), campanha.Nome + ".csv");

            Context ctx = new Context();
            using (ManipuladorCsv.CsvFileWriter writer = new ManipuladorCsv.CsvFileWriter(caminho))
            {
                ManipuladorCsv.CsvRow row = new ManipuladorCsv.CsvRow();
                foreach (string c in cabecalho)
                {
                    row.Add(c);
                }
                writer.WriteRow(row);

                var reader = ctx.ExecutaComandoComRetorno(sql);
                while (reader.Read())
                {
                    row = new ManipuladorCsv.CsvRow();
                    for(int i = 0; i < cabecalho.Length; i++)
                    {
                        row.Add(reader[i].ToString());
                    }
                    writer.WriteRow(row);
                }
            }
            ctx.Dispose();

            return File(caminho, "text/CSV", campanha.Nome);
        }

        public String sqlString(Campanha File)
        {
            string sql_command = "SELECT distinct b.numero, c.CPF, p.nome, c.dataNasc, c.estado, c.cidade, c.bairro, c.cep, "
                + "c.logradouro, c.ddd, c.telefone, e.parcelasContrato, e.Saldo, e.inicioPag, e.ban_id, e.valorParcela "
                + "from Pessoa p, Cliente c, Emprestimo e, Beneficio b "
                + "where p.pessoa_id = c.pessoa_id and c.pessoa_id = e.pessoa_id and b.pessoa_id = c.pessoa_id ";
                
            if (File.MinParcela != 0)
            {
                sql_command += "and " + "'" + File.MinParcela + "'" + " <= e.valorParcela ";
            }

            if (File.MaxParcela != 0)
            {
                sql_command += "and " + "'" + File.MaxParcela + "'" + " >= e.valorParcela ";
            }

            if (File.MinParcelasPagas != 0)
            {
                sql_command += "and " + "'" + File.MinParcelasPagas + "'" + " <= e.parcelasPagas ";
            }

            if (File.MinParcelasPagas != 0)
            {
                sql_command += "and " + "'" + File.MaxParcelasPagas + "'" + " >= e.parcelasPagas ";
            }

            if (File.MinInicioPag != String.Empty)
            {
                sql_command += "and " + "'" + File.MinInicioPag + "'" + " <= e.inicioPag ";
            }

            if (File.MaxInicioPag != String.Empty)
            {
                sql_command += "and " + "'" + File.MaxInicioPag + "'" + " >= e.inicioPag ";
            }

            if (File.MinDataNascimento != DateTime.MinValue)
            {
                sql_command += "and " + "'" + File.MinDataNascimento + "'" + " <= c.dataNasc ";
            }

            if (File.MinCep != null)
            {
                sql_command += "and " + "'" + File.MinCep + "'" + " <= c.cep ";
            }

            if (File.MaxCep != null)
            {
                sql_command += "and " + "'" + File.MaxCep + "'" + " >= c.cep ";
            }

            if (File.CodigoBanco != 0)
            {
                sql_command += "and " + "'" + File.CodigoBanco + "'" + " = e.ban_id ";
            }

            return sql_command;
        }
    }
}