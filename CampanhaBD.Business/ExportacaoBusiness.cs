using CampanhaBD.Model;
using CampanhaBD.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Business
{
    public class ExportacaoBusiness
    {
        private CoreBusiness _core;

        public ExportacaoBusiness(CoreBusiness core)
        {
            try
            {
                _core = core;
            }
            catch
            {
                throw;
            }
        }

        public void ExportarPlanilhaProcessa(CampanhaModel campanha, string caminho)
        {
            try
            {
                List<ClienteModel> lista = _core.UnityOfWorkAdo.Campanhas.ExportarFiltro(campanha);
                string[] cabecalho = { "BENEFICIO", "DATA_NASCIMENTO", "CPF", "NOME", "ESPECIE", "UF", "IDENTFICACAO_CLIENTE",
                "STATUS", "OK" };

                using (ManipuladorCsv.CsvFileWriter writer = new ManipuladorCsv.CsvFileWriter(caminho))
                {
                    ManipuladorCsv.CsvRow row = new ManipuladorCsv.CsvRow();
                    foreach (string c in cabecalho)
                    {
                        row.Add(c);
                    }
                    writer.WriteRow(row);

                    foreach (ClienteModel cl in lista)
                    {
                        row = new ManipuladorCsv.CsvRow();

                        row.Add(cl.Beneficios[0].Numero.ToString());
                        row.Add(cl.DataNascimento.ToString());
                        row.Add(cl.Cpf);
                        row.Add(cl.Nome);
                        row.Add("");
                        row.Add(cl.Uf);
                        row.Add("");
                        row.Add("");
                        row.Add("");

                        writer.WriteRow(row);
                    }

                    writer.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ExportarProcessa(CampanhaModel campanha)
        {
            try
            {
                List<ClienteModel> lista = _core.UnityOfWorkAdo.Campanhas.ExportarFiltro(campanha);


            }
            catch
            {
                throw;
            }
        }

    }
}
