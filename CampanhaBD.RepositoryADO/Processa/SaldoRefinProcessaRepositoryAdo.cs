using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.RepositoryADO
{
    public class SaldoRefinProcessaRepositoryAdo
    {
        private Context _context;
        public const string NOME_BASE_CONSULTA = "Consulta";
        public const string NOME_BASE_CRED9 = "CampanhaBD";

        public SaldoRefinProcessaRepositoryAdo(Context context)
        {
            _context = context;
        }

        public List<SaldoRefinProcessaModel> ListarEmprestimosDeConsulta(SaldoRefinProcessaModel saldoRefin)
        {
            try
            {
                List<SaldoRefinProcessaModel> lista = new List<SaldoRefinProcessaModel>();
                SqlDataReader reader = null;

                string[] parameters = { };
                object[] values = { };

                _context.MudarBase(NOME_BASE_CONSULTA);

                reader = _context.ExecuteProcedureWithReturn(
                    SaldoRefinProcessaModel.PROCEDURE_SELECT_BY_CONSULTA, parameters, values);

                while (reader.Read())
                {
                    var entidade = new SaldoRefinProcessaModel();
                    entidade.Consulta = Convert.ToInt32(reader[SaldoRefinProcessaModel.COLUMN_CONSULTA]);
                    entidade.Cpf = reader[SaldoRefinProcessaModel.COLUMN_CPF].ToString();
                    entidade.CodigoBanco = reader[SaldoRefinProcessaModel.COLUMN_CODIGO_BANCO].ToString();
                    entidade.Matricula = reader[SaldoRefinProcessaModel.COLUMN_MATRICULA].ToString();
                    entidade.DataConsulta = reader[SaldoRefinProcessaModel.COLUMN_DATA_CONSULTA].ToString();
                    entidade.ParcelasContrato = int.Parse(reader[SaldoRefinProcessaModel.COLUMN_PARCELAS_CONTRATO].ToString());
                    entidade.ParcelasAberto = int.Parse(reader[SaldoRefinProcessaModel.COLUMN_PARCELAS_ABERTO].ToString());
                    entidade.ParcelasRefin = int.Parse(reader[SaldoRefinProcessaModel.COLUMN_PARCELAS_REFIN].ToString());
                    entidade.ValorContrato = float.Parse(reader[SaldoRefinProcessaModel.COLUMN_VALOR_CONTRATO].ToString());
                    entidade.ValorParcela = float.Parse(reader[SaldoRefinProcessaModel.COLUMN_VALOR_PARCELA].ToString());
                    entidade.SaldoContrato = float.Parse(reader[SaldoRefinProcessaModel.COLUMN_SALDO_CONTRATO].ToString());
                    entidade.SaldoRefin = float.Parse(reader[SaldoRefinProcessaModel.COLUMN_SALDO_REFIN].ToString());
                    entidade.Status = reader[SaldoRefinProcessaModel.COLUMN_STATUS].ToString();
                    entidade.Ok = reader[SaldoRefinProcessaModel.COLUMN_OK].ToString();

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
