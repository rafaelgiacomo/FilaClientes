using CampanhaBD.Model;
using CampanhaBD.RepositoryADO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Business
{
    public class ImportacaoBusiness
    {

        #region Propriedades
        private string _connectionString;

        private ClienteModel _cliente;
        #endregion

        #region Métodos públicos
        public void AdicionarImportacao(ImportacaoModel entidade)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.AbrirTransacao();
                    unit.Importacoes.Inserir(entidade);
                    unit.Commit();
                }
            }
            catch
            {
                //_core.UnityOfWorkAdo.RollBack();
                throw;
            }
        }

        public void SalvarCaminhoImportacao(ImportacaoModel entidade)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Importacoes.SalvarCaminho(entidade);
                }
            }
            catch
            {
                throw;
            }
        }

        public void ImportarClientesDeCsv(ImportacaoModel imp, int[] vetorAssossiacoes)
        {
            StreamReader stream = new StreamReader(imp.CaminhoArquivo);
            try
            {
                int[] valores = vetorAssossiacoes;
                string[] linhaSeparada = null;

                string linha = stream.ReadLine(); //Le o cabeçalho
                while ((linha = stream.ReadLine()) != null)
                {
                    linhaSeparada = linha.Split(';');
                    ClienteModel cliente = new ClienteModel();

                    cliente.ImportacaoId = imp.Id;
                    cliente.DataImportado = DateTime.Now.ToString();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                stream.Close();
            }
        }

        public void IniciarImportacaoClientesSql(ImportacaoModel imp, FiltroModel filtro)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Importacoes.Inserir(imp);
                    unit.Filtros.FiltroImportacaoBaseOriginal(filtro);
                    _cliente = new ClienteModel();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ImportarClienteDoSql(ImportacaoModel imp, FiltroModel filtro)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    _cliente.LimparPropriedades();

                    _cliente.ImportacaoId = imp.Id;
                    unit.Filtros.LerDadosClienteBaseOriginal(_cliente);

                    if (ValidaDadosCliente(_cliente))
                    {
                        SalvarCliente(_cliente, filtro);
                    }

                    if (ValidaDadosBeneficio(_cliente.Beneficios[0]))
                    {
                        SalvarBeneficio(_cliente.Beneficios[0]);
                    }

                    if (ValidaDadosEmprestimo(_cliente.Emprestimos[0]))
                    {
                        SalvarEmprestimo(_cliente.Emprestimos[0]);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void TerminarImportacaoClientesSql(ImportacaoModel imp)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Filtros.FecharReader();

                    unit.Importacoes.SalvarNumImportados(imp);
                    unit.Importacoes.Terminar(imp);

                    //unit.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void AlterarImportacao(ImportacaoModel entidade)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Importacoes.Alterar(entidade);
                }
            }
            catch
            {
                throw;
            }
        }

        public void ExcluirImportacao(int id)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    ImportacaoModel entidade = new ImportacaoModel();
                    entidade.Id = id;
                    unit.Importacoes.Excluir(entidade);
                }
            }
            catch
            {
                throw;
            }
        }

        public void CancelarImportacao()
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    if (!unit.Filtros.Reader.IsClosed)
                        unit.Filtros.Reader.Close();

                    unit.RollBack();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public int EstimarQuantidade(FiltroModel filtro)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    return unit.Filtros.EstimarQtdFiltroBaseOriginal(filtro);
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<ImportacaoModel> ListarTodos()
        {
            try
            {
                List<ImportacaoModel> retorno = new List<ImportacaoModel>();

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    retorno = unit.Importacoes.ListarTodos();
                }

                return retorno;
            }
            catch
            {
                throw;
            }
        }

        public ImportacaoModel ListarPorId(int id)
        {
            try
            {
                ImportacaoModel entidade = new ImportacaoModel();
                ImportacaoModel retorno = null;
                entidade.Id = id;

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    retorno = unit.Importacoes.ListarPorId(entidade);
                }

                return retorno;
            }
            catch
            {
                throw;
            }
        }

        public ImportacaoModel ListarPorNome(string nome)
        {
            try
            {
                ImportacaoModel entidade = new ImportacaoModel();
                ImportacaoModel retorno = null;
                entidade.Nome = nome;

                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    retorno = unit.Importacoes.ListarPorNome(entidade);
                }

                return retorno;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Métodos privados
        private void SalvarCliente(ClienteModel cliente, FiltroModel filtro)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Clientes.Inserir(cliente);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (!filtro.AtualizarDadosCliente)
                    {
                        using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                        {
                            unit.Clientes.Alterar(cliente);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private void SalvarBeneficio(BeneficioModel beneficio)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    beneficio.DataCompetencia = DateTime.Now;
                    unit.Beneficios.Inserir(beneficio);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void SalvarEmprestimo(EmprestimoModel emprestimo)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Emprestimos.Inserir(emprestimo);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private bool ValidaDadosCliente(ClienteModel cliente)
        {
            try
            {
                if ("".Equals(cliente.Cpf))
                {
                    return false;
                }

                if (cliente.ImportacaoId <= 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidaDadosBeneficio(BeneficioModel beneficio)
        {
            try
            {
                if (beneficio.IdCliente <= 0)
                {
                    return false;
                }

                if (beneficio.Numero <= 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidaDadosEmprestimo(EmprestimoModel emprestimo)
        {
            try
            {
                if (emprestimo.BancoId <= 0)
                {
                    return false;
                }

                if (emprestimo.ClienteId <= 0)
                {
                    return false;
                }

                if (emprestimo.ValorParcela <= 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        public ImportacaoBusiness(string connectionString)
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

    }
}
