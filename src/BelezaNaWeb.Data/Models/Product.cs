using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaNaWeb.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
