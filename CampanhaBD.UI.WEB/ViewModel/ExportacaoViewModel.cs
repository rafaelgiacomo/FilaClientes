using CampanhaBD.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class ExportacaoViewModel
    {
        [Required]
        [Display(Name = "Banco")]
        public int CodigoBanco { get; set; }

        [Display(Name = "Min Data Nascimento")]
        public DateTime MinDataNascimento { get; set; }

        [Display(Name = "Max Data Nascimento")]
        public DateTime MaxDataNascimento { get; set; }

        [Display(Name = "Min CEP")]
        public string MinCep { get; set; }

        [Display(Name = "Max CEP")]
        public string MaxCep { get; set; }

        [Display(Name = "Min Valor Parcela")]
        public float MinParcela { get; set; }

        [Display(Name = "Max Valor Parcela")]
        public float MaxParcela { get; set; }

        [Display(Name = "Min Data Emprestimoa Atualizados")]
        public DateTime MinDataAtualEmp { get; set; }

        [Display(Name = "Min Data Emprestimoa Atualizados")]
        public DateTime MaxDataAtualEmp { get; set; }

        [Display(Name = "Min Data Telefone Atualizado")]
        public DateTime MinDataAtualTel { get; set; }

        [Display(Name = "Max Data Telefone Atualizado")]
        public DateTime MaxDataAtualTel { get; set; }

        [Display(Name = "Min Data Trabalhado")]
        public DateTime MinDataTrabalhado { get; set; }

        [Display(Name = "Max Data Trabalhado")]
        public DateTime MaxDataTrabalhado { get; set; }

        [Display(Name = "Min Qtd Parcelas Pagas")]
        public int MinParcelasPagas { get; set; }

        [Display(Name = "Max Qtd Parcelas Pagas")]
        public int MaxParcelasPagas { get; set; }

    }
}