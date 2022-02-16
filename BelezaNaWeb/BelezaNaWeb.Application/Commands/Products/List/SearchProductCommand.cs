using BelezaNaWeb.BuildingBlocks.Mediators;

namespace BelezaNaWeb.Application.Commands.Products.List
{
    public sealed class SearchProductCommand : ICommand<SearchProductCommandResult>
    {
        public long Sku { get; set; }
        
        public SearchProductCommand WithSku(long sku)
        {
            Sku = sku;
            return this;
        }
    }
}
