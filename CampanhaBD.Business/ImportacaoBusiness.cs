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

        public List<BaseOriginalDadoModel> ClientesImportados { get; set; }
        #endregion

        #region Métodos públicos
        public void AdicionarImportacao(ImportacaoModel entidade)
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Importacoes.Inserir(entidade);
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
                    ClientesImportados = unit.Filtros.FiltroImportacaoBaseOriginal(filtro);
                    _cliente = new ClienteModel();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ImportarClienteDoSql(ImportacaoModel imp, FiltroModel filtro)
        {
            try
            {
                if (ClientesImportados.Count > 0)
                {

                    _cliente.LimparPropriedades();

                    _cliente.ImportacaoId = imp.Id;
                    //unit.Filtros.LerDadosClienteBaseOriginal(_cliente);
                    DadosBaseParaCliente();

                    if (ValidaDadosCliente())
                    {
                        SalvarCliente(filtro);
                    }
                    else
                    {

                    }

                    if (ValidaDadosBeneficio())
                    {
                        SalvarBeneficio(filtro);
                    }
                    else
                    {

                    }

                    if (ValidaDadosEmprestimo())
                    {
                        SalvarEmprestimo();
                    }
                    else
                    {

                    }

                    ClientesImportados.RemoveAt(ClientesImportados.Count - 1);
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
                    unit.Importacoes.SalvarNumImportados(imp);
                    unit.Importacoes.Terminar(imp);
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
        private void DadosBaseParaCliente()
        {
            try
            {
                BaseOriginalDadoModel registro = ClientesImportados.Last();
                EmprestimoModel emp = new EmprestimoModel();
                BeneficioModel ben = new BeneficioModel();

                #region Dados Cliente
                _cliente.PreencheCpf(registro.Cpf);
                _cliente.PreencheDataNascimento(registro.DataNascimento);
                _cliente.PreencheCep(registro.Cep);

                _cliente.Uf = registro.Uf;
                _cliente.Cidade = registro.Municipio;
                _cliente.Logradouro = registro.Endereco;
                //cl.Numero = Reader[BaseOriginalDadoModel.COLUMN_NUM_BENEFICIO].ToString();
                _cliente.Ddd = registro.Ddd;
                _cliente.Telefone = registro.Telefone;
                _cliente.Nome = registro.Nome;
                _cliente.Bairro = registro.Bairro;
                _cliente.Ativado = (registro.DataExcluidoInss == "00000000");
                //cl.Complemento = Reader[BaseOriginalDadoModel.COLUMN_COMPLEMENTO].ToString();
                #endregion

                #region Dados Emprestimo
                emp.ClienteId = _cliente.Id;
                emp.PreencheValorParcela(registro.ValorParcela);
                emp.PreencheValorBruto(registro.ValorEmprestimo);
                emp.PreencheNumBeneficio(registro.NumBeneficio);
                emp.PreencheDataInicioPagamento(registro.DataInicioPagamento);
                emp.PreencheDataFimPagamento(registro.DataFimPagamento);
                emp.PreencheParcelasContrato(registro.ParcelasNoContrato);
                emp.PreencheBancoId(registro.BancoEmprestimo);
                emp.PreencheTipoEmprestimo(registro.TipoEmprestimo);
                emp.PreencheSituacaoEmprestimo(registro.SituacaoEmprestimo);
                #endregion

                #region DadosBeneficio
                ben.IdCliente = _cliente.Id;
                ben.Numero = emp.NumBeneficio;
                ben.PreencheBancoPagamento(registro.BancoPagamento);
                ben.PreencheAgenciaPagamento(registro.AgenciaPagamento);
                ben.PreencheOrgaoPagador(registro.OrgaoPagador);
                ben.PreencheSalario(registro.ValorBeneficio);
                ben.PreencheDataInicioBeneficio(registro.DataInicioBeneficio);
                ben.PreencheDataIncluidoInss(registro.DataIncluidoInss);
                ben.PreencheDataExcluidoInss(registro.DataExcluidoInss);
                ben.PreencheEspecie(registro.Especie);
                #endregion

                _cliente.Emprestimos.Clear();
                _cliente.Beneficios.Clear();

                _cliente.Emprestimos.Add(emp);
                _cliente.Beneficios.Add(ben);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SalvarCliente(FiltroModel filtro)
        {
            try
            {
                InserirCliente();
            }
            catch (Exception ex)
            {
                if (filtro.AtualizarDadosCliente)
                {
                    AlterarCliente();
                }                
            }
        }

        private void SalvarBeneficio(FiltroModel filtro)
        {
            try
            {
                InserirBeneficio();
            }
            catch (Exception ex)
            {
                if (filtro.AtualizarDadosCliente)
                {
                    if (_cliente.Beneficios[0].DataExcluidoInss != null)
                    {
                        AlterarBeneficio();
                    }
                    else
                    {
                        AlterarBeneficioSemDataExclusao();
                    }
                    
                }                
            }
        }

        private void InserirBeneficio()
        {
            using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
            {
                _cliente.Beneficios[0].DataCompetencia = DateTime.Now;
                unit.Beneficios.Inserir(_cliente.Beneficios[0]);
            }
        }

        private void AlterarBeneficio()
        {
            using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
            {
                if (_cliente.Beneficios[0].Numero > 0)
                {
                    unit.Beneficios.Alterar(_cliente.Beneficios[0]);
                }
            }
        }

        private void AlterarBeneficioSemDataExclusao()
        {
            using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
            {
                if (_cliente.Beneficios[0].Numero > 0)
                {
                    unit.Beneficios.AlterarSemDataExclusao(_cliente.Beneficios[0]);
                }
            }
        }

        private void SalvarEmprestimo()
        {
            try
            {
                using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
                {
                    unit.Emprestimos.Inserir(_cliente.Emprestimos[0]);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void InserirCliente()
        {
            using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
            {
                unit.Clientes.Inserir(_cliente);

                _cliente.Beneficios[0].IdCliente = _cliente.Id;
                _cliente.Emprestimos[0].ClienteId = _cliente.Id;
            }
        }

        private void AlterarCliente()
        {
            using (UnityOfWorkAdo unit = new UnityOfWorkAdo(_connectionString))
            {
                var idCliente = unit.Clientes.SelecionarIdPorCpf(_cliente);
                _cliente.Id = idCliente;
                _cliente.Beneficios[0].IdCliente = _cliente.Id;
                _cliente.Emprestimos[0].ClienteId = _cliente.Id;

                if (idCliente > 0)
                {
                    unit.Clientes.Alterar(_cliente);
                }
            }
        }

        private bool ValidaDadosCliente()
        {
            try
            {
                if ("".Equals(_cliente.Cpf))
                {
                    return false;
                }

                if (_cliente.ImportacaoId <= 0)
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

        private bool ValidaDadosBeneficio()
        {
            try
            {
                BeneficioModel beneficio = _cliente.Beneficios[0];

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

        private bool ValidaDadosEmprestimo()
        {
            try
            {
                EmprestimoModel emprestimo = _cliente.Emprestimos[0];

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
                ClientesImportados = new List<BaseOriginalDadoModel>();
            }
            catch
            {
                throw;
            }
        }

    }
}
