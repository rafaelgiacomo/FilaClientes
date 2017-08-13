using System;
using System.Collections.Generic;

namespace CampanhaBD.Model
{
    public class ClienteModel
    {

        #region Propriedades
        public long Id { get; set; }

        public string Nome { get; set; }

        public int ImportacaoId { get; set; }

        public string Cpf { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Ddd { get; set; }

        public string Telefone { get; set; }

        public string Ddd2 { get; set; }

        public string Telefone2 { get; set; }

        public string DataNascimento { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string DataExpProcessa { get; set; }

        public string DataTelAtualizado { get; set; }

        public string DataEmpAtualizado { get; set; }

        public string DataTrabalhado { get; set; }

        public string DataImportado { get; set; }

        public List<BeneficioModel> Beneficios { get; set; }

        public List<EmprestimoModel> Emprestimos { get; set; }
        #endregion

        #region Colunas e Procs
        public const string PROCEDURE_INSERT = "SP_SALVAR_CLIENTE";
        public const string PROCEDURE_UPDATE = "SP_ALTERAR_CLIENTE";
        public const string PROCEDURE_DELETE = "SP_EXCLUIR_CLIENTE";
        public const string PROCEDURE_SELECT_ALL = "SP_LISTAR_TODOS_CLIENTES";
        public const string PROCEDURE_SELECT_BY_IMPORTACAO = "SP_SELECIONAR_CLIENTES_IMPORTACAO";
        public const string PROCEDURE_SELECT_BY_ID = "SP_SELECIONAR_CLIENTE_ID";
        public const string PROCEDURE_SELECT_BY_CPF = "SP_SELECIONAR_CLIENTE_CPF";
        public const string PROCEDURE_UPDATE_DATA_EXP_PROCESSA = "SP_ATUALIZAR_DATA_EXP_PROCESSA";
        public const string PROCEDURE_UPDATE_DATA_TRABALHADO = "SP_ATUALIZAR_DATA_TRABALHADO";
        public const string PROCEDURE_UPDATE_DATA_EMPRESTIMO = "SP_ATUALIZAR_DATA_EMP_ATUALIZADO";
        public const string PROCEDURE_UPDATE_DATA_TELEFONE = "SP_ATUALIZAR_DATA_TEL_ATUALIZADO";
        public const string PROCEDURE_UPDATE_IMPORTACAO = "SP_TROCAR_IMPORTACAO_CLIENTE";
        public const string COLUMN_ID = "Id";
        public const string COLUMN_IMPORTACAO_ID = "ImportacaoId";
        public const string COLUMN_NOME = "Nome";
        public const string COLUMN_CPF = "Cpf";
        public const string COLUMN_UF = "Uf";
        public const string COLUMN_CIDADE = "Cidade";
        public const string COLUMN_BAIRRO = "Bairro";
        public const string COLUMN_DDD = "Ddd";
        public const string COLUMN_TELEFONE = "Telefone";
        public const string COLUMN_DDD2 = "Ddd2";
        public const string COLUMN_TELEFONE2 = "Telefone2";
        public const string COLUMN_DATANASCIMENTO = "DataNascimento";
        public const string COLUMN_LOGRADOURO = "Logradouro";
        public const string COLUMN_NUMERO = "Numero";
        public const string COLUMN_COMPLEMENTO = "Complemento";
        public const string COLUMN_CEP = "Cep";
        public const string COLUMN_DATA_IMPORTADO = "DataImportado";
        public const string COLUMN_DATA_TEL_ATUALIZADO = "DataTelAtualizado";
        public const string COLUMN_DATA_EMP_ATUALIZADOS = "DataEmpAtualizados";
        public const string COLUMN_DATA_TRABALHADO = "DataTrabalhado";
        public const string COLUMN_DATA_EXP_PROCESSA = "DataExpProcessa";
        #endregion

        #region Indices das Propriedades
        public static readonly int INDICE_NOME = 0;
        public static readonly int INDICE_DATA_NASCIMENTO = 1;
        public static readonly int INDICE_CPF = 2;
        public static readonly int INDICE_DIGITO_CPF = 3;
        public static readonly int INDICE_UF = 4;
        public static readonly int INDICE_CIDADE = 5;
        public static readonly int INDICE_BAIRRO = 6;
        public static readonly int INDICE_DDD = 7;
        public static readonly int INDICE_TELEFONE = 8;
        public static readonly int INDICE_LOGRADOURO = 9;
        public static readonly int INDICE_CEP = 10;
        public static readonly int INDICE_BENEFICIO = 11;
        public static readonly int INDICE_BANCO = 12;
        public static readonly int INDICE_SALDO = 13;
        public static readonly int INDICE_VALOR_PARCELA = 14;
        public static readonly int INDICE_PARCELAS_NO_CONTRATO = 15;
        public static readonly int INDICE_INICIO_PAGAMENTO = 16;
        public static readonly int INDICE_VALOR_BENEFICIO = 17;
        public static readonly int INDICE_COMPLEMENTO = 18;
        #endregion

        public ClienteModel()
        {
            LimparPropriedades();
        }

        #region Preenchimento de campos
        public void PreencheCpf(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    Cpf = valor + Cpf;
                    Cpf = Cpf.Replace(".", "");
                    Cpf = Cpf.Replace("-", "");

                    //Validando quantidade de dígitos para 11
                    while (Cpf.Length < 11) { Cpf = "0" + Cpf; }
                }
            }
            catch (Exception ex)
            {
                //ex.Message += "Classe Cliente - Metodo: PreencheCpf, valor: " + valor;
            }
        }

