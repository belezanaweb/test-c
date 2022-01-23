namespace Boticario.Core.Entities
{
    public class Warehouse : BaseEntity
    {
        public Warehouse(string locality, int quantity, string type)
        {
            Locality = locality;
            Quantity = quantity;
            Type = type;
        }

        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
