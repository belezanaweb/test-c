using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Business.Entity
{
    public class Product
    {
        [Key]
        public int SKU { get; set; }
        public string Name { get; set; }
        public ICollection<ProductWarehouse> ProductWarehouse { get; set; }

    }
}
