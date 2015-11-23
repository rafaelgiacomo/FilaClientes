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
            strQuery += " INSERT INTO Beneficio (numero, pessoa_id, salario, dataCompetencia) ";
            strQuery += string.Format(" VALUES ('{0}','{1}', '{2}', '{3}') ",
                entidade.Numero, entidade.IdCliente, entidade.Salario, entidade.DataCompetencia);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Beneficio entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Beneficio SET ";
            strQuery += string.Format(" salario = '{0}', ", entidade.Salario);
            strQuery += string.Format(" dataCompetencia = '{0}' ", entidade.DataCompetencia);
            strQuery += string.Format(" WHERE numero = '{0}' AND pessoa_id = '{1}' ", entidade.Numero, 
                entidade.DataCompetencia);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Beneficio entidade)
        {
            var strQuery = string.Format(" DELETE FROM Usuario WHERE numero = '{0}' AND pessoa_id = '{1}' ", entidade.Numero,
                entidade.DataCompetencia);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Beneficio> ListarTodos()
        {
            var strQuery = " SELECT * FROM Beneficio ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Beneficio ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Usuario WHERE pessoa_id = {0} ", id);
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
                    Numero = int.Parse(reader["numero"].ToString()),
                    IdCliente = int.Parse(reader["pessoa_id"].ToString()),
                    Salario = float.Parse(reader["salario"].ToString()),
                    DataCompetencia = DateTime.Parse(reader["dataCompetencia"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }

    }
}
