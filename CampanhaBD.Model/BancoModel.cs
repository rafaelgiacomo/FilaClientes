namespace CampanhaBD.Model
{
    public class BancoModel
    {
        #region Propriedades
        public int Codigo { get; set; }

        public string Nome { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_BANCO";
        public const string PROCEDURE_UPDATE = "SP_ALTERAR_BANCO";
        public const string PROCEDURE_DELETE = "SP_EXCLUIR_BANCO";
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODOS_BANCOS";
        public const string PROCEDURE_SELECT_BY_ID = "SP_SELECIONAR_BANCO_ID";
        public const string COLUMN_CODIGO = "Codigo";
        public const string COLUMN_NOME = "Nome";
        #endregion

        public override string ToString()
        {
            return (string.Concat(Codigo, " - ", Nome));
        }
    }
}
