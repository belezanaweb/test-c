using System;

namespace API
{
    public class ProductWarehouse
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public string Locality { get; set; }
        public Product Product { get; set; }
        public int ProductSKU { get; set; }
    }
}
