using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TesteVagaBoticario.Negocio
{
    public class Warehouse
    {
        public Guid Id { get; set; }

        public Guid IdInventory { get; set; }

        public virtual Inventory Inventory { get; set; }

        public string Locality { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }
    }
}
