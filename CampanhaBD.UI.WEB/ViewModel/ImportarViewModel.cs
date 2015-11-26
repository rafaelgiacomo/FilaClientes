using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class ImportarViewModel
    {
        [Required]
        public string Nome { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}