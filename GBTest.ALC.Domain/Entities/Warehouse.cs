namespace GBTest.ALC.Domain.Entities
{
    public class Warehouse
    {
        public string Locality { get; set; }
        public decimal Quantity { get; set; }
        public WarehouseType Type { get; set; }
        public enum WarehouseType
        {
            ECOMMERCE,
            PHYSICAL_STORE
        }
    }
}