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
                List<ClienteModel> lista = _core.UnityOfWorkAdo.Campanhas.ExportarProcessaFiltro(campanha);
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
                List<ClienteModel> listaClientes = _core.UnityOfWorkAdo.Campanhas.ExportarProcessaFiltro(campanha);

                ConsultaProcessaModel consultaProcessa = new ConsultaProcessaModel();
                consultaProcessa.Descricao = campanha.Nome;

                _core.UnityOfWorkAdo.ConsultasProcessa.InserirConsulta(consultaProcessa);

                foreach (ClienteModel cl in listaClientes)
                {
                    ConsultaDadosProcessaModel dados = new ConsultaDadosProcessaModel();

                    dados.Consulta = consultaProcessa.Consulta;
                    dados.Beneficio = cl.Beneficios[0].Numero.ToString();
                    dados.DataNascimento = cl.DataNascimento;
                    dados.Cpf = cl.Cpf;
                    dados.Nome = cl.Nome;

                    _core.UnityOfWorkAdo.ConsultasDadosProcessa.InserirConsultaDados(dados);
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
