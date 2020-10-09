namespace BelezaNaWebApi.Model
{
    public class ProductModel
    {
        public long? SKU { get; set; }
        public string Name { get; set; }

        public bool IsMarketable
        {
            get
            {
                if (Inventory?.Quantity > 0)
                    return true;

                return false;
            }
        }

        public virtual InventoryModel Inventory { get; set; }
    }
}