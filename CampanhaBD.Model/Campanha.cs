using System;

namespace CampanhaBD.Model
{
    public class Campanha
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataFinal { get; set; }

        public int Status { get; set; }
    }
}
