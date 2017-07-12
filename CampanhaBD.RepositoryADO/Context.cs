using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CampanhaBD.RepositoryADO
{   
    public class Context : IDisposable
    {
        private readonly SqlConnection myConnection;

        public Context(string conString)
        {
            try
            {
                myConnection = new SqlConnection(conString);
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader ExecuteProcedureWithReturn(
            string procedureName, string[] parameters, params object[] values)
        {
            try
            {
                SqlDataReader reader = null;



                var cmdComando = new SqlCommand
                {
                    CommandText = procedureName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection,
                };

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmdComando.Parameters.AddWithValue(parameters[i], values[i]);
                }

                reader = cmdComando.ExecuteReader();

                return reader;
            }
            catch
            {
                throw;
            }
        }

        public void ExecuteProcedureNoReturn(string procedureName,
            string[] parameters, params object[] values)
        {
            SqlTransaction tran = myConnection.BeginTransaction();

            try
            {
                var cmdComando = new SqlCommand
                {
                    CommandText = procedureName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = myConnection,
                    Transaction = tran
                };

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmdComando.Parameters.AddWithValue(parameters[i], values[i]);
                }

                cmdComando.ExecuteNonQuery();
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public void ExecuteSqlCommandNoReturn(string command)
        {
            SqlTransaction tran = myConnection.BeginTransaction();

            try
            {
                var cmdComando = new SqlCommand
                {
                    CommandText = command,
                    CommandType = CommandType.Text,
                    Connection = myConnection,
                    Transaction = tran
                };

                cmdComando.ExecuteNonQuery();
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public void AbrirConexao()
        {
            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }
        }

        public void FecharConexao()
        {
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
        }

        public void Dispose()
        {
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
        }
    }
}
