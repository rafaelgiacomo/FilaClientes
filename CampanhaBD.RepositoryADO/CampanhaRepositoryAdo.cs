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
            strQuery += " INSERT INTO Campanhas (nome, dataCriacao, dataFinal, status) ";
            strQuery += string.Format(" VALUES ('{0}','{1}', '{2}', '{3}') ",
                entidade.Nome, entidade.DataCriacao, entidade.DataFinal, entidade.Status);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Campanha entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Campanhas SET ";
            strQuery += string.Format(" nome = '{0}', ", entidade.Nome);
            strQuery += string.Format(" dataCriacao = '{0}', ", entidade.DataCriacao);
            strQuery += string.Format(" dataFinal = '{0}', ", entidade.DataFinal);
            strQuery += string.Format(" status = '{0}' ", entidade.Status);
            strQuery += string.Format(" WHERE cam_id = '{0}' AND pessoa_id = '{1}'", entidade.Id, entidade.UsuarioId);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Campanha entidade)
        {
            var strQuery = string.Format(" DELETE FROM Campanhas WHERE cam_id = {0} AND pessoa_id = '{1}'", entidade.Id, entidade.UsuarioId);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Campanha> ListarTodos()
        {
            var strQuery = " SELECT * FROM Campanhas ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Campanha ListarPorId(string id, string usuarioId)
        {
            var strQuery = string.Format(" SELECT * FROM Campanhas WHERE cam_id = {0} AND pessoa_id = '{1}' ", id, usuarioId);
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
                    Id = int.Parse(reader["cam_id"].ToString()),
                    UsuarioId = int.Parse(reader["pessoa_id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    DataCriacao = DateTime.Parse(reader["dataCriacao"].ToString()),
                    DataFinal = DateTime.Parse(reader["dataCriacao"].ToString()),
                    Status = int.Parse(reader["status"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}
