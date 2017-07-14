﻿using System;
using System.Collections.Generic;

namespace CampanhaBD.Model
{
    public class ClienteModel
    {

        #region Propriedades
        public long Id { get; set; }

        public string Nome { get; set; }

        public int ImportacaoId { get; set; }

        public int UsuarioId { get; set; }

        public string Cpf { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Ddd { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public bool TelAtualizado { get; set; }

        public bool EmpAtualizado { get; set; }

        public bool Trabalhado { get; set; }

        public DateTime DataTelAtualizado { get; set; }

        public DateTime DataEmpAtualizado { get; set; }

        public DateTime DataTrabalhado { get; set; }

        public BeneficioModel Beneficio { get; set; }

        public List<EmprestimoModel> Emprestimos { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_CLIENTE";
        public const string PROCEDURE_UPDATE = "SP_ALTERAR_CLIENTE";
        public const string PROCEDURE_DELETE = "SP_EXCLUIR_CLIENTE";
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODOS_CLIENTES";
        public const string PROCEDURE_SELECT_BY_IMPORTACAO = "SP_SELECIONAR_CLIENTES_IMPORTACAO";
        public const string PROCEDURE_SELECT_BY_ID = "SP_SELECIONAR_CLIENTE_ID";
        public const string PROCEDURE_SELECT_BY_CPF = "SP_SELECIONAR_CLIENTE_CPF";
        public const string COLUMN_ID = "Id";
        public const string COLUMN_IMPORTACAO_ID = "ImportacaoId";
        public const string COLUMN_NOME = "Nome";
        public const string COLUMN_CPF = "Cpf";
        public const string COLUMN_UF = "Uf";
        public const string COLUMN_CIDADE = "Cidade";
        public const string COLUMN_BAIRRO = "Bairro";
        public const string COLUMN_DDD = "Ddd";
        public const string COLUMN_TELEFONE = "Telefone";
        public const string COLUMN_DATANASCIMENTO = "DataNascimento";
        public const string COLUMN_LOGRADOURO = "Logradouro";
        public const string COLUMN_NUMERO = "Numero";
        public const string COLUMN_COMPLEMENTO = "Complemento";
        public const string COLUMN_CEP = "Cep";
        public const string COLUMN_TEL_ATUALIZADO = "TelAtualizado";
        public const string COLUMN_EMP_ATUALIZADO = "EmpAtualizados";
        public const string COLUMN_TRABALHADO = "Trabalhado";
        public const string COLUMN_DATA_TEL_ATUALIZADO = "DataTelAtualizado";
        public const string COLUMN_DATA_EMP_ATUALIZADOS = "DataEmpAtualizados";
        public const string COLUMN_DATA_TRABALHADO = "DataTrabalhado";
        #endregion

        public static readonly int INDICE_NOME = 0;
        public static readonly int INDICE_DATA_NASCIMENTO = 1;
        public static readonly int INDICE_CPF = 2;
        public static readonly int INDICE_DIGITO_CPF = 3;
        public static readonly int INDICE_UF = 4;
        public static readonly int INDICE_CIDADE = 5;
        public static readonly int INDICE_BAIRRO = 6;
        public static readonly int INDICE_DDD = 7;
        public static readonly int INDICE_TELEFONE = 8;
        public static readonly int INDICE_LOGRADOURO = 9;
        public static readonly int INDICE_CEP = 10;
        public static readonly int INDICE_BENEFICIO = 11;
        public static readonly int INDICE_BANCO = 12;
        public static readonly int INDICE_SALDO = 13;
        public static readonly int INDICE_VALOR_PARCELA = 14;
        public static readonly int INDICE_PARCELAS_NO_CONTRATO = 15;
        public static readonly int INDICE_INICIO_PAGAMENTO = 16;
        public static readonly int INDICE_VALOR_BENEFICIO = 17;

        public ClienteModel()
        {
            Beneficio = new BeneficioModel();
            Emprestimos = new List<EmprestimoModel>();
            Emprestimos.Add(new EmprestimoModel());
        }

        public void preencheCampo(int indiceCampo, String valor)
        {
            try
            {
                switch (indiceCampo)
                {
                    case 0:
                        Nome = valor;
                        break;
                    case 1:
                        string ano = valor.Substring(0, 4);
                        string mes = valor.Substring(4, 2);
                        string dia = valor.Substring(6, 2);
                        DataNascimento = DateTime.Parse(dia + "/" + mes + "/" + ano);
                        break;
                    case 2:
                        Cpf = valor + Cpf;

                        //Validando quantidade de dígitos para 11
                        while (Cpf.Length < 11) { Cpf = "0" + Cpf; }
                        while (Cpf.Length > 11) { Cpf += "0"; }

                        break;
                    case 3:
                        //Validando Qtd de dígitos do dígito verificador
                        while (valor.Length < 2) { valor = "0" + valor; }
                        while (valor.Length > 2) { valor = valor.Replace("0", ""); }

                        //juntando dígito verificador
                        Cpf += Cpf + valor;

                        //Validando qtd de dígitos final
                        while (Cpf.Length > 11) { Cpf += "0"; }

                        break;
                    case 4:
                        Uf = valor;
                        break;
                    case 5:
                        Cidade = valor;
                        break;
                    case 6:
                        Bairro = valor;
                        break;
                    case 7:
                        Ddd = valor;
                        break;
                    case 8:
                        Telefone = valor;
                        break;
                    case 9:
                        Logradouro = valor;
                        break;
                    case 10:
                        while (valor.Length < 8)
                        {
                            valor = "0" + valor;
                        }
                        Cep = valor;
                        break;
                    case 11:
                        while (valor.Length < 10)
                        {
                            valor = "0" + valor;
                        }
                        Beneficio.Numero = long.Parse(valor);
                        Emprestimos[0].NumBeneficio = long.Parse(valor);
                        break;
                    case 12:
                        Emprestimos[0].BancoId = Convert.ToInt32(valor);
                        break;
                    case 13:
                        Emprestimos[0].Saldo = float.Parse(valor);
                        break;
                    case 14:
                        Emprestimos[0].ValorParcela = float.Parse(valor);
                        break;
                    case 15:
                        Emprestimos[0].ParcelasNoContrato = Convert.ToInt32(valor);
                        break;
                    case 16:
                        //10 é o dia de desconta na folha de pagamento
                        string anoIni = valor.Substring(0, 4);
                        string mesIni = valor.Substring(4, 2);
                        string diaIni = "10";
                        Emprestimos[0].InicioPagamento = DateTime.Parse(diaIni + "/" + mesIni + "/" + anoIni);
                        break;
                    case 17:
                        Beneficio.Salario = float.Parse(valor);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
