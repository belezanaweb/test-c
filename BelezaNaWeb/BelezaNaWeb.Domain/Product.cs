
namespace BelezaNaWeb.Domain
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; } = new Inventory();
        public bool IsMarketable
        {
            get
            {
                return Inventory.Quantity > 0;
            }
        }
    }

}
