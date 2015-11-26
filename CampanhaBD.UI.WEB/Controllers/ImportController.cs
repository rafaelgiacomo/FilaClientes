﻿using CampanhaBD.UI.WEB.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using CampanhaBD.Model;
using CampanhaBD.UI.WEB.Models;
using CampanhaBD.RepositoryADO;
using System.IO;
using Excel;

namespace CampanhaBD.UI.WEB.Controllers
{

    [Authorize]
    public class ImportController : Controller
    {
        private readonly UnityOfWorkAdo _unityOfWork = new UnityOfWorkAdo();

        // GET: Import
        public ActionResult Index()
        {
            return View(_unityOfWork.Importacoes.ListarTodos());
        }

        public ActionResult Importar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Importar(ImportarViewModel viewModel)
        {
            if (viewModel.File != null)
            {
                string caminho = Path.Combine(Server.MapPath("~/Content/Uploads"), viewModel.File.FileName);
                viewModel.File.SaveAs(caminho);

                Importacao imp = new Importacao()
                {
                    Nome = viewModel.Nome,
                    Data = DateTime.Now,
                    Terminado = false,
                    NumImportados = 0,
                    NumAtualizados = 0
                };

                _unityOfWork.Importacoes.Inserir(imp);
                
                return RedirectToAction("Associar", new { caminho = caminho });
            }
            else
            {
                ViewBag.Mensagem = "Adicione uma planilha para importação";
            }
            return View();
        }

        public ActionResult Associar(string caminho)
        {
            StreamReader stream = new StreamReader(caminho);
            string[] linhaSeparada = null;

            string linha = null;
            if((linha = stream.ReadLine()) != null)
            {
                linhaSeparada = linha.Split(';');
            }

            ImportacaoClienteViewModel viewModel = new ImportacaoClienteViewModel()
            {
                Colunas = linhaSeparada,
                CaminhoArquivo = caminho
            };

            stream.Close();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Associar(ImportacaoClienteViewModel model)
        {
            /*model.clientes = new List<Cliente>();
            if (File != null && File.ContentLength > 0)
            {
                Stream stream = File.InputStream;

                IExcelDataReader reader = null;

                if (File.FileName.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (File.FileName.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                reader.IsFirstRowAsColumnNames = true;
                DataSet result = reader.AsDataSet();
                int linhas = result.Tables[0].Columns.Count;
                int i = 1;
                while (i < linhas)
                {
                    Cliente cli = new Cliente();
                    cli.Nome = (string)result.Tables[0].Rows[i][model.Nome];
                    cli.Cpf = (string)result.Tables[0].Rows[i][model.Cpf];
                    cli.Uf = (string)result.Tables[0].Rows[i][model.Uf];
                    cli.Cidade = (string)result.Tables[0].Rows[i][model.Cidade];
                    cli.Bairro = (string)result.Tables[0].Rows[i][model.Bairro];
                    cli.Ddd = (string)result.Tables[0].Rows[i][model.Ddd];
                    cli.DataNascimento = (System.DateTime)result.Tables[0].Rows[i][model.DataNascimento];
                    cli.Logradouro = (string)result.Tables[0].Rows[i][model.Logradouro];
                    cli.Numero = (string)result.Tables[0].Rows[i][model.Numero];
                    cli.Cep = (string)result.Tables[0].Rows[i][model.Cep];
                    i++;
                    _unityOfWork.Clients.Inserir(cli);
                }
            }*/
            return View("Associar", model);
        }

            /*public ActionResult Importar(HttpPostedFileBase file)
            {
                DataSet ds = new DataSet();
                if (Request.Files["file"].ContentLength > 0)
                {
                    string fileExtension =
                                         System.IO.Path.GetExtension(Request.Files["file"].FileName);

                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {

                            System.IO.File.Delete(fileLocation);
                        }
                        Request.Files["file"].SaveAs(fileLocation);
                        string excelConnectionString = string.Empty;
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        //connection String for xls file format.
                        if (fileExtension == ".xls")
                        {
                            excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                            fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                        }
                        //connection String for xlsx file format.
                        else if (fileExtension == ".xlsx")
                        {
                            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                        }
                        //Create Connection to Excel work book and add oledb namespace
                        OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                        excelConnection.Open();
                        DataTable dt = new DataTable();

                        dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        if (dt == null)
                        {
                            return null;
                        }

                        String[] excelSheets = new String[dt.Rows.Count];
                        int t = 0;
                        //excel data saves in temp file here.
                        foreach (DataRow row in dt.Rows)
                        {
                            excelSheets[t] = row["TABLE_NAME"].ToString();
                            t++;
                        }
                        OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                        string query = string.Format("Select * from [{0}]", excelSheets[0]);
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                        {
                            dataAdapter.Fill(ds);
                        }
                    }
                    if (fileExtension.ToString().ToLower().Equals(".xml"))
                    {
                        string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                        if (System.IO.File.Exists(fileLocation))
                        {
                            System.IO.File.Delete(fileLocation);
                        }

                        Request.Files["FileUpload"].SaveAs(fileLocation);
                        XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                        // DataSet ds = new DataSet();
                        ds.ReadXml(xmlreader);
                        xmlreader.Close();
                    }

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string conn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                        SqlConnection con = new SqlConnection(conn);
                        string query = "Insert into Person(Name,Email,Mobile) Values('" +
                        ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() +
                        "','" + ds.Tables[0].Rows[i][2].ToString() + "')";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return View();
            }*/
        }
    }