using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class ImportacaoRepositoryAdo : IRepository<ImportacaoModel>
    {
        private Context _context;

        public ImportacaoRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(ImportacaoModel entidade)
        {
            //entidade.Id = NumeroImportacao(entidade.UsuarioId);
            //var strQuery = "";
            //strQuery += " INSERT INTO Importacao (imp_id, usuario_id, nome, data, terminado, numImportados, atualizados, caminhoArquivo) ";
            //strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}') ",
            //    entidade.Id, entidade.UsuarioId, entidade.Nome, entidade.Data, entidade.Terminado, entidade.NumImportados, 
            //    entidade.NumAtualizados, entidade.CaminhoArquivo);
            //_context.ExecutaComando(strQuery);
        }

        public void Alterar(ImportacaoModel entidade)
        {
            //var strQuery = "";
            //strQuery += " UPDATE Importacao SET ";
            //strQuery += string.Format(" nome = '{0}', ", entidade.Nome);
            //strQuery += string.Format(" data = '{0}', ", entidade.Data);
            //strQuery += string.Format(" terminado = '{0}', ", entidade.Terminado);
            //strQuery += string.Format(" numImportados = '{0}', ", entidade.NumImportados);
            //strQuery += string.Format(" atualizados = '{0}' ", entidade.NumAtualizados);
            //strQuery += string.Format(" WHERE imp_id = '{0}' AND usuario_id = '{1}' ", entidade.Id, entidade.UsuarioId);
            //_context.ExecutaComando(strQuery);
        }

        public void Excluir(ImportacaoModel entidade)
        {
            //var strQuery = string.Format(" DELETE FROM Importacao WHERE imp_id = '{0}' AND usuario_id = '{1}' ", entidade.Id, entidade.UsuarioId
            //    );
            //_context.ExecutaComando(strQuery);
        }

        public List<ImportacaoModel> ListarTodos()
        {
            return new List<ImportacaoModel>();
            //var strQuery = " SELECT * FROM Importacao ";
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public void Terminar(int id, int usuarioId)
        {
            //string strQuery = string.Format(" UPDATE Importacao SET terminado = 'true' WHERE imp_id = '{0}' and usuario_id = '{1}'",
            //    id, usuarioId);
            //_context.ExecutaComando(strQuery);
        }

        public int NumeroImportacao(int usuarioId)
        {
            return 0;
            //int num = 1;
            //var strQuery = string.Format(" SELECT COUNT(*) FROM Importacao WHERE usuario_id = '{0}' ", usuarioId);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //if (retornoDataReader.Read())
            //{
            //    num = int.Parse(retornoDataReader[0].ToString()) + 1;
            //}

            //retornoDataReader.Close();
            //return num;
        }

        public ImportacaoModel ListarPorId(ImportacaoModel entidade)
        {
            return new ImportacaoModel();
            //var strQuery = string.Format(" SELECT * FROM Importacao WHERE imp_id = '{0}' AND usuario_id = '{1}' ", id, usuarioId);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<ImportacaoModel> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<ImportacaoModel>();
            while (reader.Read())
            {
                var temObjeto = new ImportacaoModel()
                {
                    Id = int.Parse(reader["imp_id"].ToString()),
                    UsuarioId = int.Parse(reader["usuario_id"].ToString()),
                    Nome = reader["nome"].ToString(),
                    Data = DateTime.Parse(reader["data"].ToString()),
                    Terminado = bool.Parse(reader["Terminado"].ToString()),
                    NumImportados = int.Parse(reader["numImportados"].ToString()),
                    NumAtualizados = int.Parse(reader["atualizados"].ToString()),
                    CaminhoArquivo = reader["caminhoArquivo"].ToString()
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}
