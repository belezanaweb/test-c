using Belezanaweb.Application.Core.Commands;
using Belezanaweb.Application.Products.Commands;
using Belezanaweb.Core.Exceptions;
using Belezanaweb.Domain.Products.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Belezanaweb.Application.Products.Handlers
{
    public class DeleteProductCommandHandler : ProductHandlerBase, IRequestHandler<DeleteProductCommand, Response>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository) 
            : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Response> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                throw new ValidatorException(request.ValidationResult);

            var existingProduct = base.GetProductBySku(request.Sku);

            _productRepository.Delete(existingProduct);

            return Task.FromResult(new Response());
        }
    }
}
