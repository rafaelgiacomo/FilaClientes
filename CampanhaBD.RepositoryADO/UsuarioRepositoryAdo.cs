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
            strQuery += " INSERT INTO USUARIOS (Id, Email, Login, Senha, Empresa) ";
            strQuery += string.Format(" VALUES ('{0}','{1}', '{2}', '{3}', '{4}') ",
                entidade.Id, entidade.Login, entidade.Senha, entidade.Empresa);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Usuario entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE USUARIOS SET ";
            strQuery += string.Format(" Email = '{0}', ", entidade.Login);
            strQuery += string.Format(" Login = '{0}', ", entidade.Login);
            strQuery += string.Format(" Senha = '{0}', ", entidade.Senha);
            strQuery += string.Format(" Empresa = '{0}' ", entidade.Empresa);
            strQuery += string.Format(" WHERE Id = {0} ", entidade.Id);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Usuario entidade)
        {
            var strQuery = string.Format(" DELETE FROM USUARIOS WHERE Id = {0}", entidade.Id);
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
            var strQuery = string.Format(" SELECT * FROM USUARIOS WHERE Id = {0} ", id);
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
                    Id = int.Parse(reader["Id"].ToString()),
                    Login = reader["Login"].ToString(),
                    Email = reader["Email"].ToString(),
                    Senha = reader["Senha"].ToString(),
                    Empresa = reader["Empresa"].ToString()
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}