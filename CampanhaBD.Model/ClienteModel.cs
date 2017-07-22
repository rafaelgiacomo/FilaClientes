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

        public string DataNascimento { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string DataTelAtualizado { get; set; }

        public string DataEmpAtualizado { get; set; }

        public string DataTrabalhado { get; set; }

        public string DataImportado { get; set; }

        public List<BeneficioModel> Beneficios { get; set; }

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
        public const string PROCEDURE_UPDATE_DATA_TRABALHADO = "SP_ATUALIZAR_DATA_TRABALHADO";
        public const string PROCEDURE_UPDATE_DATA_EMPRESTIMO = "SP_ATUALIZAR_DATA_EMP_ATUALIZADO";
        public const string PROCEDURE_UPDATE_DATA_TELEFONE = "SP_ATUALIZAR_DATA_TEL_ATUALIZADO";
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
        public const string COLUMN_DATA_IMPORTADO = "DataImportado";
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
        public static readonly int INDICE_COMPLEMENTO = 18;

        public ClienteModel()
        {
            Nome = String.Empty;
            Cpf = String.Empty;
            Uf = String.Empty;
            Cidade = String.Empty;
            Bairro = String.Empty;
            Ddd = String.Empty;
            Telefone = String.Empty;
            DataNascimento = String.Empty;
            Logradouro = String.Empty;
            Numero = String.Empty;
            Complemento = String.Empty;
            Cep = String.Empty;
            DataTelAtualizado = String.Empty;
            DataEmpAtualizado = String.Empty;
            DataTrabalhado = String.Empty;
            DataImportado = String.Empty;

            Beneficios = new List<BeneficioModel>();
            Emprestimos = new List<EmprestimoModel>();
            Beneficios.Add(new BeneficioModel());
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
                        if (!"".Equals(valor))
                        {
                            var data = Convert.ToDateTime(valor);

                            if (DateTime.Compare(data, DateTime.MinValue) >= 0)
                            {
                                DataNascimento = data.ToString("dd/MM/yyyy");
                            }                            
                        }
                        
                        break;
                    case 2:
                        Cpf = valor + Cpf;
                        Cpf = Cpf.Replace(".", "");
                        Cpf = Cpf.Replace("-", "");

                        //Validando quantidade de dígitos para 11
                        while (Cpf.Length < 11) { Cpf = "0" + Cpf; }

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
                        valor = valor.Replace("-", "");
                        while (valor.Length < 8)
                        {
                            valor = "0" + valor;
                        }
                        Cep = valor;
                        break;
                    case 11:
                        if (!"".Equals(valor))
                        {
                            valor = valor.Replace(".", "");
                            valor = valor.Replace("-", "");
                            Beneficios[0].Numero = long.Parse(valor);
                            Emprestimos[0].NumBeneficio = long.Parse(valor);
                        }                        
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
                        Beneficios[0].Salario = float.Parse(valor);
                        break;
                    case 18:
                        Complemento = valor;
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}