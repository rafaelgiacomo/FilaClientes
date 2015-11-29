using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;
using System;

namespace CampanhaBD.RepositoryADO
{
    public class EmprestimoRepositoryAdo
    {
        private Context _context;
        public int UltimoId { get; set; }

        public EmprestimoRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(Emprestimo entidade)
        {
            var strQuery = "";
            entidade.NumEmprestimo = NumeroEmprestimo(entidade.NumBeneficio, entidade.ClienteId);
            strQuery += " INSERT INTO Emprestimo (emp_id, numero, pessoa_id, parcelasContrato, " +
                        "parcelasPagas, saldo, inicioPag, ban_id, valorParcela) ";
            strQuery += string.Format(" VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}') ",
                entidade.NumEmprestimo, entidade.NumBeneficio, entidade.ClienteId, entidade.ParcelasNoContrato, 
                entidade.ParcelasPagas, entidade.Saldo.ToString().Replace(",","."), entidade.InicioPagamento, entidade.BancoId, 
                entidade.ValorParcela.ToString().Replace(",", "."));
            _context.ExecutaComando(strQuery);
        }

        public void Alterar(Emprestimo entidade)
        {
            var strQuery = "";
            strQuery += " UPDATE Emprestimo SET ";
            strQuery += string.Format(" ParcelasNoContrato = '{0}', ", entidade.ParcelasNoContrato);
            strQuery += string.Format(" ParcelasPagas = '{0}', ", entidade.ParcelasPagas);
            strQuery += string.Format(" Saldo = '{0}', ", entidade.Saldo);
            strQuery += string.Format(" InicioPagamento = '{0}', ", entidade.InicioPagamento);
            strQuery += string.Format(" BancoId = '{0}' ", entidade.BancoId);
            strQuery += string.Format(" valorParcela = '{0}' ", entidade.ValorParcela);
            strQuery += string.Format(" WHERE emp_id = '{0}' AND  numero = '{1}' AND  pessoa_id = '{2}' ", 
                entidade.NumEmprestimo, entidade.NumBeneficio, entidade.ClienteId);
            _context.ExecutaComando(strQuery);
        }

        public void Excluir(Emprestimo entidade)
        {
            var strQuery = string.Format(" DELETE FROM Emprestimo WHERE  emp_id = '{0}' AND numero = '{1}' " +
                                         "AND pessoa_id = '{2}' ", entidade.NumEmprestimo, entidade.NumBeneficio, 
                                         entidade.ClienteId);
            _context.ExecutaComando(strQuery);
        }

        public IEnumerable<Emprestimo> ListarTodos()
        {
            var strQuery = " SELECT * FROM Emprestimo ";
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public Emprestimo ListarPorId(string id, string numero, string pessoa_id)
        {
            var strQuery = string.Format(" SELECT * FROM Emprestimo  WHERE emp_id = '{0}' AND  numero = '{1}' AND  pessoa_id = '{2}' ", id, numero, pessoa_id);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        public int NumeroEmprestimo(int numBeneficio, int pessoaId)
        {
            int num = 1;
            var strQuery = string.Format(" SELECT COUNT(*) QTD FROM Emprestimo WHERE pessoa_id = '{0}' and numero = '{1}'", 
                pessoaId, numBeneficio);
            var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            if (retornoDataReader.Read())
            {
                num = int.Parse(retornoDataReader["QTD"].ToString()) + 1;
            }

            retornoDataReader.Close();
            return num;
        }

        private List<Emprestimo> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<Emprestimo>();
            while (reader.Read())
            {
                var temObjeto = new Emprestimo()
                {
                    NumEmprestimo = int.Parse(reader["emp_id"].ToString()),
                    NumBeneficio = int.Parse(reader["numero"].ToString()),
                    ClienteId = int.Parse(reader["pessoa_id"].ToString()),
                    ParcelasNoContrato = int.Parse(reader["parcelasContrato"].ToString()),
                    ParcelasPagas = int.Parse(reader["parcelasPagas"].ToString()),
                };
                usuarios.Add(temObjeto);
            }
            reader.Close();
            return usuarios;
        }
    }
}
