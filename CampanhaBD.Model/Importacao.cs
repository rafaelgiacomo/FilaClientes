using System;

namespace CampanhaBD.Model
{
    public class Importacao
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public DateTime Data { get; set; }

        public bool Terminado { get; set; }

        public int NumImportados { get; set; }

        public int NumAtualizados { get; set; }

        public string CaminhoArquivo { get; set; }
    }
}
