namespace BoticarioAPI.Domain.TransferObjects
{
    public class NewProductTO
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public NewInventoryTO Inventory { get; set; }
    }
}
