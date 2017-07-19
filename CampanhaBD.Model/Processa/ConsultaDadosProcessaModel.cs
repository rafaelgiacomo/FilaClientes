using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Model
{
    public class ConsultaDadosProcessaModel
    {
        #region Propriedades
        public int Consulta { get; set; }

        public string Beneficio { get; set; }

        public string DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_CONSULTA_DADOS";
        public const string PROCEDURE_SELECT_BY_CONSULTA = "SP_LISTAR_CONSULTA_ID";
        public const string COLUMN_CONSULTA = "Consulta";
        public const string COLUMN_BENEFICIO = "Beneficio";
        public const string COLUMN_DATA_NASCIMENTO = "DataNascimento";
        public const string COLUMN_CPF = "Cpf";
        public const string COLUMN_NOME = "Nome";
        #endregion
    }
}
