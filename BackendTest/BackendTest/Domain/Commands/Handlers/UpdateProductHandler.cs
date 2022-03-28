using BackendTest.Domain.Commands.Requests;
using BackendTest.Domain.Commands.Responses;
using BackendTest.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackendTest.Domain.Commands.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly ApiContext _apiContext;

        public UpdateProductHandler(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _apiContext.Products
                    .Include(x => x.Inventory.Warehouses)
                    .FirstOrDefault(x => x.Sku == request.Sku);

                if (product == null)
                {
                    return Task.FromResult(UpdateProductResponse.NExists());
                }

                var inventory = TransformarEmInventory(product.Inventory.Id, request.Inventory);

                product.Atualizar(request.Name, inventory);

                _apiContext.SaveChanges();

                return Task.FromResult(UpdateProductResponse.Success());
            }
            catch (Exception ex)
            {
                return Task.FromResult(UpdateProductResponse.Error(ex.InnerException.Message));
            }
        }

        private Inventory TransformarEmInventory(int id, InventoryUpdateRequest inventory)
        {
            return new Inventory
            {
                Id = id,
                Warehouses = inventory?.Warehouses?.Select(x => new Warehouse { Locality = x.Locality, Quantity = x.Quantity, Type = x.Type }).ToList()
            };
        }
    }
}
