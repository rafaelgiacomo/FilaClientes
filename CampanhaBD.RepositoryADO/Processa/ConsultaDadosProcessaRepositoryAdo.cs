using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.RepositoryADO
{
    public class ConsultaDadosProcessaRepositoryAdo
    {
        private Context _context;
        public const string NOME_BASE_CONSULTA = "Consulta";
        public const string NOME_BASE_CRED9 = "CampanhaBD";

        public ConsultaDadosProcessaRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void InserirConsultaDados(ConsultaDadosProcessaModel consulta)
        {
            try
            {
                string[] parameters =
                {
                    ConsultaDadosProcessaModel.COLUMN_CONSULTA, ConsultaDadosProcessaModel.COLUMN_BENEFICIO,
                    ConsultaDadosProcessaModel.COLUMN_DATA_NASCIMENTO, ConsultaDadosProcessaModel.COLUMN_CPF,
                    ConsultaDadosProcessaModel.COLUMN_NOME
                };

                object[] values =
                {
                    consulta.Consulta, consulta.Beneficio, consulta.DataNascimento, consulta.Cpf, consulta.Nome
                };

                _context.MudarBase(NOME_BASE_CONSULTA);

                _context.ExecuteProcedureNoReturn(
                    ConsultaDadosProcessaModel.PROCEDURE_INSERT, parameters, values);
            }
            catch
            {
                throw;
            }
            finally
            {
                _context.MudarBase(NOME_BASE_CRED9);
            }
        }
    }
}
