using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class BeneficioRepositoryAdo
    {
        private Context _context;

        public BeneficioRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(Beneficio entidade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Beneficios (Numero, ClienteId, Salario, DataCompetencia) ";
            strQuery += string.Format(" VALUES ('{0}','{1}', '{2}', '{3}') ",
                entidade.Numero, entidade.IdCliente, entidade.Salario, entidade.DataCompetencia);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Beneficio entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Beneficios SET ";
            strQuery += string.Format(" Salario = '{0}', ", entidade.Salario);
            strQuery += string.Format(" DataCompetencia = '{0}' ", entidade.DataCompetencia);
            strQuery += string.Format(" WHERE Numero = '{0}' AND ClienteId = '{1}' ", entidade.Numero, 
                entidade.DataCompetencia);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Beneficio entidade)
        {
            var strQuery = string.Format(" DELETE FROM Usuarios WHERE Numero = '{0}' AND ClienteId = '{1}' ", entidade.Numero,
                entidade.DataCompetencia);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Beneficio> ListarTodos()
        {
            var strQuery = " SELECT * FROM Beneficios ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Beneficio ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Usuarios WHERE Id = {0} ", id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<Beneficio> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Beneficio>();
            while (reader.Read())
            {
                var temObjeto = new Beneficio()
                {
                    Numero = int.Parse(reader["Id"].ToString()),
                    IdCliente = int.Parse(reader["ClienteId"].ToString()),
                    Salario = float.Parse(reader["Salario"].ToString()),
                    DataCompetencia = DateTime.Parse(reader["Empresa"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }

    }
}
