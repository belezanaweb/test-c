using BlzWeb.Domain.StoreContext.Enums;
using BlzWeb.Shared.Entities;

namespace BlzWeb.Domain.StoreContext.Entities
{
    public sealed class Warehouse : Entity
    {
        public Warehouse(string locality, int quantity, EWarehouseType type)
        {
            Locality = locality;
            Quantity = quantity;
            Type = type;
        }

        public string Locality { get; private set; }
        public int Quantity { get; private set; }
        public EWarehouseType Type { get; private set; }
       
    }
}
