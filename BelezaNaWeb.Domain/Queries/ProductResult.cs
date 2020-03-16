namespace BelezaNaWeb.Domain.Queries
{
    public class ProductResult {
        public int sku { get; set; }
        public string name { get; set; }
        public InventoryResult inventory { get; set; } = new InventoryResult();
        public bool isMarketable { get; set; }
    }
}
