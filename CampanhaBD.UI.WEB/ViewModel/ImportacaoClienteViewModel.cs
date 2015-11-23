using CampanhaBD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class ImportacaoClienteViewModel
    {
        public int Nome { get; set; }

        public List<string> colunas { get; set; }
        public List<Cliente> clientes { get; set; }

        [Required]
        public int Cpf { get; set; }

        public int Uf { get; set; }

        public int Cidade { get; set; }

        public int Bairro { get; set; }

        public int Ddd { get; set; }

        public int Telefone { get; set; }

        public int DataNascimento { get; set; }

        public int Logradouro { get; set; }

        public int Numero { get; set; }

        public int Cep { get; set; }
    }
}