using System;
using System.Collections.Generic;

namespace CampanhaBD.Model
{
    public class Cliente : Pessoa
    {
        public int ImportacaoId { get; set; }

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

        public bool Trabalhado { get; set; }

        public Beneficio Beneficio { get; set; }

        public List<Emprestimo> Emprestimos { get; set; }

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
        public static readonly int INDICE_INICIO_PAGAMENTO = 15;

        public Cliente()
        {
            Beneficio = new Beneficio();
            Emprestimos = new List<Emprestimo>();
        }

        public void preencheCampo(int indiceCampo, String valor)
        {
            switch (indiceCampo)
            {
                case 0:
                    Nome = valor;
                    break;
                case 1:
                    DataNascimento = DateTime.Parse(valor);
                    break;
                case 2:
                    Cpf = valor + Cpf;

                    //Validando quantidade de dígitos para 11
                    while (Cpf.Length < 11) { Cpf = "0" + Cpf;  }
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
                    Beneficio.Numero = int.Parse(valor);
                    break;
                case 12:
                    Emprestimos[0].BancoId = int.Parse(valor);
                    break;
                case 13:
                    Emprestimos[0].Saldo = float.Parse(valor.Replace(',', '.'));
                    break;
                case 14:
                    Emprestimos[0].ValorParcela = float.Parse(valor.Replace(',', '.'));
                    break;
                case 15:
                    Emprestimos[0].ParcelasNoContrato = int.Parse(valor);
                    break;
                case 16:
                    //10 é o dia de desconta na folha de pagamento
                    valor = valor + "10";
                    Emprestimos[0].InicioPagamento = DateTime.Parse(valor);
                    break;
            }
        }
    }
}
