using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;
using CampanhaBD.Util;
using System;
using System.Collections.Generic;

namespace CampanhaBD.Business
{
    public class ExportacaoBusiness
    {
        private string _connectionString;

        public ExportacaoBusiness(string connectionString)
        {
            try
            {
                _connectionString = connectionString;
            }
            catch
            {
                throw;
            }
        }

        public void ExportarPlanilhaProcessa(FiltroModel campanha, string caminho)
        {
            try
            {
                ExportacaoModel exportacao = new ExportacaoModel(caminho);
                exportacao.EscreverCabecalhoProcessa();

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Filtros.ExportaProcessa(campanha, ref exportacao);
                }

                exportacao.FinalizarRelatorio();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExportarPlanilhaFiltro(FiltroModel campanha, string caminho)
        {
            try
            {
                ExportacaoModel exportacao = new ExportacaoModel(caminho);
                exportacao.EscreverCabecalhoCompleto();

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Filtros.ExportaCompleto(campanha, ref exportacao);
                }

                exportacao.FinalizarRelatorio();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExportarPlanilhaPanorama(FiltroModel campanha, string caminho)
        {
            try
            {
                ExportacaoModel exportacao = new ExportacaoModel(caminho);
                exportacao.EscreverCabecalhoCompleto();

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Filtros.ExportaCompleto(campanha, ref exportacao);
                }

                exportacao.FinalizarRelatorio();

                //unit.Clientes.AtualizarDataTrabalhado(cl);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExportarPlanilhaTelefone(FiltroModel campanha, string caminho)
        {
            try
            {
                ExportacaoModel exportacao = new ExportacaoModel(caminho);
                exportacao.EscreverCabecalhoTelefone();

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Filtros.ExportaTelefone(campanha, ref exportacao);
                }

                exportacao.FinalizarRelatorio();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ExportarProcessa(FiltroModel campanha)
        {
            try
            {
                ConsultaProcessaModel consultaProcessa = new ConsultaProcessaModel();
                List<ClienteModel> listaClientes = new List<ClienteModel>();

                consultaProcessa.Descricao = campanha.Nome;

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    listaClientes = unit.Filtros.ExportaProcessa(campanha);
                    unit.ConsultasProcessa.InserirConsulta(consultaProcessa);

                    foreach (ClienteModel cl in listaClientes)
                    {
                        ConsultaDadosProcessaModel dados = new ConsultaDadosProcessaModel();

                        dados.Consulta = consultaProcessa.Consulta;
                        dados.Beneficio = cl.Beneficios[0].Numero.ToString();
                        dados.DataNascimento = cl.DataNascimento;
                        dados.Cpf = cl.Cpf;
                        dados.Nome = cl.Nome;

                        unit.ConsultasDadosProcessa.InserirConsultaDados(dados);
                        unit.Clientes.AtualizarDataExpProcessa(cl);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
