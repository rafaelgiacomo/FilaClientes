using System;

namespace CampanhaBD.Model
{
    public class Beneficio
    {
        public int Numero { get; set; }

        public int IdCliente { get; set; }

        public float Salario { get; set; }

        public DateTime DataCompetencia { get; set; }
    }
}
