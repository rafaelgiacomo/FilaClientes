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

        public BancoModel ParaBancoModel()
        {
            BancoModel banco = new BancoModel()
            {
                Nome = this.Nome,
                Codigo = this.Codigo
            };
            return banco;
        }

        public void ParaViewModel(BancoModel banco)
        {
            Codigo = banco.Codigo;
            Nome = banco.Nome;
        }
    }
}