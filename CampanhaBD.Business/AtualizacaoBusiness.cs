using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Business
{
    public class AtualizacaoBusiness
    {
        private CoreBusiness _core;

        public static readonly int INDICE_PROCESSA_BENEFICIO = 2;
        public static readonly int INDICE_PROCESSA_CPF = 4;
        public static readonly int INDICE_PROCESSA_BANCO_ID = 71;
        public static readonly int INDICE_PROCESSA_PARCELAS_CONTRATO = 72;
        public static readonly int INDICE_PROCESSA_PARCELAS_ABERTO = 73;
        public static readonly int INDICE_PROCESSA_VALOR_PARCELA = 74;
        public static readonly int INDICE_PROCESSA_SALDO = 75;

        public AtualizacaoBusiness(CoreBusiness core)
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

        public void AtualizarEmprestimos(string caminho)
        {
            StreamReader stream = new StreamReader(caminho);
            try
            {
                int[] valores = criaVetorValores();
                string[] linhaSeparada = null;

                string linha = stream.ReadLine(); //Le o cabeçalho
                while ((linha = stream.ReadLine()) != null)
                {
                    linhaSeparada = linha.Split(';');

                    EmprestimoModel empExcluir = new EmprestimoModel();
                    
                    empExcluir.BancoId = 422;

                    if ("".Equals(linhaSeparada[INDICE_PROCESSA_BENEFICIO]))
                    {
                        ClienteModel cl = new ClienteModel();
                        cl.Cpf = linhaSeparada[INDICE_PROCESSA_CPF];
                        cl = _core.UnityOfWorkAdo.Clientes.ListarPorCpf(cl);

                        empExcluir.ClienteId = cl.Id;

                        _core.UnityOfWorkAdo.Emprestimos.ExcluirPorClienteId(empExcluir);
                    }
                    else
                    {
                        empExcluir.NumBeneficio = long.Parse(linhaSeparada[INDICE_PROCESSA_BENEFICIO]);
                        _core.UnityOfWorkAdo.Emprestimos.ExcluirPorBeneficio(empExcluir);
                    }                    

                    for (int i = 0;i < 10; i++)
                    {
                        if (!"".Equals(linhaSeparada[INDICE_PROCESSA_BANCO_ID + (i*5)]))
                        {
                            EmprestimoModel emprestimo = new EmprestimoModel();

                            emprestimo.BancoId = 422;
                            emprestimo.NumBeneficio = long.Parse(linhaSeparada[INDICE_PROCESSA_BENEFICIO]);
                            emprestimo.ParcelasNoContrato = int.Parse(linhaSeparada[INDICE_PROCESSA_PARCELAS_CONTRATO + (i * 5)]);
                            emprestimo.ParcelasEmAberto = int.Parse(linhaSeparada[INDICE_PROCESSA_PARCELAS_ABERTO + (i * 5)]);
                            emprestimo.ValorParcela = float.Parse(linhaSeparada[INDICE_PROCESSA_VALOR_PARCELA + (i * 5)]);

                            _core.UnityOfWorkAdo.Emprestimos.InserirProcessa(emprestimo);
                        }
                        else
                        {
                            i = 10;
                        } 
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
        }

        public int[] criaVetorValores()
        {
            try
            {
                int[] vet = new int[19];
                //vet[ClienteModel.INDICE_NOME] = 4;
                //vet[ClienteModel.INDICE_DATA_NASCIMENTO] = 1;
                //vet[ClienteModel.INDICE_CPF] = model.Cpf - 1;
                //vet[ClienteModel.INDICE_DDD] = model.Ddd - 1;
                //vet[ClienteModel.INDICE_TELEFONE] = model.Telefone - 1;
                //vet[ClienteModel.INDICE_UF] = model.Uf - 1;
                //vet[ClienteModel.INDICE_CIDADE] = model.Cidade - 1;
                //vet[ClienteModel.INDICE_BAIRRO] = model.Bairro - 1;
                //vet[ClienteModel.INDICE_CEP] = model.Cep - 1;
                //vet[ClienteModel.INDICE_DIGITO_CPF] = 3;
                //vet[ClienteModel.INDICE_BANCO] = model.BancoId - 1;
                //vet[ClienteModel.INDICE_SALDO] = model.Saldo - 1;
                //vet[ClienteModel.INDICE_VALOR_PARCELA] = model.ValorParcela - 1;
                //vet[ClienteModel.INDICE_PARCELAS_NO_CONTRATO] = model.ParcelasNoContrato - 1;
                //vet[ClienteModel.INDICE_INICIO_PAGAMENTO] = model.InicioPagamento - 1;
                //vet[ClienteModel.INDICE_BENEFICIO] = 0;
                //vet[ClienteModel.INDICE_LOGRADOURO] = model.Logradouro - 1;
                //vet[ClienteModel.INDICE_VALOR_BENEFICIO] = model.ValorBeneficio - 1;
                //vet[ClienteModel.INDICE_COMPLEMENTO] = model.Complemento - 1;
                return vet;
            }
            catch
            {
                throw;
            }
        }

    }
}
