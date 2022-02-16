using BelezaNaWeb.Application.Commands.Products.Commom.Dtos;
using BelezaNaWeb.BuildingBlocks.Mediators;

namespace BelezaNaWeb.Application.Commands.Products.Create
{
    public sealed class CreateProductCommand : ICommand<Nothing>
    {
        public long Sku { get; set; }

        public string Name { get; set; }

        public InventoryDto Inventory { get; set; }
    }
}
