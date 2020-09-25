using System;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BelezaNaWeb.Domain.Dtos;
using BelezaNaWeb.Domain.Queries;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BelezaNaWeb.Framework.Extensions;
using BelezaNaWeb.Framework.Data.Repositories;

namespace BelezaNaWeb.Framework.Handlers
{
    public sealed class GetProductHandler : GenericHandler<GetProductQuery, GetProductResult>
    {
        #region Private Read-Only Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructrors

        public GetProductHandler(ILogger<GetProductHandler> logger
            , IMediator mediator
            , IProductRepository productRepository
        )
            : base(logger, mediator)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        #endregion

        #region Overriden Methods

        public override async Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Find(
                predicate: x => x.Sku.Equals(request.Sku)
                , include: x => x.Include(p => p.Warehouses)
            );

            if (product == null)
                throw new ArgumentException($"O produto({request.Sku}) pesquisado não existe.");

            return new GetProductResult
            {
                Sku = product.Sku,
                Name = product.Name,
                Inventory = new InventoryDto
                {
                    Warehouses = product.Warehouses.Select(x => new WarehouseDto
                    {
                        Locality = x.Locality,
                        Quantity = x.Quantity,
                        Type = x.Type.ToDescription().ToUpper()
                    })
                }
            };
        }

        #endregion
    }
}
