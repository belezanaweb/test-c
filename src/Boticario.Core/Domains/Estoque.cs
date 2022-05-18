using Boticario.Core.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Core.Domains
{
    public class Estoque : EntityBase
    {
        public Estoque() { }

        public Estoque(string local, int quantidade, string tipo)
        {
            Local = local;
            Quantidade = quantidade;
            Tipo = tipo;
        }

        public string Local { get; set; }

        public int Quantidade { get; set; }

        public string Tipo { get; set; }
    }
}
