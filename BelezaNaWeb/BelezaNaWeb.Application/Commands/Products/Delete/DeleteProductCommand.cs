using BelezaNaWeb.BuildingBlocks.Mediators;

namespace BelezaNaWeb.Application.Commands.Products.Delete
{
    public sealed class DeleteProductCommand : ICommand<Nothing>
    {
        public long Sku { get; set; }

        public DeleteProductCommand WithSku(long sku)
        {
            Sku = sku;
            return this;
        }
    }
}
