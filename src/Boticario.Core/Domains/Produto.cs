using Boticario.Core.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Core.Domains
{
    public class Produto : EntityBase
    {
        public Produto() { }

        public Produto(long sku, string nome, List<Estoque> estoque)
        {
            Sku = sku;
            Nome = nome;
            Estoque = estoque;
        }

        public long Sku { get; set; }

        public string Nome { get; set; }

        public List<Estoque> Estoque { get; set; } = new List<Estoque>();
    }
}
