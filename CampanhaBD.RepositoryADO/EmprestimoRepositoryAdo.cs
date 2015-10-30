using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;

namespace CampanhaBD.RepositoryADO
{
    public class EmprestimoRepositoryAdo
    {
        private Context _context;

        public EmprestimoRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(Emprestimo entidade)
        {
            var strQuery = "";
            strQuery += " INSERT INTO Emprestimos (ClienteId, NumBeneficio, NumEmprestimo, ParcelasNoContrato, " +
                        "ParcelasPagas, Saldo, InicioPagamento, BancoId) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}') ",
                entidade.ClienteId, entidade.NumBeneficio, entidade.NumEmprestimo, entidade.ParcelasNoContrato, 
                entidade.ParcelasPagas, entidade.Saldo, entidade.InicioPagamento, entidade.BancoId);
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Emprestimo entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Emprestimos SET ";
            strQuery += string.Format(" ParcelasNoContrato = '{0}', ", entidade.ParcelasNoContrato);
            strQuery += string.Format(" ParcelasPagas = '{0}', ", entidade.ParcelasPagas);
            strQuery += string.Format(" Saldo = '{0}', ", entidade.Saldo);
            strQuery += string.Format(" InicioPagamento = '{0}', ", entidade.InicioPagamento);
            strQuery += string.Format(" BancoId = '{0}' ", entidade.BancoId);
            strQuery += string.Format(" WHERE ClienteId = '{0}' AND NumBeneficio = '{1}' AND NumEmprestimo = '{2}' ", 
                entidade.ClienteId, entidade.NumBeneficio, entidade.NumEmprestimo);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Emprestimo entidade)
        {
            var strQuery = string.Format(" DELETE FROM Emprestimos WHERE ClienteId = '{0}' AND NumBeneficio = '{1}' " +
                                         "AND NumEmprestimo = '{2}' ", entidade.ClienteId, entidade.NumBeneficio, 
                                         entidade.NumEmprestimo);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Emprestimo> ListarTodos()
        {
            var strQuery = " SELECT * FROM Emprestimos ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Emprestimo ListarPorId(string id)
        {
            var strQuery = string.Format(" SELECT * FROM Emprestimos WHERE Id = {0} ", id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<Emprestimo> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Emprestimo>();
            while (reader.Read())
            {
                var temObjeto = new Emprestimo()
                {
                    ClienteId = int.Parse(reader["ClienteId"].ToString()),
                    NumBeneficio = int.Parse(reader["NumBeneficio"].ToString()),
                    NumEmprestimo = int.Parse(reader["NumEmprestimo"].ToString()),
                    ParcelasNoContrato = int.Parse(reader["ParcelasNoContrato"].ToString()),
                    ParcelasPagas = int.Parse(reader["ParcelasPagas"].ToString())
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}
