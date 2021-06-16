namespace TesteBelezaNaWeb.API.Models.ViewModel
{
    public class WarehouseViewModel
    {
        public WarehouseViewModel(string locality, int quantity, string type)
        {
            this.locality = locality;
            this.quantity = quantity;
            this.type = type;
        }

        public string locality { get; private set; }
        public int quantity { get; private set; }
        public string type { get; private set; }
    }
}
