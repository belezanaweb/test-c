using System.Collections.Generic;

namespace BW.Domain
{
    public class ProductDomain
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryDomain Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }
    public class InventoryDomain
    {
        public int Quantity { get; set; }
        public List<WarehouseDomain> Warehouses { get; set; }
    }
    public class WarehouseDomain
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
