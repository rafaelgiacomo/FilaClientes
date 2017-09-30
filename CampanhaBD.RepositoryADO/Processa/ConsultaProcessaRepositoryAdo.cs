using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.RepositoryADO
{
    public class ConsultaProcessaRepositoryAdo
    {
        private Context _context;
        public const string NOME_BASE_CONSULTA = "Consulta";
        public const string NOME_BASE_CRED9 = "CampanhaBD";

        public ConsultaProcessaRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void InserirConsulta(ConsultaProcessaModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    ConsultaProcessaModel.COLUMN_DESCRICAO, ConsultaProcessaModel.COLUMN_SAFRA_USUARIO,
                    ConsultaProcessaModel.COLUMN_SAFRA_SENHA
                };

                object[] values = 
                {
                    entidade.Descricao, entidade.SafraUsuario, entidade.SafraSenha
                };

                _context.MudarBase(NOME_BASE_CONSULTA);

                var reader = _context.ExecuteProcedureWithReturn(
                    ConsultaProcessaModel.PROCEDURE_INSERT, parameters, values);

                if (reader.Read())
                {
                    var ultimoId = reader[0].ToString();

                    if (!string.IsNullOrEmpty(ultimoId))
                        entidade.Consulta = Convert.ToInt32(ultimoId);
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                _context.MudarBase(NOME_BASE_CRED9);
            }
        }

        public List<ConsultaProcessaModel> ListarTodos()
        {
            try
            {
                List<ConsultaProcessaModel> lista = new List<ConsultaProcessaModel>();
                SqlDataReader reader = null;

                string[] parameters = { };
                object[] values = { };

                _context.MudarBase(NOME_BASE_CONSULTA);

                reader = _context.ExecuteProcedureWithReturn(
                    ConsultaProcessaModel.PROCEDURE_SELECT_ALL, parameters, values);

                while (reader.Read())
                {
                    var entidade = new ConsultaProcessaModel();
                    entidade.Consulta = Convert.ToInt32(reader[ConsultaProcessaModel.COLUMN_CONSULTA]);
                    entidade.Descricao = reader[ConsultaProcessaModel.COLUMN_DESCRICAO].ToString();
                    entidade.Data = reader[ConsultaProcessaModel.COLUMN_DATA].ToString();

                    lista.Add(entidade);
                }

                reader.Close();

                return lista;
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
