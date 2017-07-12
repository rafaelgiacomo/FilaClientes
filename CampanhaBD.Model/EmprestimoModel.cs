using System;

namespace CampanhaBD.Model
{
    public class EmprestimoModel
    {
        public int ClienteId { get; set; }

        public int NumBeneficio { get; set; }

        public int NumEmprestimo { get; set; }

        public float ValorParcela { get; set; }

        public int ParcelasNoContrato { get; set; }

        public int ParcelasPagas { get; set; }

        public float Saldo { get; set; }

        public DateTime InicioPagamento { get; set; }

        public int BancoId { get; set; }
    }
}
