using BackendTest.Domain.Commands.Requests;
using BackendTest.Domain.Commands.Responses;
using BackendTest.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackendTest.Domain.Commands.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly ApiContext _apiContext;

        public CreateProductHandler(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (_apiContext.Products.FirstOrDefault(x => x.Sku == request.Sku) != null)
                {
                    return Task.FromResult(CreateProductResponse.Exists());
                }

                var product = TransformarEmProduto(request);

                _apiContext.Products.Add(product);
                _apiContext.SaveChanges();

                return Task.FromResult(CreateProductResponse.Success());
            }
            catch (Exception ex)
            {
                return Task.FromResult(CreateProductResponse.Error(ex.InnerException.Message));
            }
        }

        private Product TransformarEmProduto(CreateProductRequest request)
        {
            return new Product
            {
                Sku = request.Sku,
                Name = request.Name,
                Inventory = new Inventory
                {
                    Warehouses = request.Inventory?.Warehouses.Select(x => new Warehouse { Locality = x.Locality, Quantity = x.Quantity, Type = x.Type }).ToList()
                }
            };
        }
    }
}
