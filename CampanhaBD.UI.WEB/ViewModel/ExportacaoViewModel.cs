﻿using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class ExportacaoViewModel
    {
        #region Propriedades
        [Required(ErrorMessage = "Digite um nome para a exportação")]
        [Display(Name = "Nome da Exportação")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Escolha um banco para a exportação")]
        [Display(Name = "Banco")]
        public int CodigoBanco { get; set; }

        [Display(Name = "Min Data Nascimento")]
        public string MinDataNascimento { get; set; }

        [Display(Name = "Max Data Nascimento")]
        public string MaxDataNascimento { get; set; }

        [Display(Name = "Min CEP")]
        public string MinCep { get; set; }

        [Display(Name = "Max CEP")]
        public string MaxCep { get; set; }

        [Display(Name = "Min Valor Parcela")]
        public float MinParcela { get; set; }

        [Display(Name = "Max Valor Parcela")]
        public float MaxParcela { get; set; }

        [Display(Name = "Min Data Emprestimos Atualizados")]
        public string MinDataAtualEmp { get; set; }

        [Display(Name = "Min Data Emprestimos Atualizados")]
        public string MaxDataAtualEmp { get; set; }

        [Display(Name = "Min Data Telefone Atualizado")]
        public string MinDataAtualTel { get; set; }

        [Display(Name = "Max Data Telefone Atualizado")]
        public string MaxDataAtualTel { get; set; }

        [Display(Name = "Min Data Trabalhado")]
        public string MinDataTrabalhado { get; set; }

        [Display(Name = "Max Data Trabalhado")]
        public string MaxDataTrabalhado { get; set; }

        [Display(Name = "Min Qtd Parcelas Aberto")]
        public int MinParcelasEmAberto { get; set; }

        [Display(Name = "Max Qtd Parcelas Aberto")]
        public int MaxParcelasEmAberto { get; set; }

        [Display(Name = "Min Data Inicio Pagamento")]
        public string MinDataInicioPag { get; set; }

        [Display(Name = "Max Data Inicio Pagamento")]
        public string MaxDataInicioPag { get; set; }

        [Display(Name = "Layout da Planilha")]
        public int LayoutArquivo { get; set; }

        [Display(Name = "Min Valor Bruto")]
        public float MinBruto { get; set; }

        [Display(Name = "Max Valor Bruto")]
        public float MaxBruto { get; set; }

        [Display(Name = "Min Valor Liquido")]
        public float MinLiquido { get; set; }

        [Display(Name = "Max Valor Liquido")]
        public float MaxLiquido { get; set; }

        [Display(Name = "Coeficiente")]
        public float Coeficiente { get; set; }

        public string Submit { get; set; }

        [Display(Name = "Banco")]
        public SelectList ListaBanco { get; set; }

        [Display(Name = "Banco")]
        public SelectList ListaLayout { get; set; }
        #endregion

        public ExportacaoViewModel()
        {

        }

        public ExportacaoViewModel(List<BancoModel> listaBanco)
        {
            try
            {
                ListaLayout = new SelectList(LayoutArquivoModel.GeraLista(), "Codigo", "Nome");
                ListaBanco = new SelectList(listaBanco, BancoModel.COLUMN_CODIGO, BancoModel.COLUMN_NOME);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CampanhaModel ViewModelParaCampanha()
        {
            try
            {
                CampanhaModel campanha = new CampanhaModel();

                campanha.Nome = Nome;
                campanha.CodigoBanco = CodigoBanco;
                campanha.MinDataNascimento = MinDataNascimento;
                campanha.MaxDataNascimento = MaxDataNascimento;
                campanha.MinCep = MinCep;
                campanha.MaxCep = MaxCep;
                campanha.MinParcela = MinParcela;
                campanha.MaxParcela = MaxParcela;
                campanha.MinDataAtualEmp = MinDataAtualEmp;
                campanha.MaxDataAtualEmp = MaxDataAtualEmp;
                campanha.MinDataAtualTel = MinDataAtualTel;
                campanha.MaxDataAtualTel = MaxDataAtualTel;
                campanha.MinDataTrabalhado = MinDataTrabalhado;
                campanha.MaxDataTrabalhado = MaxDataTrabalhado;
                campanha.MinParcelasEmAberto = MinParcelasEmAberto;
                campanha.MaxParcelasEmAberto = MaxParcelasEmAberto;
                campanha.MinDataInicioPag = MinDataInicioPag;
                campanha.MaxDataInicioPag = MaxDataInicioPag;
                campanha.MinBruto = MinBruto;
                campanha.MaxBruto = MaxBruto;
                campanha.MinLiquido = MinLiquido;
                campanha.MaxLiquido = MaxLiquido;
                campanha.Coeficiente = Coeficiente;

                return campanha;

            } catch(Exception)
            {
                throw;
            }
        }

    }
}