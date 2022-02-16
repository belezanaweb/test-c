using BelezaNaWeb.Application.Commands.Products.Mappers;
using BelezaNaWeb.BuildingBlocks.Mediators;
using BelezaNaWeb.BuildingBlocks.Notifications;
using BelezaNaWeb.Domain.Interfaces.Products;
using System.Threading;
using System.Threading.Tasks;

namespace BelezaNaWeb.Application.Commands.Products.Create
{
    public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Nothing>
    {
        private readonly IProductRepository _productRepository;
        private readonly INotificationContext _notifier;

        public CreateProductCommandHandler(IProductRepository productRepository, INotificationContext notifier)
        {
            _productRepository = productRepository;
            _notifier = notifier;
        }

        public async Task<Nothing> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductBySkuAsync(request.Sku);

            if (product != null)
            {
                _notifier.AddBadRequest(nameof(request.Sku), "Produto já existe!");
                return default;
            }

            product = request.ToEntity();

            await _productRepository.AddAsync(product);

            return Nothing.Value;
        }
    }
}
