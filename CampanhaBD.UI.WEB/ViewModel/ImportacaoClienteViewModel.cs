using System;
using System.ComponentModel.DataAnnotations;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class ImportacaoClienteViewModel
    {
        [Display(Name = "N° Benefício")]
        public int NumBeneficio { get; set; }

        [Display(Name = "Valor Beneficio")]
        public int ValorBeneficio { get; set; }

        public int Nome { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public int Cpf { get; set; }

        [Display(Name = "Digito CPF")]
        public int DigitoCpf { get; set; }

        [Display(Name = "UF")]
        public int Uf { get; set; }

        public int Cidade { get; set; }

        public int Bairro { get; set; }

        [Display(Name = "DDD")]
        public int Ddd { get; set; }

        public int Telefone { get; set; }

        [Display(Name = "Data de Nascimento")]
        public int DataNascimento { get; set; }

        [Display(Name = "Endereço")]
        public int Logradouro { get; set; }

        [Display(Name = "N°")]
        public int Numero { get; set; }

        [Display(Name = "Complemento")]
        public int Complemento { get; set; }

        [Display(Name = "CEP")]
        public int Cep { get; set; }

        [Display(Name = "Valor de Parcela")]
        public int ValorParcela { get; set; }

        [Display(Name = "Parcelas no contrato")]
        public int ParcelasNoContrato { get; set; }

        [Display(Name = "Parcelas pagas")]
        public int ParcelasPagas { get; set; }

        [Display(Name = "Saldo")]
        public int Saldo { get; set; }

        [Display(Name = "Data Inicio Pagamento")]
        public int InicioPagamento { get; set; }

        [Display(Name = "Código do Banco")]
        public int BancoId { get; set; }

        public string[] Colunas { get; set; }

        public int UsuarioId { get; set; }

        public int ImpId { get; set; }
    }
}