using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class BeneficioRepositoryAdo : IRepository<BeneficioModel>
    {
        private Context _context;

        public BeneficioRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(BeneficioModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    BeneficioModel.COLUMN_NUMERO, BeneficioModel.COLUMN_CLIENTE_ID, BeneficioModel.COLUMN_SALARIO,
                    BeneficioModel.COLUMN_DATA_COMPETENCIA, BeneficioModel.COLUMN_DATA_INICIO_BENEFICIO, 
                    BeneficioModel.COLUMN_BANCO_PAGAMENTO, BeneficioModel.COLUMN_AGENCIA_PAGAMENTO, 
                    BeneficioModel.COLUMN_ORGAO_PAGADOR, BeneficioModel.COLUMN_CONTA_CORRENTE,
                    BeneficioModel.COLUMN_ESPECIE
                };

                object[] values = {
                    entidade.Numero, entidade.IdCliente, entidade.Salario, entidade.DataCompetencia,
                    entidade.DataInicioBeneficio, entidade.BancoPagamento, entidade.AgenciaPagamento,
                    entidade.CodigoOrgaoPagador, entidade.ContaCorrente, entidade.Especie
                };

                _context.ExecuteProcedureNoReturn(
                    BeneficioModel.PROCEDURE_INSERT, parameters, values);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void Alterar(BeneficioModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    BeneficioModel.COLUMN_NUMERO, BeneficioModel.COLUMN_CLIENTE_ID, BeneficioModel.COLUMN_SALARIO,
                    BeneficioModel.COLUMN_DATA_INICIO_BENEFICIO,
                    BeneficioModel.COLUMN_BANCO_PAGAMENTO, BeneficioModel.COLUMN_AGENCIA_PAGAMENTO,
                    BeneficioModel.COLUMN_ORGAO_PAGADOR, BeneficioModel.COLUMN_CONTA_CORRENTE,
                    BeneficioModel.COLUMN_ESPECIE
                };

                object[] values = {
                    entidade.Numero, entidade.IdCliente, entidade.Salario,
                    entidade.DataInicioBeneficio, entidade.BancoPagamento, entidade.AgenciaPagamento,
                    entidade.CodigoOrgaoPagador, entidade.ContaCorrente, entidade.Especie
                };

                _context.ExecuteProcedureNoReturn(
                    BeneficioModel.PROCEDURE_UPDATE, parameters, values);
            }
            catch (Exception ex)
            {
                throw;
            }
        }       

        public void Excluir(BeneficioModel entidade)
        {

        }

        public List<BeneficioModel> ListarTodos()
        {
            return new List<BeneficioModel>();
        }

        public BeneficioModel ListarPorId(BeneficioModel entidade)
        {
            try
            {
                SqlDataReader reader = null;
                BeneficioModel retorno = null;

                string[] parameters = { BeneficioModel.COLUMN_NUMERO };
                object[] values = { entidade.Numero };

                reader = _context.ExecuteProcedureWithReturn(
                    BeneficioModel.PROCEDURE_SELECT_BY_ID, parameters, values);

                if (reader.Read())
                {
                    retorno = TransformaReaderEmListaDeObjeto(reader);
                }

                reader.Close();

                return retorno;
            }
            catch
            {
                throw;
            }
        }

        public List<BeneficioModel> ListarPorClienteId(long clienteId)
        {
            try
            {
                SqlDataReader reader = null;
                var retorno = new List<BeneficioModel>();

                string[] parameters = { BeneficioModel.COLUMN_CLIENTE_ID };
                object[] values = { clienteId };

                reader = _context.ExecuteProcedureWithReturn(
                    BeneficioModel.PROCEDURE_SELECT_BY_CLIENTE_ID, parameters, values);

                while (reader.Read())
                {
                    var ben = TransformaReaderEmListaDeObjeto(reader);
                    retorno.Add(ben);
                }

                reader.Close();

                return retorno;
            }
            catch
            {
                throw;
            }
        }

        private BeneficioModel TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            try
            {
                var temObjeto = new BeneficioModel();
                temObjeto.Numero = long.Parse(reader[BeneficioModel.COLUMN_NUMERO].ToString());
                temObjeto.IdCliente = long.Parse(reader[BeneficioModel.COLUMN_CLIENTE_ID].ToString());
                temObjeto.Salario = float.Parse(reader[BeneficioModel.COLUMN_SALARIO].ToString());
                temObjeto.DataCompetencia = DateTime.Parse(reader[BeneficioModel.COLUMN_DATA_COMPETENCIA].ToString());

                var especie = (reader[BeneficioModel.COLUMN_ESPECIE].ToString());
                var dataIncluido = (reader[BeneficioModel.COLUMN_ESPECIE].ToString());
                var DataExcluido = (reader[BeneficioModel.COLUMN_ESPECIE].ToString());

                return temObjeto;
            }
            catch
            {
                throw;
            }    
        }
    }
}
