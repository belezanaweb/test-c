namespace BoticarioAPI.Domain.Entities
{
    public class Warehouse
    {
        public Warehouse(int sku, string locality, int quantity, string type)
        {
            Sku = sku;
            Locality = locality;
            Quantity = quantity;
            Type = type;
        }
        public int Id { get; private set; }
        public int Sku { get; private set; }
        public string Locality { get; private set; }
        public int Quantity { get; private set; }
        public string Type { get; private set; }
        public virtual Product Product { get; private set; }
    }
}
