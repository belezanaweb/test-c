namespace BackEndTest.Domain.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public int ProductSku { get; set; }
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}
