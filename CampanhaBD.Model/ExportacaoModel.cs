using CampanhaBD.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampanhaBD.Model
{
    public class ExportacaoModel
    {
        public CsvFileWriter Writer { get; set; }

        public ExportacaoModel(string caminho)
        {
            Writer = new CsvFileWriter(caminho);
        }

        public void EscreverCabecalhoCompleto()
        {
            string[] cabecalho = FormarCabecalhoPlanilhaCompleto();

            CsvRow rowCabecalho = new CsvRow();
            foreach (string c in cabecalho)
            {
                rowCabecalho.Add(c);
            }

            Writer.WriteRow(rowCabecalho);
        }

        public void EscreverCabecalhoProcessa()
        {
            string[] cabecalho = FormarCabecalhoPlanilhaProcessa();

            CsvRow rowCabecalho = new CsvRow();
            foreach (string c in cabecalho)
            {
                rowCabecalho.Add(c);
            }

            Writer.WriteRow(rowCabecalho);
        }

        public void EscreverCabecalhoTelefone()
        {
            string[] cabecalho = FormarCabecalhoPlanilhaTelefone();

            CsvRow rowCabecalho = new CsvRow();
            foreach (string c in cabecalho)
            {
                rowCabecalho.Add(c);
            }

            Writer.WriteRow(rowCabecalho);
        }

        public void EscreverLinha(CsvRow row)
        {
            Writer.WriteRow(row);
        }

        public void FinalizarRelatorio()
        {
            Writer.Close();
        }

        public string[] FormarCabecalhoPlanilhaCompleto()
        {
            List<string> lista = new List<string>();

            lista.Add("BENEFICIO");
            lista.Add("ESPECIE_BEN");
            lista.Add("CPF");
            lista.Add("DATA_NASCIMENTO");
            lista.Add("NOME");
            lista.Add("UF");
            lista.Add("CIDADE");
            lista.Add("BAIRRO");
            lista.Add("CEP");
            lista.Add("LOGRADOURO");
            lista.Add("NUMERO");
            lista.Add("COMPLEMENTO");
            lista.Add("DDD");
            lista.Add("TELEFONE");
            lista.Add("DDD2");
            lista.Add("TELEFONE2");
            lista.Add("DATA_EMP_ATUALIZADOS");
            lista.Add("DATA_TEL_ATUALIZADO");
            lista.Add("DATA_TRABALHADO");
            lista.Add("DATA_EXP_PROCESSA");
            lista.Add("DATA_IMPORTADO");
            lista.Add("ATIVADO");

            lista.Add("DATA_EXLCUIDO_INSS");
            lista.Add("BANCO_ID");
            lista.Add("DATA_FIM_PAGAMENTO");
            lista.Add("DATA_INICIO_PAGAMENTO");
            lista.Add("PARCELAS_CONTRATO");
            lista.Add("PARCELAS_ABERTO");
            lista.Add("SALDO");
            lista.Add("SITUACAO_EMPRESTIMO");
            lista.Add("TIPO_EMPRESTIMO");
            lista.Add("VALOR_BRUTO");
            lista.Add("VALOR_PARCELA");

            return lista.ToArray();
        }

        public string[] FormarCabecalhoPlanilhaProcessa()
        {
            return new string[] { "BENEFICIO", "DATA_NASCIMENTO", "CPF", "NOME", "ESPECIE", "UF", "IDENTFICACAO_CLIENTE", "STATUS", "OK" };
        }

        public string[] FormarCabecalhoPlanilhaTelefone()
        {
            return new string[] { "CPF" };
        }
    }
}
