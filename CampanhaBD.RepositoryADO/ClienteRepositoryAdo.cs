using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Interface;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class ClienteRepositoryAdo : IRepository<ClienteModel>
    {
        private Context _context;
        private readonly EmprestimoRepositoryAdo _emprestimoRepositorioADO;
        private readonly BeneficioRepositoryAdo _beneficioRepositorioADO;

        public ClienteRepositoryAdo(Context context)
        {
            _context = context;
            _emprestimoRepositorioADO = new EmprestimoRepositoryAdo(context);
            _beneficioRepositorioADO = new BeneficioRepositoryAdo(context);
        }

        public void Inserir(ClienteModel entidade)
        {
            //entidade.Classificacao = Pessoa.CLIENTE;
            //_pessoaRepositorioADO.Inserir((Pessoa)entidade);
            //entidade.Id = _pessoaRepositorioADO.UltimoId;

            //var strQuery = "";
            //strQuery += " INSERT INTO CLIENTE (pessoa_id, dataNasc, estado, cidade, bairro, ddd, telefone, logradouro, " +
            //            " cep, trabalhado, numero, complemento, CPF, imp_id, usuario_id) ";
            //strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', " +
            //    " '{10}', '{11}', '{12}', '{13}', '{14}') ", entidade.Id, entidade.DataNascimento, entidade.Uf, entidade.Cidade, 
            //    entidade.Bairro, entidade.Ddd, entidade.Telefone, entidade.Logradouro, entidade.Cep, entidade.Trabalhado, 
            //    entidade.Numero, entidade.Complemento, entidade.Cpf, entidade.ImportacaoId, entidade.UsuarioId);
            //_context.ExecutaComando(strQuery);
        }

        public void Alterar(ClienteModel entidade)
        {
            //var strQuery = "";
            //strQuery += " UPDATE Cliente SET ";
            //strQuery += string.Format(" dataNasc = '{0}', ", entidade.DataNascimento);
            //strQuery += string.Format(" estado = '{0}', ", entidade.Uf);
            //strQuery += string.Format(" cidade = '{0}', ", entidade.Cidade);
            //strQuery += string.Format(" bairro = '{0}', ", entidade.Bairro);
            //strQuery += string.Format(" ddd = '{0}', ", entidade.Ddd);
            //strQuery += string.Format(" telefone = '{0}', ", entidade.Telefone);
            //strQuery += string.Format(" logradouro = '{0}', ", entidade.Logradouro);
            //strQuery += string.Format(" cep = '{0}', ", entidade.Cep);
            //strQuery += string.Format(" trabalhado = '{0}' ", entidade.Trabalhado);
            //strQuery += string.Format(" numero = '{0}', ", entidade.Numero);
            //strQuery += string.Format(" complemento = '{0}', ", entidade.Complemento);
            //strQuery += string.Format(" CPF = '{0}', ", entidade.Cpf);
            //strQuery += string.Format(" imp_id = '{0}', ", entidade.ImportacaoId);
            //strQuery += string.Format(" WHERE pessoa_id = {0} ", entidade.Id);
            //_context.ExecutaComando(strQuery);
        }

        public void AlterarImportacao(ClienteModel entidade)
        {
            //var strQuery = "";
            //strQuery += " UPDATE Cliente SET ";
            //strQuery += string.Format(" imp_id = '{0}' ", entidade.ImportacaoId);
            //strQuery += string.Format(" WHERE pessoa_id = {0} ", entidade.Id);
            //_context.ExecutaComando(strQuery);
        }

        public void Excluir(ClienteModel entidade)
        {
            //var strQuery = string.Format(" DELETE FROM Cliente WHERE pessoa_id = {0}", entidade.Id);
            //_context.ExecutaComando(strQuery);
        }

        public List<ClienteModel> ListarTodos()
        {
            return new List<ClienteModel>();
            //var strQuery = " SELECT * FROM Cliente ";
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public ClienteModel ListarPorId(ClienteModel entidade)
        {
            return new ClienteModel();
            //var strQuery = string.Format(" SELECT * FROM Cliente WHERE pessoa_id = {0} ", id);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        public ClienteModel ListarPorCpf(ClienteModel entidade)
        {
            return new ClienteModel();
            //var strQuery = string.Format(" SELECT * FROM Cliente WHERE CPF = '{0}' ", cpf);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<ClienteModel> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<ClienteModel>();
            while (reader.Read())
            {
                var temObjeto = new ClienteModel()
                {
                    Id = int.Parse(reader["pessoa_id"].ToString()),
                    DataNascimento = DateTime.Parse(reader["dataNasc"].ToString()),
                    Uf = reader["estado"].ToString(),
                    Cidade = reader["cidade"].ToString(),
                    Bairro = reader["bairro"].ToString(),
                    Ddd = reader["ddd"].ToString(),
                    Telefone = reader["telefone"].ToString(),
                    Logradouro = reader["logradouro"].ToString(),
                    Cep = reader["cep"].ToString(),
                    Numero = reader["numero"].ToString(),
                    Trabalhado = bool.Parse(reader["trabalhado"].ToString()),
                    Complemento = reader["complemento"].ToString(),
                    Cpf = reader["CPF"].ToString(),
                    ImportacaoId = int.Parse(reader["imp_id"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }

    }
}
