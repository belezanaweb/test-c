using System;
using System.Collections.Generic;
using System.Text;

namespace BWEBTestBack.Business.Models
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public int Sku { get; set; }
        public string Name { get; set; }
        public bool IsMarketable { get; set; }
        public Inventory Inventory { get; set; }
    }
}
