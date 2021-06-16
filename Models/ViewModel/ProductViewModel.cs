namespace TesteBelezaNaWeb.API.Models.ViewModel
{
    public class ProductViewModel
    {
        public ProductViewModel() { }
        public ProductViewModel(int sku, string name)
        {
            this.sku = sku;
            this.name = name;
        }
        public int sku { get; private set; }
        public string name { get; private set; }
        public InventoryViewModel inventory { get; private set; }
        public bool isMarketable { get { return inventory == null ? false : inventory.quantity > 0; } }
    }
}
