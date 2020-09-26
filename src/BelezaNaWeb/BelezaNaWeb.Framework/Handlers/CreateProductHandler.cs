using System;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Dtos;
using BelezaNaWeb.Domain.Commands;
using BelezaNaWeb.Domain.Entities;
using Microsoft.Extensions.Logging;
using BelezaNaWeb.Domain.Constants;
using BelezaNaWeb.Domain.Exceptions;
using BelezaNaWeb.Framework.Extensions;
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
            var exists = await _productRepository.Any(x => x.Sku.Equals(request.Sku));
            if (exists)
                throw new ApiException(ErrorConstants.ProductAlreadyExists.Name, ErrorConstants.ProductAlreadyExists.Message, ErrorConstants.ProductAlreadyExists.Code);
            
            var product = new Product(
                  sku: request.Sku
                , name: request.Name
                , warehouses: request.Warehouses
                    .Select(x => new Warehouse(sku: request.Sku, quantity: x.Quantity, locality: x.Locality, type: x.Type))
                    .ToList()
            );

            await _productRepository.Create(product);
            await _productRepository.CompleteAsync();

            return new CreateProductResult
            {
                Sku = product.Sku,
                Name = product.Name,
                Inventory = new InventoryDto
                {
                    Warehouses = product.Warehouses.Select(x => new WarehouseDto
                    {
                        Locality = x.Locality,
                        Quantity = x.Quantity,
                        Type = x.Type.ToDescription()
                    })
                }
            };
        }

        #endregion
    }
}
