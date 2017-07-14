using System;

namespace CampanhaBD.Model
{
    public class BeneficioModel
    {
        #region Propriedades
        public long Numero { get; set; }

        public long IdCliente { get; set; }

        public float Salario { get; set; }

        public DateTime DataCompetencia { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_BENEFICIO";
        public const string PROCEDURE_UPDATE = "SP_ALTERAR_BENEFICIO";
        public const string PROCEDURE_DELETE = "SP_EXCLUIR_BENEFICIO";
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODOS_BENEFICIOS";
        public const string PROCEDURE_SELECT_BY_ID = "SP_SELECIONAR_BENEFICIO_ID";
        public const string PROCEDURE_SELECT_BY_CLIENTE_ID = "SP_SELECIONAR_BENEFICIO_CLIENTE_ID";
        public const string COLUMN_NUMERO = "Numero";
        public const string COLUMN_CLIENTE_ID = "ClienteId";
        public const string COLUMN_SALARIO = "Salario";
        public const string COLUMN_DATA_COMPETENCIA = "DataCompetencia";
        #endregion
    }
}
