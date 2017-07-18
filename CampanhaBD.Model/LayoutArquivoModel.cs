using System.Collections.Generic;

namespace CampanhaBD.Model
{
    public class LayoutArquivoModel
    {
        #region Propriedades
        public int Codigo { get; set; }

        public string Nome { get; set; }
        #endregion

        #region Constantes
        public const int CODIGO_PROCESSA = 1;
        public const int CODIGO_TELEFONE = 2;
        public const int CODIGO_PANORAMA = 3;
        #endregion

        public static List<LayoutArquivoModel> GeraLista()
        {
            List<LayoutArquivoModel> lista = new List<LayoutArquivoModel>();

            lista.Add(new LayoutArquivoModel() { Codigo = CODIGO_PROCESSA, Nome = "Processa" });
            lista.Add(new LayoutArquivoModel() { Codigo = CODIGO_TELEFONE, Nome = "Telefone" });
            lista.Add(new LayoutArquivoModel() { Codigo = CODIGO_PANORAMA, Nome = "Panorama" });

            return lista;
        }

        public static List<LayoutArquivoModel> GeraListaAtualizacao()
        {
            List<LayoutArquivoModel> lista = new List<LayoutArquivoModel>();

            lista.Add(new LayoutArquivoModel() { Codigo = CODIGO_PROCESSA, Nome = "Processa" });
            lista.Add(new LayoutArquivoModel() { Codigo = CODIGO_TELEFONE, Nome = "Telefone" });

            return lista;
        }
    }
}
