using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class UsuarioRepositoryAdo
    {
        private Context _context;
        private readonly PessoaRepositoryAdo _pessoaRepositorioADO;

        public UsuarioRepositoryAdo(Context context)
        {
            _context = context;
            _pessoaRepositorioADO = new PessoaRepositoryAdo(context);
        }

        public void Inserir(Usuario entidade)
        {
            entidade.Classificacao = Pessoa.CLIENTE;
            _pessoaRepositorioADO.Inserir((Pessoa) entidade);
            entidade.Id = _pessoaRepositorioADO.UltimoId;

            var strQuery = "";
            strQuery += " INSERT INTO Usuario (pessoa_id, login, senha, empresa, email) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}') ",
                entidade.Id, entidade.Login, entidade.Senha, entidade.Empresa, entidade.Email);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Usuario entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Usuario SET ";
            strQuery += string.Format(" login = '{0}', ", entidade.Login);
            strQuery += string.Format(" senha = '{0}', ", entidade.Senha);
            strQuery += string.Format(" empresa = '{0}' ", entidade.Empresa);
            strQuery += string.Format(" email = '{0}', ", entidade.Email);
            strQuery += string.Format(" WHERE pessoa_id = {0} ", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Usuario entidade)
        {
            var strQuery = string.Format(" DELETE FROM Usuario WHERE pessoa_id = {0}", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            var strQuery = " SELECT * FROM USUARIOS ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Usuario ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Usuario WHERE pessoa_id = {0} ", id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<Usuario> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Usuario>();
            while (reader.Read())
            {
                var temObjeto = new Usuario()
                {
                    Id = int.Parse(reader["pessoa_id"].ToString()),
                    Login = reader["login"].ToString(),
                    Senha = reader["senha"].ToString(),
                    Empresa = reader["empresa"].ToString(),
                    Email = reader["email"].ToString(),
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}