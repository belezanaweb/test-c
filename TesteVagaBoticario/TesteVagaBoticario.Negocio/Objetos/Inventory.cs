using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteVagaBoticario.Negocio
{
    public class Inventory
    {
        public Inventory(){
            this.Warehouses = new List<Warehouse>();
        }

        public Guid Id { get; set; }

        public Guid IdProduct { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get { return Warehouses?.Sum(w => w.Quantity) ?? 0; } }

        public virtual List<Warehouse> Warehouses { get; set; }
    }
}
