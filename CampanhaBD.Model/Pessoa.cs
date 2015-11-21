namespace CampanhaBD.Model
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Classificacao { get; set; }

        public static readonly int USUARIO = 0;

        public static readonly int CLIENTE = 1;
    }
}
