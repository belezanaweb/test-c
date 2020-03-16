using BelezaNaWeb.Shared.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Domain.Entities
{
    public class Inventory : Entity {


        private readonly IList<Warehouse> _warehouses;

        public Inventory() {
            this._warehouses = new List<Warehouse>();
        }


        //A propriedade inventory.quantity é a soma da quantity dos warehouses
        public int quantity { 
            get {
                var total = 0;
                foreach (var warehouse in this.warehouses)
                {
                    total += warehouse.quantity;
                }
                return total;
            }
        }
        public IReadOnlyCollection<Warehouse> warehouses => this._warehouses.ToArray();

        public void add(Warehouse warehouse) {
            this._warehouses.Add(warehouse);
        }
    }
}
