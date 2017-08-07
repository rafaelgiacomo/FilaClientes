using CampanhaBD.Model;
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
        private CoreBusiness _core;

        private ClienteModel _cliente;

        public bool ContinuarImportacao { get; set; }
        #endregion

        #region Métodos públicos
        public void AdicionarImportacao(ImportacaoModel entidade)
        {
            try
            {
                _core.UnityOfWorkAdo.AbrirTransacao();
                _core.UnityOfWorkAdo.Importacoes.Inserir(entidade);
                _core.UnityOfWorkAdo.Commit();
            }
            catch
            {
                _core.UnityOfWorkAdo.RollBack();
                throw;
            }
        }

        public void SalvarCaminhoImportacao(ImportacaoModel entidade)
        {
            try
            {
                _core.UnityOfWorkAdo.Importacoes.SalvarCaminho(entidade);
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

                _core.UnityOfWorkAdo.Importacoes.Terminar(imp);
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
                _core.UnityOfWorkAdo.AbrirTransacao();
                _core.UnityOfWorkAdo.Importacoes.Inserir(imp);
                _core.UnityOfWorkAdo.Filtros.FiltroImportacaoBaseOriginal(filtro);
                _cliente = new ClienteModel();
                ContinuarImportacao = true;
            }
            catch (Exception ex)
            {

            }
        }

        public void ImportarClienteDoSql(ImportacaoModel imp, FiltroModel filtro)
        {
            try
            {
                if (ContinuarImportacao)
                {
                    _cliente.LimparPropriedades();

                    _cliente.ImportacaoId = imp.Id;
                    ContinuarImportacao = _core.UnityOfWorkAdo.Filtros.LerDadosClienteBaseOriginal(_cliente);

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
                _core.UnityOfWorkAdo.RollBack();
                throw;
            }
        }

        public void TerminarImportacaoClientesSql(ImportacaoModel imp)
        {
            try
            {
                _core.UnityOfWorkAdo.Filtros.FecharReader();

                _core.UnityOfWorkAdo.Importacoes.SalvarNumImportados(imp);
                _core.UnityOfWorkAdo.Importacoes.Terminar(imp);

                _core.UnityOfWorkAdo.Commit();
            }
            catch (Exception ex)
            {

            }
        }

        public void AlterarImportacao(ImportacaoModel entidade)
        {
            try
            {
                _core.UnityOfWorkAdo.Importacoes.Alterar(entidade);
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
                ImportacaoModel entidade = new ImportacaoModel();
                entidade.Id = id;
                _core.UnityOfWorkAdo.Importacoes.Excluir(entidade);
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
                if (!_core.UnityOfWorkAdo.Filtros.Reader.IsClosed)
                    _core.UnityOfWorkAdo.Filtros.Reader.Close();

                _core.UnityOfWorkAdo.RollBack();
            }
            catch (Exception ex)
            {

            }
        }

        public int EstimarQuantidade(FiltroModel filtro)
        {
            try
            {
                return _core.UnityOfWorkAdo.Filtros.EstimarQtdFiltroBaseOriginal(filtro);
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
                var retorno = _core.UnityOfWorkAdo.Importacoes.ListarTodos();

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
                entidade.Id = id;

                var retorno = _core.UnityOfWorkAdo.Importacoes.ListarPorId(entidade);

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
                entidade.Nome = nome;

                var retorno = _core.UnityOfWorkAdo.Importacoes.ListarPorNome(entidade);

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
                _core.UnityOfWorkAdo.Clientes.Inserir(cliente);
            }
            catch (Exception)
            {
                if (filtro.AtualizarDadosCliente)
                {
                    _core.UnityOfWorkAdo.Clientes.Alterar(cliente);
                }
            }
        }

        private void SalvarBeneficio(BeneficioModel beneficio)
        {
            try
            {
                beneficio.DataCompetencia = DateTime.Now;
                _core.UnityOfWorkAdo.Beneficios.Inserir(beneficio);
            }
            catch (Exception ex)
            {

            }
        }

        private void SalvarEmprestimo(EmprestimoModel emprestimo)
        {
            try
            {
                _core.UnityOfWorkAdo.Emprestimos.Inserir(emprestimo);
            }
            catch (Exception ex)
            {

            }
        }

        private bool ValidaDadosCliente(ClienteModel cliente)
        {
            try
            {
                if (cliente.Id <= 0)
                {
                    return false;
                }

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

        public ImportacaoBusiness(CoreBusiness core)
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

    }
}
