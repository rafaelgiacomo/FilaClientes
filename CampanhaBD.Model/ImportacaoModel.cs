using System;

namespace CampanhaBD.Model
{
    public class ImportacaoModel
    {
        #region Propriedades
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public DateTime Data { get; set; }

        public bool Terminado { get; set; }

        public int NumImportados { get; set; }

        public int NumAtualizados { get; set; }

        public string CaminhoArquivo { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_IMPORTACAO";
        public const string PROCEDURE_UPDATE = "SP_ALTERAR_IMPORTACAO";
        public const string PROCEDURE_UPDATE_CAMINHO = "SP_SALVAR_CAMINHO_IMPORTACAO";
        public const string PROCEDURE_DELETE = "SP_EXCLUIR_IMPORTACAO";
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODOS_IMPORTACOES";
        public const string PROCEDURE_SELECT_BY_ID = "SP_SELECIONAR_IMPORTACAO_ID";
        public const string PROCEDURE_SELECT_BY_NOME = "SP_SELECIONAR_IMPORTACAO_NOME";
        public const string PROCEDURE_TERMINAR = "SP_TERMINAR_IMPORTACAO";
        public const string COLUMN_ID = "Id";
        public const string COLUMN_USUARIO_ID = "UsuarioId";
        public const string COLUMN_NOME = "Nome";
        public const string COLUMN_DATA = "Data";
        public const string COLUMN_TERMINADO = "Terminado";
        public const string COLUMN_NUM_IMPORTADOS = "NumImportados";
        public const string COLUMN_NUM_ATUALIZADOS = "NumAtualizados";
        public const string COLUMN_CAMINHO_ARQUIVO = "CaminhoArquivo";
        #endregion
    }
}
