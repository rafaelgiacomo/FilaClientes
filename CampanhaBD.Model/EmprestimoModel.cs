using System;

namespace CampanhaBD.Model
{
    public class EmprestimoModel
    {
        #region Propriedades
        public long ClienteId { get; set; }

        public long NumBeneficio { get; set; }

        public int NumEmprestimo { get; set; }

        public float ValorParcela { get; set; }

        public int ParcelasNoContrato { get; set; }

        public int ParcelasPagas { get; set; }

        public float Saldo { get; set; }

        public DateTime InicioPagamento { get; set; }

        public int BancoId { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_EMPRESTIMO";
        public const string PROCEDURE_UPDATE = "SP_ALTERAR_EMPRESTIMO";
        public const string PROCEDURE_DELETE = "SP_EXCLUIR_EMPRESTIMO";
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODOS_EMPRESTIMOS";
        public const string PROCEDURE_SELECT_BY_ID = "SP_SELECIONAR_EMPRESTIMO_ID";
        public const string PROCEDURE_SELECT_BY_CLIENTE_ID = "SP_SELECIONAR_EMPRESTIMOS_CLIENTE_ID";
        public const string COLUMN_NUMERO = "Codigo";
        public const string COLUMN_CLIENTE_ID = "Nome";
        public const string COLUMN_SALARIO = "Salario";
        public const string COLUMN_DATA_COMPETENCIA = "DataCompetencia";
        #endregion
    }
}
