using System;

namespace TesteVagaBoticario.Negocio
{
    public class Product
    {
        public Guid Id { get; set; }

        public int Sku { get; set; }

        public string Name { get; set; }

        public Inventory Inventory { get; set; }

        public bool IsMarketable { get { return Inventory?.Quantity > 0; } }
    }
}
