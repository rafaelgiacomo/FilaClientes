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
        private CoreBusiness _core;

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

        public void AdicionarImportacao(ImportacaoModel entidade)
        {
            try
            {
                _core.UnityOfWorkAdo.Importacoes.Inserir(entidade);
            }
            catch
            {
                throw;
            }
        }

        public void ImportarClientes(ImportacaoModel imp, int[] vetorAssossiacoes)
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
                    cliente.UsuarioId = imp.UsuarioId;
                    cliente.DataImportado = DateTime.Now.ToString();

                    for (int i = 0; i < valores.Length; i++)
                    {
                        if (valores[i] > -1)
                        {
                            cliente.preencheCampo(i, linhaSeparada[valores[i]]);
                        }
                    }

                    var cl = _core.UnityOfWorkAdo.Clientes.ListarPorCpf(cliente);

                    if (cl == null)
                    {
                        _core.UnityOfWorkAdo.Clientes.Inserir(cliente);

                        if (cliente.Beneficios[0].Numero != 0)
                        {
                            cliente.Beneficios[0].IdCliente = cliente.Id;
                            cliente.Beneficios[0].DataCompetencia = DateTime.Now;
                            cliente.Emprestimos[0].ClienteId = cliente.Id;

                            _core.UnityOfWorkAdo.Beneficios.Inserir(cliente.Beneficios[0]);

                            if (cliente.Emprestimos[0].BancoId != 0 && cliente.Emprestimos[0].ValorParcela != 0)
                            {
                                _core.UnityOfWorkAdo.Emprestimos.Inserir(cliente.Emprestimos[0]);
                            }
                        }                      
                        
                    }
                    else
                    {
                        if (cliente.Beneficios[0].Numero != 0)
                        {
                            var ben = _core.UnityOfWorkAdo.Beneficios.ListarPorId(cliente.Beneficios[0]);

                            if (ben == null)
                            {
                                cliente.Beneficios[0].IdCliente = cl.Id;
                                cliente.Beneficios[0].DataCompetencia = DateTime.Now;
                                _core.UnityOfWorkAdo.Beneficios.Inserir(cliente.Beneficios[0]);
                            }

                            if (cliente.Emprestimos[0].BancoId != 0 && cliente.Emprestimos[0].ValorParcela != 0)
                            {
                                cliente.Emprestimos[0].ClienteId = cl.Id;
                                _core.UnityOfWorkAdo.Emprestimos.Inserir(cliente.Emprestimos[0]);
                            }

                        }

                        _core.UnityOfWorkAdo.Clientes.AlterarImportacao(cliente);
                    }
                }

                _core.UnityOfWorkAdo.Importacoes.Terminar(imp);
            }
            catch
            {
                throw;
            }
            finally
            {
                stream.Close();
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

    }
}
