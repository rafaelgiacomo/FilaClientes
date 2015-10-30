using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class CampanhaRepositoryAdo
    {
        private Context _context;

        public CampanhaRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(Campanha entidade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Campanhas (Nome, DataCriacao, DataFinal, Status) ";
            strQuery += string.Format(" VALUES ('{0}','{1}', '{2}', '{3}') ",
                entidade.Nome, entidade.DataCriacao, entidade.DataFinal, entidade.Status);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Campanha entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Campanhas SET ";
            strQuery += string.Format(" Nome = '{0}', ", entidade.Nome);
            strQuery += string.Format(" DataCriacao = '{0}', ", entidade.DataCriacao);
            strQuery += string.Format(" DataFinal = '{0}', ", entidade.DataFinal);
            strQuery += string.Format(" Status = '{0}' ", entidade.Status);
            strQuery += string.Format(" WHERE Id = '{0}' ", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Campanha entidade)
        {
            var strQuery = string.Format(" DELETE FROM Campanhas WHERE Id = {0}", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Campanha> ListarTodos()
        {
            var strQuery = " SELECT * FROM Campanhas ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Campanha ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Campanhas WHERE Id = {0} ", id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<Campanha> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Campanha>();
            while (reader.Read())
            {
                var temObjeto = new Campanha()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    DataCriacao = DateTime.Parse(reader["DataCriacao"].ToString()),
                    DataFinal = DateTime.Parse(reader["DataCriacao"].ToString()),
                    Status = int.Parse(reader["Status"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}
