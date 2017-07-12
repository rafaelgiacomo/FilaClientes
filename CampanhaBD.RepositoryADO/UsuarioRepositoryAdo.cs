using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class UsuarioRepositoryAdo
    {
        private Context _context;

        public UsuarioRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(UsuarioModel entidade)
        {
            //entidade.Classificacao = Pessoa.USUARIO;
            //_pessoaRepositorioADO.Inserir((Pessoa) entidade);
            //entidade.Id = _pessoaRepositorioADO.UltimoId;

            //var strQuery = "";
            //strQuery += " INSERT INTO Usuario (usuario_id, login, senha, empresa, email) ";
            //strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}') ",
            //    entidade.Id, entidade.Login, entidade.Senha, entidade.Empresa, entidade.Email);
            //_context.ExecutaComando(strQuery);
        }

        public void Alterar(UsuarioModel entidade)
        {
            //var strQuery = "";
            //strQuery += " UPDATE Usuario SET ";
            //strQuery += string.Format(" login = '{0}', ", entidade.Login);
            //strQuery += string.Format(" senha = '{0}', ", entidade.Senha);
            //strQuery += string.Format(" empresa = '{0}' ", entidade.Empresa);
            //strQuery += string.Format(" email = '{0}', ", entidade.Email);
            //strQuery += string.Format(" WHERE usuario_id = {0} ", entidade.Id);
            //_context.ExecutaComando(strQuery);
        }

        public void Excluir(UsuarioModel entidade)
        {
            //var strQuery = string.Format(" DELETE FROM Usuario WHERE usuario_id = {0}", entidade.Id);
            //_context.ExecutaComando(strQuery);
        }

        public List<UsuarioModel> ListarTodos()
        {
            return new List<UsuarioModel>();
            //var strQuery = " SELECT * FROM Usuario ";
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public UsuarioModel ListarPorId(string id)
        {
            return new UsuarioModel();
            //var strQuery = string.Format(" SELECT * FROM Usuario WHERE usuario_id = {0} ", id);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        public UsuarioModel ListarPorLogin(string login)
        {
            return new UsuarioModel();
            //var strQuery = string.Format(" SELECT * FROM Usuario WHERE login = '{0}' ", login);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<UsuarioModel> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<UsuarioModel>();
            while (reader.Read())
            {
                var temObjeto = new UsuarioModel()
                {
                    Id = int.Parse(reader["usuario_id"].ToString()),
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