using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Model
{
    public class ConsultaProcessa
    {
        #region Propriedades
        public int Consulta { get; set; }

        public string Descricao { get; set; }

        public string Data { get; set; }

        public string Integracao { get; set; }

        public string SafraUsuario { get; set; }

        public string SafraSenha { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_CONSULTA";
        public const string PROCEDURE_UPDATE = "SP_ALTERAR_CONSULTA";
        public const string PROCEDURE_DELETE = "SP_EXCLUIR_CONSULTA";
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODOS_CONSULTAS";
        public const string PROCEDURE_SELECT_BY_ID = "SP_SELECIONAR_CONSULTA_ID";
        public const string COLUMN_CONSULTA = "Consulta";
        public const string COLUMN_DESCRICAO = "Descricao";
        public const string COLUMN_DATA = "Data";
        public const string COLUMN_INTEGRACAO = "Integracao";
        public const string COLUMN_SAFRA_USUARIO = "SAFRA_Usuario";
        public const string COLUMN_SAFRA_SENHA = "SAFRA_Senha";
        #endregion
    }
}
