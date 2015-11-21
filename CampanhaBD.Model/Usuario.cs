namespace CampanhaBD.Model
{
    public class Usuario : Pessoa
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Empresa { get; set; }
    }
}
