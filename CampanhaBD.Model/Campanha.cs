using System;

namespace CampanhaBD.Model
{
    public class Campanha
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

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
    }
}
