using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CampanhaBD.RepositoryADO
{   
    public class Context : IDisposable
    {
        private readonly SqlConnection _mySqlConnection;

        public Context()
        {
            _mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CampanhaBD"].ConnectionString);
            _mySqlConnection.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = _mySqlConnection
            };
            cmdComando.ExecuteNonQuery();
        }

        public String ExecutaScalar(string strQuery)
        {
            var cmdComando = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = _mySqlConnection
            };
            return cmdComando.ExecuteScalar().ToString();
        }

        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, _mySqlConnection);
            return cmdComando.ExecuteReader();
        }

        public void Dispose()
        {
            if (_mySqlConnection.State == ConnectionState.Open)
                _mySqlConnection.Close();
        }
    }
}
