using CampanhaBD.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class AtualizarViewModel
    {
        public int LayoutArquivo { get; set; }

        public int ConsultaProcessa { get; set; }

        [Display(Name = "Layout da Planilha")]
        public SelectList ListaLayout { get; set; }

        [Display(Name = "Consulta do Processa")]
        public SelectList ListaConsulta { get; set; }

        public HttpPostedFileBase File { get; set; }

        public string Submit { get; set; }

        public AtualizarViewModel()
        {

        }

        public AtualizarViewModel(List<ConsultaProcessaModel> listaConsultasProcessa)
        {
            ListaLayout = new SelectList(LayoutArquivoModel.GeraListaAtualizacao(), "Codigo", "Nome");
            ListaConsulta = new SelectList(listaConsultasProcessa, "Consulta", "Descricao");
        }
    }
}