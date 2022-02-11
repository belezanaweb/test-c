using MediatR;
using AutoMapper;
using System.Linq;
using BelezaWeb.Domain.Models;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Requests;

namespace BelezaWeb.Domain.Handlers
{
    public class UpdateProductHandle : IRequestHandler<UpdateProductRequest, Response>
    {
        private readonly IRepository<Product> Repository;
        private readonly IMapper Mapper;

        public UpdateProductHandle(IRepository<Product> productRepository, IMapper mapper)
        {
            Repository = productRepository;
            Mapper = mapper;
        }

        public Response Handle(UpdateProductRequest payload)
        {
            var product = Repository.Edit(Mapper.Map<Product>(payload)).Result;
            
            if (product == null)
                return new Response(new { response = $"Produto não encontrado." }, true);
            else
            {
                var amount = product.Inventory.Warehouses.Sum(x => x.Quantity);

                product.Inventory.Quantity = amount;
                product.IsMarketable = amount > 0 ? true : false;

                return new Response(product);
            }
        }
    }
}
