using System.Collections.Generic;

namespace CampanhaBD.Model
{
    public class TabelaBaseModel
    {
        #region Propriedades
        public string Nome { get; set; }

        public List<string> Colunas { get; set; }
        #endregion

        #region Colunas e Procs
        public const string COLUMN_NOME_TABELA = "TABLE_NAME";
        #endregion

        public TabelaBaseModel()
        {
            Colunas = new List<string>();
        }

    }

}
