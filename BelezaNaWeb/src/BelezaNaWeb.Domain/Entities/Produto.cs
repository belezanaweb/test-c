using System;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Entities
{
    public class Produto : EntidadeBase
    {
        public Guid ProdutoId { get; set; }
        public long Sku { get; set; }
        public string Nome { get; set; }
        public bool EstaVendavel { get; set; }
        public virtual IEnumerable<Inventario> Inventario { get; set; }
    }
}
