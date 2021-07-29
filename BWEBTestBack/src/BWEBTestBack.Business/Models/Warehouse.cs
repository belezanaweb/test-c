using System;
using System.Collections.Generic;
using System.Text;

namespace BWEBTestBack.Business.Models
{
    public class Warehouse
    {
        public Warehouse()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }

        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; } // str somente para efeitos do teste, em um caso real criaria um enum aqui mesmo na models

        // EF Relations
        public Inventory Inventory { get; set; }
    }
}
