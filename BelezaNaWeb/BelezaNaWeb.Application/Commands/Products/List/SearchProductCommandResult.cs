using BelezaNaWeb.Application.Commands.Products.Commom.Dtos;

namespace BelezaNaWeb.Application.Commands.Products.List
{
    public sealed class SearchProductCommandResult
    {
        public SearchProductCommandResult(long sku, string name, InventoryDto inventory)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;
        }

        public SearchProductCommandResult()
        {
        }

        public long Sku { get; set; }

        public string Name { get; set; }

        public InventoryDto Inventory { get; set; }

        public bool? IsMarketable
        {
            get
            {
                if (Inventory.Quantity > 0)
                    return true;

                return false;
            }
        }
    }
}
