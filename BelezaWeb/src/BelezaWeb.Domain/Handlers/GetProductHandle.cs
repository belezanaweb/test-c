using MediatR;
using System.Linq;
using BelezaWeb.Domain.Models;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Requests;

namespace BelezaWeb.Domain.Handlers
{
    public class GetProductHandle : IRequestHandler<GetProductRequest, Response>
    {
        private readonly IRepository<Product> Repository;

        public GetProductHandle(IRepository<Product> productRepository)
        {
            Repository = productRepository;
        }

        public Response Handle(GetProductRequest payload)
        {
            var product = Repository.Get(payload.Sku).Result;

            if (product == null)
                return new Response(new { response = $"Produto não encontrado" });
            else
            {
                var amount = product.Inventory.Warehouses.Sum(x => x.Quantity);

                product.Inventory.Quantity = amount;
                product.IsMarketable = amount > 0 ? true : false;

                return new Response(new { product });
            }
        }
    }
}
