using System;

namespace BelezaNaWeb.Domain.Entities
{
    public class Inventario : EntidadeBase
    {
        public Guid InventarioId { get; set; }
        public Guid ProdutoId { get; set; }
        public long Sku { get; set; }
        public string Localidade { get; set; }
        public int Quantidade { get; set; }
        public string Tipo { get; set; }
    }
}
