
namespace CampanhaBD.Model
{
    public class BaseOriginalModel
    {
        #region Propriedades
        public int Id { get; set; }

        public string Descricao { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODAS_BASES";
        public const string COLUMN_ID = "Id";
        public const string COLUMN_DESCRICAO = "Descricao";
        #endregion

        public override string ToString()
        {
            return Descricao;
        }

    }
}
