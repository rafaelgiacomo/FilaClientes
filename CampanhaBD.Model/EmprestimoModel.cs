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

        public int ParcelasEmAberto { get; set; }

        public float Saldo { get; set; }

        public string InicioPagamento { get; set; }

        public int BancoId { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_EMPRESTIMO";
        public const string PROCEDURE_INSERT_PROCESSA = "SP_SALVAR_EMPRESTIMO_PROCESSA";
        public const string PROCEDURE_UPDATE = "SP_ALTERAR_EMPRESTIMO";
        public const string PROCEDURE_DELETE = "SP_EXCLUIR_EMPRESTIMO";
        public const string PROCEDURE_DELETE_BENEFICIO = "SP_EXCLUIR_EMPRESTIMO_BENEFICIO";
        public const string PROCEDURE_DELETE_CLIENTE = "SP_EXCLUIR_EMPRESTIMO_CLIENTE";
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODOS_EMPRESTIMOS";
        public const string PROCEDURE_SELECT_BY_ID = "SP_SELECIONAR_EMPRESTIMO_ID";
        public const string PROCEDURE_SELECT_BY_CLIENTE_ID = "SP_SELECIONAR_EMPRESTIMOS_CLIENTE_ID";
        public const string COLUMN_BANCO_ID = "BancoId";
        public const string COLUMN_CLIENTE_ID = "ClienteId";
        public const string COLUMN_NUM_BENEFICIO = "NumBeneficio";
        public const string COLUMN_NUM_EMPRESTIMO = "NumEmprestimo";
        public const string COLUMN_VALOR_PARCELA = "ValorParcela";
        public const string COLUMN_PARCELAS_NO_CONTRATO = "ParcelasNoContrato";
        public const string COLUMN_PARCELAS_EM_ABERTO = "ParcelasEmAberto";
        public const string COLUMN_SALDO = "Saldo";
        public const string COLUMN_INICIO_PAGAMENTO = "InicioPagamento";
        #endregion

    }
}
