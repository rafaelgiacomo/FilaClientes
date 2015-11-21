using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    class PessoaRepositoryAdo
    {
        private Context _context;
        public int UltimoId { get; set; }

        public PessoaRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(Pessoa entidade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO PESSOAS (Nome, Classificacao) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}') ", entidade.Nome, entidade.Classificacao);
            _context.ExecutaComando(strQuery);
            UltimoId = Convert.ToInt32(_context.ExecutaScalar("SELECT SCOPE_IDENTITY()"));
        }

        public void Alterar(Pessoa entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE PESSOAS SET ";
            strQuery += string.Format(" Nome = '{0}', ", entidade.Nome);
            strQuery += string.Format(" Classificacao = '{0}' ", entidade.Classificacao);
            strQuery += string.Format(" WHERE Id = '{0}' ", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Pessoa entidade)
        {
            var strQuery = string.Format(" DELETE FROM PESSOAS WHERE Id = {0}", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Pessoa> ListarTodos()
        {
            var strQuery = " SELECT * FROM PESSOAS ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Pessoa ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM PESSOAS WHERE Id = {0} ", id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<Pessoa> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Pessoa>();
            while (reader.Read())
            {
                var temObjeto = new Pessoa()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Classificacao = int.Parse(reader["Classificacao"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }

    }
}
