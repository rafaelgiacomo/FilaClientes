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
            strQuery += " INSERT INTO Importacoes (Nome, Data, Terminado, NumImportados, NumAtualizados) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}') ",
                entidade.Nome, entidade.Data, entidade.Terminado, entidade.NumImportados, entidade.NumAtualizados);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Importacao entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Importacoes SET ";
            strQuery += string.Format(" Nome = '{0}', ", entidade.Nome);
            strQuery += string.Format(" Data = '{0}', ", entidade.Data);
            strQuery += string.Format(" Terminado = '{0}', ", entidade.Terminado);
            strQuery += string.Format(" NumImportados = '{0}', ", entidade.NumImportados);
            strQuery += string.Format(" NumAtualizados = '{0}' ", entidade.NumAtualizados);
            strQuery += string.Format(" WHERE Id = {0} ", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Importacao entidade)
        {
            var strQuery = string.Format(" DELETE FROM Importacoes WHERE Id = {0}", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Importacao> ListarTodos()
        {
            var strQuery = " SELECT * FROM Importacoes ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Importacao ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Importacoes WHERE Id = {0} ", id);
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
                    Id = int.Parse(reader["Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Data = DateTime.Parse(reader["DataNascimento"].ToString()),
                    NumImportados = int.Parse(reader["NumImportados"].ToString()),
                    NumAtualizados = int.Parse(reader["NumAtualizados"].ToString()),
                    Terminado = bool.Parse(reader["Terminado"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}
