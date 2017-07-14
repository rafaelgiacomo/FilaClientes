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
                    cliente.TelAtualizado = false;
                    cliente.EmpAtualizado = false;
                    cliente.Trabalhado = false;

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

                        cliente.Beneficio.IdCliente = cliente.Id;
                        cliente.Beneficio.DataCompetencia = DateTime.Now;
                        cliente.Emprestimos[0].ClienteId = cliente.Id;

                        _core.UnityOfWorkAdo.Beneficios.Inserir(cliente.Beneficio);
                        _core.UnityOfWorkAdo.Emprestimos.Inserir(cliente.Emprestimos[0]);
                    }
                    else
                    {
                        _core.UnityOfWorkAdo.Clientes.AlterarImportacao(cliente);
                        cliente.Emprestimos[0].ClienteId = cl.Id;
                        _core.UnityOfWorkAdo.Emprestimos.Inserir(cliente.Emprestimos[0]);
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                stream.Close();
            }            
            //_core.UnityOfWorkAdo.Importacoes.Terminar(imp.Id, imp.UsuarioId);
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
