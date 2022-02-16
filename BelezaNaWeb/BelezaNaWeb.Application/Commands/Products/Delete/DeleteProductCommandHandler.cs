using BelezaNaWeb.BuildingBlocks.Mediators;
using BelezaNaWeb.BuildingBlocks.Notifications;
using BelezaNaWeb.Domain.Interfaces.Products;
using System.Threading;
using System.Threading.Tasks;

namespace BelezaNaWeb.Application.Commands.Products.Delete
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, Nothing>
    {
        private readonly IProductRepository _productRepository;
        private readonly INotificationContext _notifier;

        public DeleteProductCommandHandler(IProductRepository productRepository, INotificationContext notifier)
        {
            _productRepository = productRepository;
            _notifier = notifier;
        }

        public async Task<Nothing> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductBySkuAsync(request.Sku);

            if (product is null)
            {
                _notifier.AddNotFound(nameof(request.Sku), "Produto não encontrado!");
                return default;
            }

            await _productRepository.DeleteAsync(product);

            return Nothing.Value;
        }
    }
}
