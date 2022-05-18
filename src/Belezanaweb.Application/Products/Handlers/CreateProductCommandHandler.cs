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
    public class CreateProductCommandHandler : ProductHandlerBase, IRequestHandler<CreateProductCommand, Response>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper) 
            : base(productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<Response> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                throw new ValidatorException(request.ValidationResult);

            base.CheckIfProductExists(request.Sku);

            var product = _mapper.Map<Product>(request);
            product.CreatedAt = DateTime.UtcNow;
            _productRepository.Insert(product);
            

            return Task.FromResult(new Response());
        }
    }
}
