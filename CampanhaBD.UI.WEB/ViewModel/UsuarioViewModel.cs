using System.ComponentModel.DataAnnotations;
using CampanhaBD.Model;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class UsuarioViewModel
    {
        [Required]
        public string Cpf { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string ConfirmarSenha { get; set; }

        public string Empresa { get; set; }

        public Usuario ParaUsuarioModel()
        {
            Usuario usuario = new Usuario()
            {
                Cpf = this.Cpf,
                Nome = this.Nome,
                Login = this.Login,
                Senha = this.Senha,
                Empresa = this.Empresa
            };
            return usuario;
        }
    }
}