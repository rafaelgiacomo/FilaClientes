using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Model
{
    public class SaldoRefinProcessaModel
    {
        #region Propriedades
        public int Consulta { get; set; }

        public string Cpf { get; set; }

        public string Tipo { get; set; }

        public string Banco { get; set; }

        public string CodigoBanco { get; set; }

        public string NomeBanco { get; set; }

        public string Contrato { get; set; }

        public string DataConsulta { get; set; }

        public string Matricula { get; set; }

        public string Convenio { get; set; }

        public string TaxaContrato { get; set; }

        public string DataContrato { get; set; }

        public string DataProximoVencimento { get; set; }

        public string DataPrimeiroVencimento { get; set; }

        public int ParcelasContrato { get; set; }

        public int ParcelasAberto { get; set; }

        public int ParcelasRefin { get; set; }

        public float PercentualPago { get; set; }

        public float ValorContrato { get; set; }

        public float ValorParcela { get; set; }

        public float SaldoContrato { get; set; }

        public float SaldoRefin { get; set; }

        public string Status { get; set; }

        public string Ok { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_SELECT_BY_CONSULTA = "SP_LISTAR_EMPRESTIMOS_CONSULTA";
        public const string COLUMN_CONSULTA = "Consulta";
        public const string COLUMN_CPF = "CPF";
        public const string COLUMN_TIPO = "Tipo";
        public const string COLUMN_BANCO = "Banco";
        public const string COLUMN_CODIGO_BANCO = "Codigo_Banco";
        public const string COLUMN_NOME_BANCO = "Nome_Banco";
        public const string COLUMN_CONTRATO = "Contrato";
        public const string COLUMN_DATA_CONSULTA = "Data_Consulta";
        public const string COLUMN_MATRICULA = "Matricula";
        public const string COLUMN_CONVENIO = "Convenio";
        public const string COLUMN_TAXA_CONTRATO = "Taxa_Contrato";
        public const string COLUMN_DATA_CONTRATO = "Data_Contrato";
        public const string COLUMN_DATA_PROX_VENCIMENTO = "Data_Proximo_Vencimento";
        public const string COLUMN_DATA_PRIM_VENCIMENTO = "Data_Primeiro_Vencimento";
        public const string COLUMN_PARCELAS_CONTRATO = "Parcelas_Contrato";
        public const string COLUMN_PARCELAS_ABERTO = "Parcelas_Aberto";
        public const string COLUMN_PARCELAS_REFIN = "Parcelas_Refin";
        public const string COLUMN_PERCENTUAL_PAGO = "Percentual_Pago";
        public const string COLUMN_VALOR_CONTRATO = "Valor_Contrato";
        public const string COLUMN_VALOR_PARCELA = "Valor_Parcela";
        public const string COLUMN_SALDO_CONTRATO = "Saldo_Contrato";
        public const string COLUMN_SALDO_REFIN = "Saldo_Refin";
        public const string COLUMN_STATUS = "Status";
        public const string COLUMN_OK = "OK";
        #endregion
    }
}
