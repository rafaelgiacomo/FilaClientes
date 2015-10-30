﻿using System;

namespace CampanhaBD.Model
{
    public class Cliente : Pessoa
    {
        public DateTime DataNascimento { get; set; }

        public string Uf { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Ddd { get; set; }

        public string Telefone { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public bool Trabalhado { get; set; }
    }
}
