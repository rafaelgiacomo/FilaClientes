using System;
using System.Collections.Generic;

namespace CampanhaBD.Model
{
    public class FiltroModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public List<int> Bancos { get; set; }

        public List<int> Importacoes { get; set; }

        public List<int> BasesOriginais { get; set; }

        public List<int> TiposEmprestimos { get; set; }

        public List<int> Especies { get; set; }

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

        public string MinDataExpProcessa { get; set; }

        public string MaxDataExpProcessa { get; set; }

        public int MinParcelasContrato { get; set; }

        public int MaxParcelasContrato { get; set; }

        public int MinParcelasEmAberto { get; set; }

        public int MaxParcelasEmAberto { get; set; }

        public int MinParcelasPagas { get; set; }

        public int MaxParcelasPagas { get; set; }

        public string MinDataInicioPag { get; set; }

        public string MaxDataInicioPag { get; set; }

        public string MinDataFimPag { get; set; }

        public string MaxDataFimPag { get; set; }

        public string MinDataImportado { get; set; }

        public string MaxDataImportado { get; set; }

        public float MinBruto { get; set; }

        public float MaxBruto { get; set; }

        public float MinLiquido { get; set; }

        public float MaxLiquido { get; set; }

        public float Coeficiente { get; set; }

        public float MinValorEmprestimo { get; set; }

        public float MaxValorEmprestimo { get; set; }

        public bool NuncaExpProcessa { get; set; }

        public bool NuncaExpTelefone { get; set; }

        public bool NuncaTrabalhado { get; set; }

        public bool AtualizarDadosCliente { get; set; }

        public bool NaoImportarTipo { get; set; }

        public bool NaoImportarEspecie { get; set; }

        public int ResultadoImportacao { get; set; }

        public FiltroModel()
        {
            Bancos = new List<int>();
            Importacoes = new List<int>();
            BasesOriginais = new List<int>();
            TiposEmprestimos = new List<int>();
            Especies = new List<int>();
        }

    }
}
