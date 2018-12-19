using System;
namespace testc.Model
{
    public class Product
    {
        public long? Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; }

    }
}
