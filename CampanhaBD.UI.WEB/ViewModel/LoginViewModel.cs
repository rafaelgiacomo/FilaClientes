using System.ComponentModel.DataAnnotations;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}