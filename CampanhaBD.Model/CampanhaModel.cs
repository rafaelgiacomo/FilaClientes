using System;
using System.Collections.Generic;

namespace CampanhaBD.Model
{
    public class CampanhaModel
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public int CodigoBanco { get; set; }

        public string MinDataNascimento { get; set; }

        public string MaxDataNascimento { get; set; }

        public string MinCep { get; set; }

        public string MaxCep { get; set; }

        public float MinParcela { get; set; }

        public float MaxParcela { get; set; }

        public string MinDataAtualEmp { get; set; }

        public string MaxDataAtualEmp { get; set; }

        public string MinDataAtualTel { get; set; }

        public string MaxDataAtualTel { get; set; }

        public string MinDataTrabalhado { get; set; }

        public string MaxDataTrabalhado { get; set; }

        public int MinParcelasContrato { get; set; }

        public int MaxParcelasContrato { get; set; }

        public int MinParcelasEmAberto { get; set; }

        public int MaxParcelasEmAberto { get; set; }

        public int MinParcelasPagas { get; set; }

        public int MaxParcelasPagas { get; set; }

        public string MinDataInicioPag { get; set; }

        public string MaxDataInicioPag { get; set; }

        public float MinBruto { get; set; }

        public float MaxBruto { get; set; }

        public float MinLiquido { get; set; }

        public float MaxLiquido { get; set; }

        public float Coeficiente { get; set; }

    }
}
