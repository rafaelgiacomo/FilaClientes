using CampanhaBD.Model;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class AtualizarViewModel
    {
        [Required]
        public int LayoutArquivo { get; set; }

        [Display(Name = "Banco")]
        public SelectList ListaLayout { get; set; }

        public HttpPostedFileBase File { get; set; }

        public AtualizarViewModel()
        {
            ListaLayout = new SelectList(LayoutArquivoModel.GeraListaAtualizacao(), "Codigo", "Nome");
        }
    }
}