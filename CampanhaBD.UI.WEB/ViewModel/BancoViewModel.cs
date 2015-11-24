using CampanhaBD.Model;
using System.ComponentModel.DataAnnotations;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class BancoViewModel
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        public string Nome { get; set; }

        public Banco ParaBancoModel()
        {
            Banco banco = new Banco()
            {
                Nome = this.Nome,
                Codigo = this.Codigo
            };
            return banco;
        }

        public void ParaViewModel(Banco banco)
        {
            Codigo = banco.Codigo;
            Nome = banco.Nome;
        }
    }
}