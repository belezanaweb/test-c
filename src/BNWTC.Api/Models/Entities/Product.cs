namespace BNWTC.Api.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable
        {
            get
            {
                if (Inventory == null || Inventory.Quantity == 0)
                    return false;
                else if (Inventory.Quantity > 0)
                    return true;

                return false;
            }
        }
    }
}
