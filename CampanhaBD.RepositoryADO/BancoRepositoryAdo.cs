using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;
using System;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class BancoRepositoryAdo : IRepository<BancoModel>
    {
        private Context _context;

        public BancoRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(BancoModel entidade)
        {
            try
            {
                string[] parameters = { BancoModel.COLUMN_NOME };

                object[] values = { entidade.Nome };

                _context.ExecuteProcedureNoReturn(
                    BancoModel.PROCEDURE_INSERT, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void Alterar(BancoModel entidade)
        {
            try
            {
                string[] parameters = { BancoModel.COLUMN_CODIGO, BancoModel.COLUMN_NOME };

                object[] values = { entidade.Codigo, entidade.Nome };

                _context.ExecuteProcedureNoReturn(
                    BancoModel.PROCEDURE_UPDATE, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void Excluir(BancoModel entidade)
        {
            try
            {
                string[] parameters = { BancoModel.COLUMN_CODIGO };
                object[] values = { entidade.Codigo };

                _context.ExecuteProcedureNoReturn(
                    BancoModel.PROCEDURE_DELETE, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public List<BancoModel> ListarTodos()
        {
            try
            {
                List<BancoModel> lista = new List<BancoModel>();
                SqlDataReader reader = null;

                string[] parameters = { };
                object[] values = { };

                reader = _context.ExecuteProcedureWithReturn(
                    BancoModel.PROCEDURE_SELECT_ALL, parameters, values);

                while (reader.Read())
                {
                    var entidade = new BancoModel();
                    entidade.Codigo = Convert.ToInt32(reader[BancoModel.COLUMN_CODIGO]);
                    entidade.Nome = reader[BancoModel.COLUMN_NOME].ToString();

                    lista.Add(entidade);
                }

                reader.Close();

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public BancoModel ListarPorId(BancoModel entidade)
        {
            try
            {
                SqlDataReader reader = null;
                var retorno = new BancoModel();

                string[] parameters = { BancoModel.COLUMN_CODIGO };
                object[] values = { BancoModel.COLUMN_CODIGO };

                reader = _context.ExecuteProcedureWithReturn(
                    BancoModel.PROCEDURE_SELECT_BY_ID, parameters, values);

                if (reader.Read())
                {
                    retorno.Codigo = Convert.ToInt32(reader[BancoModel.COLUMN_CODIGO].ToString());
                    retorno.Nome = reader[BancoModel.COLUMN_NOME].ToString();
                }

                reader.Close();

                return retorno;
            }
            catch
            {
                throw;
            }
        }

        private List<BancoModel> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var lista = new List<BancoModel>();
            while (reader.Read())
            {
                var temObjeto = new BancoModel()
                {
                    Codigo = int.Parse(reader["Codigo"].ToString()),
                    Nome = reader["Nome"].ToString()
                };
                lista.Add(temObjeto);
            }
            reader.Close();
            return lista;
        }
    
    }
}
