using System;
using System.ComponentModel.DataAnnotations;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class ImportacaoClienteViewModel
    {
        [Display(Name = "N° Benefício")]
        public int NumBeneficio { get; set; }

        public int ValorBeneficio { get; set; }

        public int Nome { get; set; }

        [Required]
        public int Cpf { get; set; }

        public int DigitoCpf { get; set; }

        public int Uf { get; set; }

        public int Cidade { get; set; }

        public int Bairro { get; set; }

        public int Ddd { get; set; }

        public int Telefone { get; set; }

        [Display(Name = "Data de Nascimento")]
        public int DataNascimento { get; set; }

        public int Logradouro { get; set; }

        public int Numero { get; set; }

        [Display(Name = "CEP")]
        public int Cep { get; set; }

        [Display(Name = "Valor de Parcela")]
        public int ValorParcela { get; set; }

        [Display(Name = "Parcelas no contrato")]
        public int ParcelasNoContrato { get; set; }

        [Display(Name = "Parcelas pagas")]
        public int ParcelasPagas { get; set; }

        public int Saldo { get; set; }

        [Display(Name = "Inicio de Pagamento")]
        public int InicioPagamento { get; set; }

        [Display(Name = "Código do Banco")]
        public int BancoId { get; set; }

        public string[] Colunas { get; set; }

        public int UsuarioId { get; set; }

        public int ImpId { get; set; }
    }
}