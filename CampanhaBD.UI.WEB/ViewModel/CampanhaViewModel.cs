using CampanhaBD.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class CampanhaViewModel
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        [Required]
        [Display(Name = "Nome da campanha")]
        public string Nome { get; set; }

        [Display(Name="Mínimo de parcelas")]
        public float MinParcela { get; set; }

        [Display(Name = "Máximo de parcelas")]
        public float MaxParcela { get; set; }

        [Display(Name = "Data mínima de pagto")]
        public string MinInicioPag { get; set; }

        [Display(Name = "Data máxima de pgto")]
        public string MaxInicioPag { get; set; }

        [Display(Name = "Mínimo de parcelas pagas")]
        public int MinParcelasPagas { get; set; }

        [Display(Name = "Máximo de parcelas pagas")]
        public int MaxParcelasPagas { get; set; }

        [Display(Name = "Mínimo data de nascimento")]
        public DateTime MinDataNascimento { get; set; }

        [Display(Name = "Apenas não exportados?")]
        public bool ApenasNaoExportados { get; set; }

        [Display(Name = "CEP mínimo")]
        public string MinCep { get; set; }

        [Display(Name = "CEP máximo")]
        public string MaxCep { get; set; }

        [Display(Name = "Código banco")]
        public int CodigoBanco { get; set; }


        public Campanha ParaCampanhaModel()
        {
            Campanha campanha = new Campanha()
            {
                Id = this.Id,
                UsuarioId = this.UsuarioId,
                Nome = this.Nome,
                MinParcela = this.MinParcela,
                MaxParcela = this.MaxParcela,
                MinInicioPag = this.MinInicioPag,
                MaxInicioPag = this.MaxInicioPag,
                MinParcelasPagas = this.MinParcelasPagas,
                MaxParcelasPagas = this.MaxParcelasPagas,
                MinDataNascimento = this.MinDataNascimento,
                ApenasNaoExportados = this.ApenasNaoExportados,
                MinCep = this.MinCep,
                MaxCep = this.MaxCep,
                CodigoBanco = this.CodigoBanco
            };
            return campanha;
        }

        public void ParaViewModel(Campanha campanha)
        {
            Id = campanha.Id;
            UsuarioId = campanha.UsuarioId;
            Nome = campanha.Nome;
            MinParcela = campanha.MinParcela;
            MaxParcela = campanha.MaxParcela;
            MinInicioPag = campanha.MinInicioPag;
            MaxInicioPag = campanha.MaxInicioPag;
            MinParcelasPagas = campanha.MinParcelasPagas;
            MaxParcelasPagas = campanha.MaxParcelasPagas;
            MinDataNascimento = campanha.MinDataNascimento;
            ApenasNaoExportados = campanha.ApenasNaoExportados;
            MinCep = campanha.MinCep;
            MaxCep = campanha.MaxCep;
            CodigoBanco = campanha.CodigoBanco;
        }
    }
}