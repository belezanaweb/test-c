using System;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Constants;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Domain.Exceptions;
using BelezaNaWeb.Framework.Data.Repositories;

namespace BelezaNaWeb.Framework.Handlers
{
    public sealed class EditProductHandler : GenericHandler<EditProductCommand, bool>
    {
        #region Private Read-Only Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public EditProductHandler(ILogger<EditProductHandler> logger
            , IMediator mediator
            , IProductRepository productRepository
        )
            : base(logger, mediator)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        #endregion

        #region Overriden Methods

        public override async Task<bool> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var exists = await _productRepository.Any(x => x.Sku.Equals(request.Sku));
            if (!exists)
                throw new ApiException(ErrorConstants.ProductNotFound.Name, ErrorConstants.ProductNotFound.Message, ErrorConstants.ProductNotFound.Code);

            var product = new Product(
                  sku: request.Sku
                , name: request.Name
                , warehouses: request.Warehouses
                    .Select(x => new Warehouse(sku: request.Sku, quantity: x.Quantity, locality: x.Locality, type: x.Type))
                    .ToList()
            );

            await _productRepository.Update(request.Sku, product);
            await _productRepository.CompleteAsync();

            return true;
        }

        #endregion
    }
}
