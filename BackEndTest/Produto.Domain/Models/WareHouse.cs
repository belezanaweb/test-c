using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Domain.Models
{
    public class WareHouse: Entity
    {
        public string Locality { get; set; }
        public int Quantitiy { get; set; }
        public WarehouseType Type { get; set; }
        public Invenctory Invenctory { get; set; }
    }

    public enum WarehouseType
    {
        PHISYCAL_STORE,
        ECOMMERCE

    }
}
