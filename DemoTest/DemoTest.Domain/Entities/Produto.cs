using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTest.Domain.Entities
{
    public class Produto
    {
        public long Sku { get; set; }
        public string Nome { get; set; }
        public bool Disponível { get; set; }
        public virtual IList<Inventario> Inventario { get; set; }
    }
}
