using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class ImportacaoRepositoryAdo
    {
        private Context _context;

        public ImportacaoRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(Importacao entidade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Importacao (nome, data, terminado, numImportados, atualizados) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}') ",
                entidade.Nome, entidade.Data, entidade.Terminado, entidade.NumImportados, entidade.NumAtualizados);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Importacao entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Importacao SET ";
            strQuery += string.Format(" nome = '{0}', ", entidade.Nome);
            strQuery += string.Format(" data = '{0}', ", entidade.Data);
            strQuery += string.Format(" terminado = '{0}', ", entidade.Terminado);
            strQuery += string.Format(" numImportados = '{0}', ", entidade.NumImportados);
            strQuery += string.Format(" atualizados = '{0}' ", entidade.NumAtualizados);
            strQuery += string.Format(" WHERE imp_id = '{0}' AND pessoa_id = '{1}' ", entidade.Id, entidade.ClienteId);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Importacao entidade)
        {
            var strQuery = string.Format(" DELETE FROM Importacao WHERE imp_id = '{0}' AND pessoa_id = '{1}' ", entidade.Id, entidade.ClienteId);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Importacao> ListarTodos()
        {
            var strQuery = " SELECT * FROM Importacao ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Importacao ListarPorId(string id, string clienteId)
        {
            var strQuery = string.Format(" SELECT * FROM Importacao WHERE imp_id = '{0}' AND pessoa_id = '{1}' ", id, clienteId);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<Importacao> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Importacao>();
            while (reader.Read())
            {
                var temObjeto = new Importacao()
                {
                    Id = int.Parse(reader["imp_id"].ToString()),
                    ClienteId = int.Parse(reader["pessoa_id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Data = DateTime.Parse(reader["data"].ToString()),
                    Terminado = bool.Parse(reader["Terminado"].ToString()),
                    NumImportados = int.Parse(reader["numImportados"].ToString()),
                    NumAtualizados = int.Parse(reader["atualizados"].ToString()),
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}
