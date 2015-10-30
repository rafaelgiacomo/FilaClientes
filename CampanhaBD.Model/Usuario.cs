namespace CampanhaBD.Model
{
    public class Usuario : Pessoa
    {
        public string Login { get; set; }

        public string Senha { get; set; }

        public string Empresa { get; set; }
    }
}
