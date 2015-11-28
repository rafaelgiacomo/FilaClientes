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
            entidade.Id = NumeroCampanha(entidade.UsuarioId);
            var strQuery = " INSERT INTO Campanha (cam_id, pessoa_id, nome, minParcela, maxParcela, minInicioPag," +  
                "maxInicioPag, minParcelasPagas, maxParcelasPagas, minDataNascimento, apenasNaoExportados, ban_id) ";

            strQuery += string.Format("VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}') ",
                    entidade.Id,
                    entidade.UsuarioId,
                    entidade.Nome,
                    entidade.MinParcela,
                    entidade.MaxParcela, 
                    entidade.MinInicioPag,
                    entidade.MaxInicioPag,
                    entidade.MinParcelasPagas,
                    entidade.MaxParcelasPagas,
                    entidade.MinDataNascimento,
                    Convert.ToByte(entidade.ApenasNaoExportados),
                    entidade.CodigoBanco
                );

            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Campanha entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Campanha SET ";
            strQuery += string.Format(" nome = '{0}', ",                          entidade.Nome);
            strQuery += string.Format(" minParcela = '{0}', ",                    entidade.MinParcela);
            strQuery += string.Format(" maxParcela = '{0}', ",                    entidade.MaxParcela);
            strQuery += string.Format(" minInicioPag = '{0}', ",                  entidade.MinInicioPag);
            strQuery += string.Format(" maxInicioPag = '{0}', ",                  entidade.MaxInicioPag);
            strQuery += string.Format(" maxParcelasPagas = '{0}', ",              entidade.MaxParcelasPagas);
            strQuery += string.Format(" minDataNascimento = '{0}', ",             entidade.MinDataNascimento == default(DateTime) ? null : entidade.MinDataNascimento.ToString("yyyy-MM-dd HH:mm:ss"));
            strQuery += string.Format(" apenasNaoExportados = '{0}', ",           Convert.ToByte(entidade.ApenasNaoExportados));
            strQuery += string.Format(" ban_id = '{0}', ",                        entidade.CodigoBanco);

            strQuery += string.Format(" WHERE cam_id = {0} AND pessoa_id = {1}", entidade.Id, entidade.UsuarioId);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Campanha entidade)
        {
            var strQuery = string.Format(" DELETE FROM Campanha WHERE cam_id = {0} AND pessoa_id = '{1}'", entidade.Id, entidade.UsuarioId);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Campanha> ListarTodos()
        {
            var strQuery = " SELECT * FROM Campanha ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Campanha ListarPorId(string id, string usuarioId)
        {
            var strQuery = string.Format(" SELECT * FROM Campanha WHERE cam_id = {0} AND pessoa_id = {1} ", id, usuarioId);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        public int NumeroCampanha(int usuarioId)
        {
            int num = 0;
            var strQuery = string.Format(" SELECT COUNT(*) FROM Campanha WHERE pessoa_id = '{0}' ", usuarioId);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            if (retornoDataReader.Read())
            {
                num = int.Parse(retornoDataReader[0].ToString());
            }

            if(num == 0)
            {
                num = 1;
            }

            retornoDataReader.Close();
            return num;
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
                    MinParcela = float.Parse(reader["minParcela"].ToString()),
                    MaxParcela = float.Parse(reader["maxParcela"].ToString()),
                    MinInicioPag = reader["minInicioPag"].ToString(),
                    MaxInicioPag = reader["maxInicioPag"].ToString(),
                    MinParcelasPagas = int.Parse(reader["minParcelasPagas"].ToString()),
                    MaxParcelasPagas = int.Parse(reader["maxParcelasPagas"].ToString()),
                    MinDataNascimento = DateTime.Parse(reader["minDataNascimento"].ToString()),
                    ApenasNaoExportados = bool.Parse(reader["apenasNaoExportados"].ToString()),
                    CodigoBanco = int.Parse(reader["codigoBanco"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}
