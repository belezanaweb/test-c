using AutoMapper;
using BelezaWeb.Domain.Command.Input.Product;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Model;
using BelezaWeb.Domain.Models;
using MediatR;
using System.Linq;

namespace BelezaWeb.Domain.Handlers
{
    public class GetProductCommandHandle : IRequestHandler<GetProductCommand, Response>
    {
        private readonly IRepository<Product> _productRepository;

        public GetProductCommandHandle(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Response Handle(GetProductCommand command)
        {
            var produto = _productRepository.Get(command.sku).Result;
            if (produto == null)
                return new Response(new { message = $"Produto não localizado." }, false);
            else
            {
                var total = produto.inventory.warehouses.Sum(x => x.quantity);
                produto.inventory.quantity = total;
                produto.isMarketable = total > 0 ? true : false;
                return new Response(new { produto }, false);
            }
        }
    }
}
