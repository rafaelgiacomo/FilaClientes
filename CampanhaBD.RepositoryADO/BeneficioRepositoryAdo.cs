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
                    BeneficioModel.COLUMN_DATA_COMPETENCIA
                };

                object[] values = { entidade.Numero, entidade.IdCliente, entidade.Salario, entidade.DataCompetencia };

                _context.ExecuteProcedureNoReturn(
                    BeneficioModel.PROCEDURE_INSERT, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void Alterar(BeneficioModel entidade)
        {

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

                string[] parameters = { ClienteModel.COLUMN_ID };
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
                temObjeto.Numero = long.Parse(reader["Numero"].ToString());
                temObjeto.IdCliente = long.Parse(reader["ClienteId"].ToString());
                temObjeto.Salario = float.Parse(reader["Salario"].ToString());
                temObjeto.DataCompetencia = DateTime.Parse(reader["DataCompetencia"].ToString());

                return temObjeto;
            }
            catch
            {
                throw;
            }    
        }

    }
}
