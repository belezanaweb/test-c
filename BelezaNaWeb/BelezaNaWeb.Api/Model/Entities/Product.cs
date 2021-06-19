namespace BelezaNaWeb.Api.Model.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable
        {
            get
            {
                var result = Inventory is not null && Inventory.Quantity > 0;

                return result;
            }
        }
    }
}
