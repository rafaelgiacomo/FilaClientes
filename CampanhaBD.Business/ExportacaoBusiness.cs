using CampanhaBD.Model;
using CampanhaBD.Util;
using System;
using System.Collections.Generic;


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
                List<ClienteModel> lista = _core.UnityOfWorkAdo.Campanhas.FiltroExportacao(campanha);
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
                        row.Add(cl.DataNascimento);
                        row.Add(cl.Cpf);
                        row.Add(cl.Nome);
                        row.Add("");
                        row.Add(cl.Uf);
                        row.Add("");
                        row.Add("");
                        row.Add("");

                        _core.UnityOfWorkAdo.Clientes.AtualizarDataExpProcessa(cl);
                        writer.WriteRow(row);
                    }

                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExportarPlanilhaFiltro(CampanhaModel campanha, string caminho)
        {
            try
            {
                List<ClienteModel> lista = _core.UnityOfWorkAdo.Campanhas.FiltroExportacao(campanha);
                string[] cabecalho = FormarCabecalhoPlanilhaCompleto();

                using (ManipuladorCsv.CsvFileWriter writer = new ManipuladorCsv.CsvFileWriter(caminho))
                {
                    ManipuladorCsv.CsvRow row = new ManipuladorCsv.CsvRow();
                    foreach (string c in cabecalho)
                    {
                        row.Add(c);
                    }
                    writer.WriteRow(row);

                    foreach (ClienteModel cliente in lista)
                    {
                        var cl = _core.UnityOfWorkAdo.Clientes.ListarPorId(cliente);
                        cl.Beneficios = cliente.Beneficios;
                        cl.Emprestimos = _core.UnityOfWorkAdo.Emprestimos.ListarEmprestimosPorCliente(cl.Id);

                        row = new ManipuladorCsv.CsvRow();

                        row.Add(cl.Beneficios[0].Numero.ToString());
                        row.Add(cl.Cpf);
                        row.Add(cl.DataNascimento);
                        row.Add(cl.Nome);
                        row.Add(cl.Uf);
                        row.Add(cl.Cidade);
                        row.Add(cl.Bairro);
                        row.Add(cl.Cep);
                        row.Add(cl.Logradouro);
                        row.Add(cl.Numero);
                        row.Add(cl.Complemento);
                        row.Add(cl.Ddd);
                        row.Add(cl.Telefone);
                        row.Add(cl.DataEmpAtualizado);
                        row.Add(cl.DataTelAtualizado);
                        row.Add(cl.DataTrabalhado);
                        row.Add(cl.DataExpProcessa);
                        row.Add(cl.DataImportado);

                        foreach (var emp in cl.Emprestimos)
                        {
                            row.Add(emp.BancoId.ToString());
                            row.Add(emp.ParcelasNoContrato.ToString());
                            row.Add(emp.ParcelasEmAberto.ToString());
                            row.Add(emp.ValorParcela.ToString());
                            row.Add(emp.Saldo.ToString());
                            row.Add(emp.InicioPagamento);
                        }

                        writer.WriteRow(row);
                    }

                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExportarPlanilhaPanorama(CampanhaModel campanha, string caminho)
        {
            try
            {
                List<ClienteModel> lista = _core.UnityOfWorkAdo.Campanhas.FiltroExportacao(campanha);
                string[] cabecalho = 
                {
                    "BENEFICIO", "CPF", "DATA_NASCIMENTO", "NOME", "UF", "CIDADE", "BAIRRO", "CEP", "LOGRADOURO",
                    "NUMERO", "COMPLEMENTO", "DDD", "TELEFONE", "DATA_EMP_ATUALIZADOS", "DATA_TEL_ATUALIZADO",
                    "DATA_TRABALHADO"
                };

                using (ManipuladorCsv.CsvFileWriter writer = new ManipuladorCsv.CsvFileWriter(caminho))
                {
                    ManipuladorCsv.CsvRow row = new ManipuladorCsv.CsvRow();
                    foreach (string c in cabecalho)
                    {
                        row.Add(c);
                    }
                    writer.WriteRow(row);

                    foreach (ClienteModel cliente in lista)
                    {
                        var cl = _core.UnityOfWorkAdo.Clientes.ListarPorId(cliente);
                        cl.Beneficios = cliente.Beneficios;

                        row = new ManipuladorCsv.CsvRow();

                        row.Add(cl.Beneficios[0].Numero.ToString());
                        row.Add(cl.Cpf);
                        row.Add(cl.DataNascimento);
                        row.Add(cl.Nome);
                        row.Add(cl.Uf);
                        row.Add(cl.Cidade);
                        row.Add(cl.Bairro);
                        row.Add(cl.Cep);
                        row.Add(cl.Logradouro);
                        row.Add(cl.Numero);
                        row.Add(cl.Complemento);
                        row.Add(cl.Ddd);
                        row.Add(cl.Telefone);
                        row.Add(cl.DataEmpAtualizado);
                        row.Add(cl.DataTelAtualizado);
                        row.Add(cl.DataTrabalhado);

                        _core.UnityOfWorkAdo.Clientes.AtualizarDataTrabalhado(cl);
                        writer.WriteRow(row);
                    }

                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExportarPlanilhaTelefone(CampanhaModel campanha, string caminho)
        {
            try
            {
                List<ClienteModel> lista = _core.UnityOfWorkAdo.Campanhas.FiltroExportacao(campanha);
                string[] cabecalho = { "CPF" };

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

                        row.Add(cl.Cpf);

                        writer.WriteRow(row);
                    }

                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExportarProcessa(CampanhaModel campanha)
        {
            try
            {
                List<ClienteModel> listaClientes = _core.UnityOfWorkAdo.Campanhas.FiltroExportacao(campanha);

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
                    _core.UnityOfWorkAdo.Clientes.AtualizarDataExpProcessa(cl);
                }
            }
            catch
            {
                throw;
            }
        }

        public string[] FormarCabecalhoPlanilhaCompleto()
        {
            try
            {
                List<string> lista = new List<string>();

                lista.Add("BENEFICIO");
                lista.Add("CPF");
                lista.Add("DATA_NASCIMENTO");
                lista.Add("NOME");
                lista.Add("UF");
                lista.Add("CIDADE");
                lista.Add("BAIRRO");
                lista.Add("CEP");
                lista.Add("LOGRADOURO");
                lista.Add("NUMERO");
                lista.Add("COMPLEMENTO");
                lista.Add("DDD");
                lista.Add("TELEFONE");
                lista.Add("DATA_EMP_ATUALIZADOS");
                lista.Add("DATA_TEL_ATUALIZADO");
                lista.Add("DATA_TRABALHADO");
                lista.Add("DATA_EXP_PROCESSA");
                lista.Add("DATA_IMPORTADO");

                for (int i=1;i<=12;i++)
                {
                    lista.Add("BANCO_ID_" + i);
                    lista.Add("PARCELAS_CONTRATO_" + i);
                    lista.Add("PARCELAS_EM_ABERTO_" + i);
                    lista.Add("VALOR_PARCELA_" + i);
                    lista.Add("SALDO_" + i);
                    lista.Add("INCIO_PAGAMENTO_" + i);
                }

                return lista.ToArray();
            }
            catch
            {
                throw;
            }
        }

    }
}
