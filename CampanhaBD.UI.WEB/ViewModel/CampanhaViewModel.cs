using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class CampanhaViewModel
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        public float MinParcela { get; set; }

        public float MaxParcela { get; set; }

        public string MinInicioPag { get; set; }

        public string MaxInicioPag { get; set; }

        public int MinParcelasPagas { get; set; }

        public int MaxParcelasPagas { get; set; }

        public DateTime MinDataNascimento { get; set; }

        public bool ApenasNaoExportados { get; set; }

        public string MinCep { get; set; }

        public string MaxCep { get; set; }

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