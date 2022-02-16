using BelezaNaWeb.Application.Commands.Products.Mappers;
using BelezaNaWeb.BuildingBlocks.Mediators;
using BelezaNaWeb.BuildingBlocks.Notifications;
using BelezaNaWeb.Domain.Interfaces.Products;
using System.Threading;
using System.Threading.Tasks;

namespace BelezaNaWeb.Application.Commands.Products.List
{
    public sealed class SearchProductCommandHandler : ICommandHandler<SearchProductCommand, SearchProductCommandResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly INotificationContext _notifier;

        public SearchProductCommandHandler(IProductRepository productRepository, INotificationContext notifier)
        {
            _productRepository = productRepository;
            _notifier = notifier;
        }

        public async Task<SearchProductCommandResult> Handle(SearchProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductBySkuAsync(request.Sku);

            if (product is null)
            {
                _notifier.AddNotFound(nameof(request.Sku), "Produto não encontrado!");
                return default;
            }

            return SearchProductCommandMapper.MapProduct(product);
        }
    }
}
