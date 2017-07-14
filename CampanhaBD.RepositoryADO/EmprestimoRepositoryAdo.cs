using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using CampanhaBD.Model;
using System;
using CampanhaBD.Interface;

namespace CampanhaBD.RepositoryADO
{
    public class EmprestimoRepositoryAdo : IRepository<EmprestimoModel>
    {
        private Context _context;
        public int UltimoId { get; set; }

        public EmprestimoRepositoryAdo(Context context)
        {
            _context = context;
        }

        public void Inserir(EmprestimoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    EmprestimoModel.COLUMN_BANCO_ID, EmprestimoModel.COLUMN_CLIENTE_ID, EmprestimoModel.COLUMN_NUM_BENEFICIO,
                    EmprestimoModel.COLUMN_VALOR_PARCELA, EmprestimoModel.COLUMN_PARCELAS_NO_CONTRATO,
                    EmprestimoModel.COLUMN_PARCELAS_PAGAS, EmprestimoModel.COLUMN_SALDO, EmprestimoModel.COLUMN_INICIO_PAGAMENTO
                };

                object[] values = 
                {
                    entidade.BancoId, entidade.ClienteId, entidade.NumBeneficio, entidade.ValorParcela,
                    entidade.ParcelasNoContrato, entidade.ParcelasPagas, entidade.Saldo, entidade.InicioPagamento
                };

                _context.ExecuteProcedureNoReturn(
                    EmprestimoModel.PROCEDURE_INSERT, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void Alterar(EmprestimoModel entidade)
        {
            //var strQuery = "";
            //strQuery += " UPDATE Emprestimo SET ";
            //strQuery += string.Format(" ParcelasNoContrato = '{0}', ", entidade.ParcelasNoContrato);
            //strQuery += string.Format(" ParcelasPagas = '{0}', ", entidade.ParcelasPagas);
            //strQuery += string.Format(" Saldo = '{0}', ", entidade.Saldo);
            //strQuery += string.Format(" InicioPagamento = '{0}', ", entidade.InicioPagamento);
            //strQuery += string.Format(" BancoId = '{0}' ", entidade.BancoId);
            //strQuery += string.Format(" valorParcela = '{0}' ", entidade.ValorParcela);
            //strQuery += string.Format(" WHERE emp_id = '{0}' AND  numero = '{1}' AND  pessoa_id = '{2}' ", 
            //    entidade.NumEmprestimo, entidade.NumBeneficio, entidade.ClienteId);
            //_context.ExecutaComando(strQuery);
        }

        public void Excluir(EmprestimoModel entidade)
        {
            //var strQuery = string.Format(" DELETE FROM Emprestimo WHERE  emp_id = '{0}' AND numero = '{1}' " +
            //                             "AND pessoa_id = '{2}' ", entidade.NumEmprestimo, entidade.NumBeneficio, 
            //                             entidade.ClienteId);
            //_context.ExecutaComando(strQuery);
        }

        public List<EmprestimoModel> ListarTodos()
        {
            return new List<EmprestimoModel>();
            //var strQuery = " SELECT * FROM Emprestimo ";
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public EmprestimoModel ListarPorId(EmprestimoModel entidade)
        {
            return new EmprestimoModel();
            //var strQuery = string.Format(" SELECT * FROM Emprestimo  WHERE emp_id = '{0}' AND  numero = '{1}' AND  pessoa_id = '{2}' ", id, numero, pessoa_id);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        private List<EmprestimoModel> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var usuarios = new List<EmprestimoModel>();
            while (reader.Read())
            {
                var temObjeto = new EmprestimoModel()
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