        public void PreencheDataNascimento(string valor)
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
                        DataNascimento = data.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheDataExpProcessa(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    var data = Convert.ToDateTime(valor);

                    if (DateTime.Compare(data, DateTime.MinValue) >= 0)
                    {
                        DataExpProcessa = data.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheDataImportado(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    var data = Convert.ToDateTime(valor);

                    if (DateTime.Compare(data, DateTime.MinValue) >= 0)
                    {
                        DataImportado = data.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheDataTelAtualizado(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    var data = Convert.ToDateTime(valor);

                    if (DateTime.Compare(data, DateTime.MinValue) >= 0)
                    {
                        DataTelAtualizado = data.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheDataEmpAtualizados(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    var data = Convert.ToDateTime(valor);

                    if (DateTime.Compare(data, DateTime.MinValue) >= 0)
                    {
                        DataEmpAtualizado = data.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheDataTrabalhado(string valor)
        {
            try
            {
                if (!"".Equals(valor))
                {
                    var data = Convert.ToDateTime(valor);

                    if (DateTime.Compare(data, DateTime.MinValue) >= 0)
                    {
                        DataTrabalhado = data.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheDigitoCpf(string valor)
        {
            try
            {
                //Validando Qtd de dígitos do dígito verificador
                while (valor.Length < 2) { valor = "0" + valor; }
                while (valor.Length > 2) { valor = valor.Replace("0", ""); }

                //juntando dígito verificador
                Cpf += Cpf + valor;

                //Validando qtd de dígitos final
                while (Cpf.Length > 11) { Cpf += "0"; }
            }
            catch (Exception ex)
            {

            }
        }

        public void PreencheCep(string valor)
        {
            try
            {
                valor = valor.Replace("-", "");
                while (valor.Length < 8)
                {
                    valor = "0" + valor;
                }
                Cep = valor;
            }
            catch (Exception)
            {

            }
        }

        public void LimparPropriedades()
        {
            Id = 0;
            Nome = string.Empty;
            ImportacaoId = 0;
            Cpf = string.Empty;
            Uf = string.Empty;
            Cidade = string.Empty;
            Bairro = string.Empty;
            Ddd = string.Empty;
            Telefone = string.Empty;
            DataNascimento = string.Empty;
            Logradouro = string.Empty;
            Numero = string.Empty;
            Complemento = string.Empty;
            Cep = string.Empty;
            DataExpProcessa = string.Empty;
            DataTelAtualizado = string.Empty;
            DataEmpAtualizado = string.Empty;
            DataTrabalhado = string.Empty;
            DataImportado = string.Empty;

            if (Beneficios != null)
            {
                Beneficios.Clear();
            }
            else
            {
                Beneficios = new List<BeneficioModel>();
            }

            if (Emprestimos != null)
            {
                Emprestimos.Clear();
            }
            else
            {
                Emprestimos = new List<EmprestimoModel>();
            }

        }
        #endregion

    }
}
