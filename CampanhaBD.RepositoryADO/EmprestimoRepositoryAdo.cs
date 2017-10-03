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
                    EmprestimoModel.COLUMN_PARCELAS_EM_ABERTO, EmprestimoModel.COLUMN_SALDO, EmprestimoModel.COLUMN_INICIO_PAGAMENTO,
                    EmprestimoModel.COLUMN_FIM_PAGAMENTO, EmprestimoModel.COLUMN_TIPO_EMPRESTIMO, EmprestimoModel.COLUMN_SITUACAO_EMPRESTIMO,
                    EmprestimoModel.COLUMN_DATA_INCLUIDO_INSS, EmprestimoModel.COLUMN_DATA_EXCLUIDO_INSS, EmprestimoModel.COLUMN_CODIGO_CONTRATO
                };

                object[] values = 
                {
                    entidade.BancoId, entidade.ClienteId, entidade.NumBeneficio, entidade.ValorParcela,
                    entidade.ParcelasNoContrato, entidade.ParcelasEmAberto, entidade.Saldo, entidade.DataInicioPagamento,
                    entidade.DataFimPagamento, entidade.TipoEmprestimo, entidade.SituacaoEmprestimo,
                    entidade.DataIncluidoInss, entidade.DataExcluidoInss, entidade.CodigoContrato
                };

                _context.ExecuteProcedureNoReturn(
                    EmprestimoModel.PROCEDURE_INSERT, parameters, values);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void InserirProcessa(EmprestimoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    EmprestimoModel.COLUMN_CLIENTE_ID, EmprestimoModel.COLUMN_BANCO_ID,
                    EmprestimoModel.COLUMN_NUM_BENEFICIO,
                    EmprestimoModel.COLUMN_VALOR_PARCELA, EmprestimoModel.COLUMN_PARCELAS_NO_CONTRATO,
                    EmprestimoModel.COLUMN_PARCELAS_EM_ABERTO, EmprestimoModel.COLUMN_SALDO
                };

                object[] values =
                {
                    entidade.ClienteId, entidade.BancoId, entidade.NumBeneficio, entidade.ValorParcela,
                    entidade.ParcelasNoContrato, entidade.ParcelasEmAberto, entidade.Saldo
                };

                _context.ExecuteProcedureNoReturn(
                    EmprestimoModel.PROCEDURE_INSERT_PROCESSA, parameters, values);
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

        public void ExcluirPorContrato(EmprestimoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    EmprestimoModel.COLUMN_CLIENTE_ID, EmprestimoModel.COLUMN_BANCO_ID, EmprestimoModel.COLUMN_CODIGO_CONTRATO
                };

                object[] values =
                {
                    entidade.ClienteId, entidade.BancoId, entidade.CodigoContrato
                };

                _context.ExecuteProcedureNoReturn(
                    EmprestimoModel.PROCEDURE_DELETE_CONTRATO, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void ExcluirPorBeneficio(EmprestimoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    EmprestimoModel.COLUMN_BANCO_ID, EmprestimoModel.COLUMN_NUM_BENEFICIO
                };

                object[] values =
                {
                    entidade.BancoId, entidade.NumBeneficio
                };

                _context.ExecuteProcedureNoReturn(
                    EmprestimoModel.PROCEDURE_DELETE_BENEFICIO, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public void ExcluirPorClienteId(EmprestimoModel entidade)
        {
            try
            {
                string[] parameters =
                {
                    EmprestimoModel.COLUMN_BANCO_ID, EmprestimoModel.COLUMN_CLIENTE_ID
                };

                object[] values =
                {
                    entidade.BancoId, entidade.ClienteId
                };

                _context.ExecuteProcedureNoReturn(
                    EmprestimoModel.PROCEDURE_DELETE_BENEFICIO, parameters, values);
            }
            catch
            {
                throw;
            }
        }

        public List<EmprestimoModel> ListarTodos()
        {
            return new List<EmprestimoModel>();
            //var strQuery = " SELECT * FROM Emprestimo ";
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader);
        }

        public List<EmprestimoModel> ListarEmprestimosPorCliente(long clienteId)
        {
            try
            {
                List<EmprestimoModel> lista = new List<EmprestimoModel>();
                SqlDataReader reader = null;

                string[] parameters = { EmprestimoModel.COLUMN_CLIENTE_ID };
                object[] values = { clienteId };

                reader = _context.ExecuteProcedureWithReturn(
                    EmprestimoModel.PROCEDURE_SELECT_BY_CLIENTE_ID, parameters, values);

                while (reader.Read())
                {
                    var entidade = TransformaReaderEmObjeto(reader);

                    lista.Add(entidade);
                }

                reader.Close();

                return lista;
            }
            catch
            {
                throw;
            }
        }

        public EmprestimoModel ListarPorId(EmprestimoModel entidade)
        {
            return new EmprestimoModel();
            //var strQuery = string.Format(" SELECT * FROM Emprestimo  WHERE emp_id = '{0}' AND  numero = '{1}' AND  pessoa_id = '{2}' ", id, numero, pessoa_id);
            //var retornoDataReader = _context.ExecutaComandoComRetorno(strQuery);
            //return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
        }

        public EmprestimoModel ListarPorContrato(EmprestimoModel entidade)
        {
            try
            {
                SqlDataReader reader = null;
                EmprestimoModel retorno = null;

                string[] parameters =
                {
                    EmprestimoModel.COLUMN_CLIENTE_ID, EmprestimoModel.COLUMN_BANCO_ID, EmprestimoModel.COLUMN_CODIGO_CONTRATO
                };

                object[] values =
                {
                    entidade.ClienteId, entidade.BancoId, entidade.CodigoContrato
                };

                reader = _context.ExecuteProcedureWithReturn(
                    EmprestimoModel.PROCEDURE_SELECT_BY_CONTRATO, parameters, values);

                if (reader.Read())
                {
                    retorno = TransformaReaderEmObjeto(reader);
                }

                reader.Close();

                return retorno;
            }
            catch
            {
                throw;
            }
        }

        private EmprestimoModel TransformaReaderEmObjeto(SqlDataReader reader)
        {
            try
            {
                var temObjeto = new EmprestimoModel();
                temObjeto.BancoId = int.Parse(reader[EmprestimoModel.COLUMN_BANCO_ID].ToString());
                temObjeto.NumEmprestimo = int.Parse(reader[EmprestimoModel.COLUMN_NUM_EMPRESTIMO].ToString());
                temObjeto.NumBeneficio = long.Parse(reader[EmprestimoModel.COLUMN_NUM_BENEFICIO].ToString());
                temObjeto.ParcelasNoContrato = int.Parse(reader[EmprestimoModel.COLUMN_PARCELAS_NO_CONTRATO].ToString());
                temObjeto.ParcelasEmAberto = int.Parse(reader[EmprestimoModel.COLUMN_PARCELAS_EM_ABERTO].ToString());
                temObjeto.Saldo = float.Parse(reader[EmprestimoModel.COLUMN_SALDO].ToString());
                temObjeto.ValorParcela = float.Parse(reader[EmprestimoModel.COLUMN_VALOR_PARCELA].ToString());
                temObjeto.DataInicioPagamento = reader[EmprestimoModel.COLUMN_INICIO_PAGAMENTO].ToString();

                return temObjeto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
