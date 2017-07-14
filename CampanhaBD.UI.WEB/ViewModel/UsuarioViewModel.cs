using System.ComponentModel.DataAnnotations;
using CampanhaBD.Model;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class UsuarioViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string ConfirmarSenha { get; set; }

        public string Empresa { get; set; }

        public UsuarioModel ParaUsuarioModel()
        {
            UsuarioModel usuario = new UsuarioModel()
            {
                Nome = this.Nome,
                Email = this.Email,
                Login = this.Login,
                Senha = this.Senha,
                Empresa = this.Empresa
            };
            return usuario;
        }
    }
}