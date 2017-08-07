using System;

namespace CampanhaBD.Model
{
    public class BeneficioModel
    {
        #region Propriedades
        public long Numero { get; set; }

        public long IdCliente { get; set; }

        public string DataInicioBeneficio { get; set; }

        public float Salario { get; set; }

        public int BancoPagamento { get; set; }

        public int AgenciaPagamento { get; set; }

        public int CodigoOrgaoPagador { get; set; }

        public string ContaCorrente { get; set; }

        public string DataIncluidoInss{ get; set; }

        public string DataExcluidoInss { get; set; }

        public DateTime DataCompetencia { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_BENEFICIO";
        public const string PROCEDURE_UPDATE = "SP_ALTERAR_BENEFICIO";
        public const string PROCEDURE_DELETE = "SP_EXCLUIR_BENEFICIO";
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODOS_BENEFICIOS";
        public const string PROCEDURE_SELECT_BY_ID = "SP_SELECIONAR_BENEFICIO_ID";
        public const string PROCEDURE_SELECT_BY_CLIENTE_ID = "SP_LISTAR_BENEFICIO_CLIENTE_ID";
        public const string COLUMN_NUMERO = "Numero";
        public const string COLUMN_CLIENTE_ID = "ClienteId";
        public const string COLUMN_SALARIO = "Salario";
        public const string COLUMN_DATA_COMPETENCIA = "DataCompetencia";
        public const string COLUMN_DATA_INICIO_BENEFICIO = "DataInicioBeneficio";
        public const string COLUMN_BANCO_PAGAMENTO = "BancoPagamento";
        public const string COLUMN_AGENCIA_PAGAMENTO = "AgenciaPagamento";
        public const string COLUMN_ORGAO_PAGADOR = "OrgaoPagador";
        public const string COLUMN_CONTA_CORRENTE = "ContaCorrente";
        public const string COLUMN_DATA_INCLUIDO_INSS = "DataIncluidoInss";
        public const string COLUMN_DATA_EXCLUIDO_INSS = "DataExcluidoInss";
        #endregion

        #region Preenchimento de campos

        public void PreencheNumBeneficio(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    valor = valor.Replace(".", "");
                    valor = valor.Replace("-", "");
                    Numero = long.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheSalario(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    valor = valor.Replace(".", "");
                    valor = valor.Replace("-", "");
                    Salario = float.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheBancoPagamento(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    valor = valor.Replace(".", "");
                    valor = valor.Replace("-", "");
                    BancoPagamento = int.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheAgenciaPagamento(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    valor = valor.Replace(".", "");
                    valor = valor.Replace("-", "");
                    AgenciaPagamento = int.Parse(valor);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheOrgaoPagador(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    valor = valor.Replace(".", "");
                    valor = valor.Replace("-", "");
                    CodigoOrgaoPagador = int.Parse(valor);
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
                if (!"".Equals(valor))
                {
                    if (valor.Length == 8)
                    {
                        string ano = valor.Substring(0, 4);
                        string mes = valor.Substring(4, 2);
                        string dia = valor.Substring(6, 2);

                        valor = dia + "/" + mes + "/" + ano;
                    }

                    var data = Convert.ToDateTime(valor);

                    if (DateTime.Compare(data, DateTime.MinValue) >= 0)
                    {
                        DataIncluidoInss = data.ToString("dd/MM/yyyy");
                    }
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
                if (!"".Equals(valor))
                {
                    if (valor.Length == 8)
                    {
                        string ano = valor.Substring(0, 4);
                        string mes = valor.Substring(4, 2);
                        string dia = valor.Substring(6, 2);

                        valor = dia + "/" + mes + "/" + ano;
                    }

                    var data = Convert.ToDateTime(valor);

                    if (DateTime.Compare(data, DateTime.MinValue) >= 0)
                    {
                        DataExcluidoInss = data.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheDataInicioBeneficio(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    if (valor.Length == 8)
                    {
                        string ano = valor.Substring(0, 4);
                        string mes = valor.Substring(4, 2);
                        string dia = valor.Substring(6, 2);

                        valor = dia + "/" + mes + "/" + ano;
                    }

                    var data = Convert.ToDateTime(valor);

                    if (DateTime.Compare(data, DateTime.MinValue) >= 0)
                    {
                        DataInicioBeneficio = data.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
