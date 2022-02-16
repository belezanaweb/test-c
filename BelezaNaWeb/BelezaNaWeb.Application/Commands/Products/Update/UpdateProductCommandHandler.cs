using BelezaNaWeb.Application.Commands.Products.Mappers;
using BelezaNaWeb.BuildingBlocks.Mediators;
using BelezaNaWeb.BuildingBlocks.Notifications;
using BelezaNaWeb.Domain.Interfaces.Products;
using System.Threading;
using System.Threading.Tasks;

namespace BelezaNaWeb.Application.Commands.Products.Update
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Nothing>
    {
        private readonly IProductRepository _productRepository;
        private readonly INotificationContext _notifier;

        public UpdateProductCommandHandler(IProductRepository productRepository, INotificationContext notifier)
        {
            _productRepository = productRepository;
            _notifier = notifier;
        }

        public async Task<Nothing> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productFromBase = await _productRepository.GetProductBySkuAsync(request.Sku);

            if (productFromBase is null)
            {
                _notifier.AddNotFound(nameof(request.Sku), "Produto não encontrado!");
                return default;
            }

            var product = request.ToEntity();

            productFromBase.Update(product);

            await _productRepository.UpdateAsync(productFromBase);

            return Nothing.Value;
        }
    }
}
