using System;

namespace CampanhaBD.Model
{
    public class EmprestimoModel
    {
        #region Propriedades
        public long ClienteId { get; set; }

        public long NumBeneficio { get; set; }

        public int NumEmprestimo { get; set; }

        public float ValorParcela { get; set; }

        public float ValorBruto { get; set; }

        public string DataInicioPagamento { get; set; }

        public string DataFimPagamento { get; set; }

        public long CodigoContrato { get; set; }

        public int ParcelasNoContrato { get; set; }

        public int ParcelasEmAberto { get; set; }

        public int TipoEmprestimo { get; set; }

        public int SituacaoEmprestimo { get; set; }

        public string DataIncluidoInss { get; set; }

        public string DataExcluidoInss { get; set; }

        public float Saldo { get; set; }

        public int BancoId { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_EMPRESTIMO";
        public const string PROCEDURE_INSERT_PROCESSA = "SP_SALVAR_EMPRESTIMO_PROCESSA";
        public const string PROCEDURE_UPDATE = "SP_ALTERAR_EMPRESTIMO";
        public const string PROCEDURE_DELETE = "SP_EXCLUIR_EMPRESTIMO";
        public const string PROCEDURE_DELETE_BENEFICIO = "SP_EXCLUIR_EMPRESTIMO_BENEFICIO";
        public const string PROCEDURE_DELETE_CLIENTE = "SP_EXCLUIR_EMPRESTIMO_CLIENTE";
        public const string PROCEDURE_DELETE_CONTRATO = "SP_EXCLUIR_EMPRESTIMO_CONTRATO";
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODOS_EMPRESTIMOS";
        public const string PROCEDURE_SELECT_BY_ID = "SP_SELECIONAR_EMPRESTIMO_ID";
        public const string PROCEDURE_SELECT_BY_CLIENTE_ID = "SP_SELECIONAR_EMPRESTIMOS_CLIENTE_ID";
        public const string PROCEDURE_SELECT_BY_CONTRATO = "SP_SELECIONAR_EMPRESTIMO_CONTRATO";
        public const string COLUMN_BANCO_ID = "BancoId";
        public const string COLUMN_CLIENTE_ID = "ClienteId";
        public const string COLUMN_NUM_BENEFICIO = "NumBeneficio";
        public const string COLUMN_NUM_EMPRESTIMO = "NumEmprestimo";
        public const string COLUMN_VALOR_PARCELA = "ValorParcela";
        public const string COLUMN_VALOR_BRUTO = "ValorBruto";
        public const string COLUMN_PARCELAS_NO_CONTRATO = "ParcelasNoContrato";
        public const string COLUMN_PARCELAS_EM_ABERTO = "ParcelasEmAberto";
        public const string COLUMN_SALDO = "Saldo";
        public const string COLUMN_INICIO_PAGAMENTO = "InicioPagamento";
        public const string COLUMN_FIM_PAGAMENTO = "FimPagamento";
        public const string COLUMN_TIPO_EMPRESTIMO = "TipoEmprestimo";
        public const string COLUMN_SITUACAO_EMPRESTIMO = "SituacaoEmprestimo";
        public const string COLUMN_DATA_INCLUIDO_INSS = "DataIncluidoInss";
        public const string COLUMN_DATA_EXCLUIDO_INSS = "DataExcluidoInss";
        public const string COLUMN_CODIGO_CONTRATO = "CodigoContrato";
        #endregion

        #region Preenchimento de campos

        public void PreencheDataInicioPagamento(string valor)
        {
            try
            {
                if ((!"".Equals(valor)))
                {
                    if (valor.Length == 6)
                    {
                        string anoIni = valor.Substring(0, 4);
                        string mesIni = valor.Substring(4, 2);
                        string diaIni = "10";

                        if (!"00".Equals(diaIni) && !"00".Equals(mesIni) && !"0000".Equals(anoIni))
                        {
                            DataInicioPagamento = (diaIni + "/" + mesIni + "/" + anoIni);
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheDataFimPagamento(string valor)
        {
            try
            {
                if ((!"".Equals(valor)))
                {
                    if (valor.Length == 6)
                    {
                        string anoIni = valor.Substring(0, 4);
                        string mesIni = valor.Substring(4, 2);
                        string diaIni = "10";

                        if (!"00".Equals(diaIni) && !"00".Equals(mesIni) && !"0000".Equals(anoIni))
                        {
                            DataFimPagamento = (diaIni + "/" + mesIni + "/" + anoIni);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheNumBeneficio(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    NumBeneficio = long.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheValorParcela(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    ValorParcela = float.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheValorBruto(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    ValorBruto = float.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        public void PreencheParcelasContrato(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    ParcelasNoContrato = (int) float.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheParcelasEmAberto(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    ParcelasEmAberto = int.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheTipoEmprestimo(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    TipoEmprestimo = int.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheSituacaoEmprestimo(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    SituacaoEmprestimo = int.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheSaldo(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    Saldo = float.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheBancoId(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    BancoId = int.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheDataIncluidoInss(string valor)
        {
            try
            {
                if ((!"".Equals(valor)) && (!"00000000".Equals(valor)))
                {
                    if (valor.Length == 8)
                    {
                        string ano = valor.Substring(0, 4);
                        string mes = valor.Substring(4, 2);
                        string dia = valor.Substring(6, 2);

                        valor = dia + "/" + mes + "/" + ano;
                    }
                    DataIncluidoInss = valor;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheDataExcluidoInss(string valor)
        {
            try
            {
                if ((!"".Equals(valor)) && (!"00000000".Equals(valor)))
                {
                    if (valor.Length == 8)
                    {
                        string ano = valor.Substring(0, 4);
                        string mes = valor.Substring(4, 2);
                        string dia = valor.Substring(6, 2);

                        valor = dia + "/" + mes + "/" + ano;
                    }

                    DataExcluidoInss = valor;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheCodigoContrato(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    CodigoContrato = long.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
