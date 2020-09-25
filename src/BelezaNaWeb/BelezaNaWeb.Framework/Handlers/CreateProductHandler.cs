using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Entities;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Framework.Data.Repositories;

namespace BelezaNaWeb.Framework.Handlers
{
    public sealed class CreateProductHandler : GenericHandler<CreateProductCommand, CreateProductResult>
    {
        #region Private Read-Only Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public CreateProductHandler(ILogger<CreateProductHandler> logger
            , IMediator mediator
            , IProductRepository productRepository
        )
            : base(logger, mediator)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));        
        }

        #endregion

        #region Overriden Methods

        public override async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(sku: request.Sku, name: request.Name);

            await _productRepository.Create(product);
            await _productRepository.CompleteAsync();

            return new CreateProductResult
            {
                Sku = product.Sku,
                Name = product.Name
            };
        }

        #endregion
    }
}
