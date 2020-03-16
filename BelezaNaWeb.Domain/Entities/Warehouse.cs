using BelezaNaWeb.Domain.Enums;
using BelezaNaWeb.Shared.Entities;

namespace BelezaNaWeb.Domain.Entities
{
    public class Warehouse : Entity {
        public Warehouse(string locality, int quantity, WarehouseType type)
        {
            this.locality = locality;
            this.quantity = quantity;
            this.type = type;
        }
        private Warehouse() { }

        public string locality { get; set; }
        public int quantity { get; set; }
        public WarehouseType type { get; set; }
    }
}
