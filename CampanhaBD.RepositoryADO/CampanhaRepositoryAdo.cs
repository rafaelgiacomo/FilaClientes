using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class CampanhaRepositoryAdo : IRepository<CampanhaModel>
    {
        private Context _context;

        public CampanhaRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(CampanhaModel entidade)
        {
            //entidade.Id = NumeroCampanha(entidade.UsuarioId);
            
            //var strQuery = " INSERT INTO Campanha (cam_id, usuario_id, nome, minParcela, maxParcela, minInicioPag," +  
            //    "maxInicioPag, minParcelasPagas, maxParcelasPagas, minDataNascimento, apenasNaoExportados, ban_id) ";

            //strQuery += string.Format("VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}') ",
            //        entidade.Id,
            //        entidade.UsuarioId,
            //        entidade.Nome,
            //        entidade.MinParcela,
            //        entidade.MaxParcela, 
            //        entidade.MinInicioPag,
            //        entidade.MaxInicioPag,
            //        entidade.MinParcelasPagas,
            //        entidade.MaxParcelasPagas,
            //        entidade.MinDataNascimento,
            //        Convert.ToByte(entidade.ApenasNaoExportados),
            //        entidade.CodigoBanco
            //    );

            ////_context.ExecutaComando(strQuery);

            ////Inserção na tabela de relacionamento entre campanha e importacao
            //foreach (ImportacaoModel imp in entidade.Importacoes)
            //{
            //    CampanhaImportacaoModel rel = new CampanhaImportacaoModel()
            //    {
            //        CampanhaId = entidade.Id,
            //        UsuarioId = entidade.UsuarioId,
            //        ImportacaoId = imp.Id
            //    };
            //    _relacionamentoRepositorioADO.Inserir(rel);
            //}
        }

        public void Alterar(CampanhaModel entidade)
        {
            //var strQuery = "";
            //strQuery += " UPDATE Campanha SET ";
            //strQuery += string.Format(" nome = '{0}', ",                          entidade.Nome);
            //strQuery += string.Format(" minParcela = '{0}', ",                    entidade.MinParcela);
            //strQuery += string.Format(" maxParcela = '{0}', ",                    entidade.MaxParcela);
            //strQuery += string.Format(" minInicioPag = '{0}', ",                  entidade.MinInicioPag);
            //strQuery += string.Format(" maxInicioPag = '{0}', ",                  entidade.MaxInicioPag);
            //strQuery += string.Format(" maxParcelasPagas = '{0}', ",              entidade.MaxParcelasPagas);
            //strQuery += string.Format(" minDataNascimento = '{0}', ",             entidade.MinDataNascimento == default(DateTime) ? null : entidade.MinDataNascimento.ToString("yyyy-MM-dd HH:mm:ss"));
            //strQuery += string.Format(" apenasNaoExportados = '{0}', ",           Convert.ToByte(entidade.ApenasNaoExportados));
            //strQuery += string.Format(" ban_id = '{0}' ",                        entidade.CodigoBanco);

            //strQuery += string.Format(" WHERE cam_id = {0} AND usuario_id = {1}", entidade.Id, entidade.UsuarioId);
            //_context.ExecutaComando(strQuery);
        }

        public void Excluir(CampanhaModel entidade)
        {
            //var strQuery = string.Format(" DELETE FROM Campanha WHERE cam_id = {0} AND usuario_id = '{1}'", entidade.Id, entidade.UsuarioId);
            //_context.ExecutaComando(strQuery);
        }

        public List<CampanhaModel> ListarTodos()
        {
            return new List<CampanhaModel>();

            //var strQuery = " SELECT * FROM Campanha ";
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public CampanhaModel ListarPorId(CampanhaModel entidade)
        {
            //var strQuery = string.Format(" SELECT * FROM Campanha WHERE cam_id = {0} AND usuario_id = {1} ", id, usuarioId);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();

            return new CampanhaModel();
        }

        public int NumeroCampanha(int usuarioId)
        {
            //int num = 1;
            //var strQuery = string.Format(" SELECT COUNT(*) FROM Campanha WHERE usuario_id = '{0}' ", usuarioId);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //if (retornoDataReader.Read())
            //{
            //    num = int.Parse(retornoDataReader[0].ToString()) + 1;
            //}

            //retornoDataReader.Close();
            //return num;
            return 0;
        }

        private List<CampanhaModel> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            return new List<CampanhaModel>();

            //var usuarios = new List<CampanhaModel>();
            //while (reader.Read())
            //{
            //    var temObjeto = new CampanhaModel()
            //    {
            //        Id = int.Parse(reader["cam_id"].ToString()),
            //        UsuarioId = int.Parse(reader["usuario_id"].ToString()),
            //        Nome = reader["nome"].ToString(),
            //        MinParcela = float.Parse(reader["minParcela"].ToString()),
            //        MaxParcela = float.Parse(reader["maxParcela"].ToString()),
            //        MinInicioPag = reader["minInicioPag"].ToString(),
            //        MaxInicioPag = reader["maxInicioPag"].ToString(),
            //        MinParcelasPagas = int.Parse(reader["minParcelasPagas"].ToString()),
            //        MaxParcelasPagas = int.Parse(reader["maxParcelasPagas"].ToString()),
            //        MinDataNascimento = DateTime.Parse(reader["minDataNascimento"].ToString()),
            //        ApenasNaoExportados = bool.Parse(reader["apenasNaoExportados"].ToString()),
            //        CodigoBanco = int.Parse(reader["ban_id"].ToString())
            //    };
            //    usuarios.Add(temObjeto);
            //}
            //reader.Close();
            //return usuarios;
        }
    }
}
