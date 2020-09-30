using AutoMapper;
using BelezaWeb.Domain.Command.Input.AddProduct;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Model;
using BelezaWeb.Domain.Models;
using MediatR;
using System.Linq;

namespace BelezaWeb.Domain.Handlers
{
    public class UpdateProductCommandHandle : IRequestHandler<UpdateProductCommand, Response>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandle(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Response Handle(UpdateProductCommand message)
        {
            var produto = _productRepository.Edit(_mapper.Map<Product>(message)).Result;
            if (produto == null)
                return new Response(new { message = $"Produto não localizado." }, false);
            else
            {
                var total = produto.inventory.warehouses.Sum(x => x.quantity);
                produto.inventory.quantity = total;
                produto.isMarketable = total > 0 ? true : false;
                return new Response(produto, false);
            }

        }
    }
}
