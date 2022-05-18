using AutoMapper;
using Belezanaweb.Application.Core.Commands;
using Belezanaweb.Application.Products.Commands;
using Belezanaweb.Core.Exceptions;
using Belezanaweb.Domain.Products.Entity;
using Belezanaweb.Domain.Products.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Belezanaweb.Application.Products.Handlers
{
    public class AlterProductCommandHandler : ProductHandlerBase, IRequestHandler<AlterProductCommand, Response>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AlterProductCommandHandler(IProductRepository productRepository, IMapper mapper) 
            : base(productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<Response> Handle(AlterProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                throw new ValidatorException(request.ValidationResult);

            Product existingProduct = base.GetProductBySku(request.Sku);

            var product = _mapper.Map<Product>(request);
            product.UpdatedAt = DateTime.UtcNow;
            product.CreatedAt = existingProduct.CreatedAt;

            _productRepository.Update(product);

            return Task.FromResult(new Response());
        }
    }
}
