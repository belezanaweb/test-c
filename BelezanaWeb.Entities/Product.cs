using System;

namespace BelezanaWeb.Entities
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public bool IsMarketable { get; set; }
        public Inventory Inventory { get; set; }
    }
}
