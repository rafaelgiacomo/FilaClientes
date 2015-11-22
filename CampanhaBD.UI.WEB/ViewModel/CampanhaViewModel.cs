using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class CampanhaViewModel
    {
        [Required]
        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        [Required]
        public DateTime DataFinal { get; set; }

        [Required]
        public int Status { get; set; }
    }
}