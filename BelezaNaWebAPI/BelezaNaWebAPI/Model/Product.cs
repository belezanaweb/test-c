using System;

namespace BelezaNaWebAPI.Model
{
    public class Product : IEntity
    {
        public Product()
        {
        }

        public Product(int _sku)
        {
            sku = _sku;
        }

        public Product(int _sku, string _name, bool isMark)
        {
            sku = _sku;
            name = _name ?? throw new ArgumentNullException(nameof(name));
            isMarketable = isMark;
        }

        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public bool isMarketable { get; set; }
    }
}
