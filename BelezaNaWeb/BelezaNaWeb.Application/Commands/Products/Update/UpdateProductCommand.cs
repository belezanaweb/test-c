using BelezaNaWeb.Application.Commands.Products.Commom.Dtos;
using BelezaNaWeb.BuildingBlocks.Mediators;

namespace BelezaNaWeb.Application.Commands.Products.Update
{
    public sealed class UpdateProductCommand : ICommand<Nothing>
    {
        public long Sku { get; private set; }

        public string Name { get; set; }

        public InventoryDto Inventory { get; set; }

        public UpdateProductCommand WithSku(long sku)
        {
            Sku = sku;
            return this;
        }
    }
}
