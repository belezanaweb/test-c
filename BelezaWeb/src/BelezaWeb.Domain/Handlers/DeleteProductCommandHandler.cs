using BelezaWeb.Domain.Command.Input.AddProduct;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Model;
using BelezaWeb.Domain.Models;
using MediatR;

namespace BelezaWeb.Domain.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response>
    {
        private readonly IRepository<Product> _productRepository;

        public DeleteProductCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Response Handle(DeleteProductCommand message)
        {
            var produto = _productRepository.Get(message.Sku).Result;
            if (produto == null)
                return new Response(new { message = "Produto não localizado" });
            else
            {
                _productRepository.Delete(message.Sku);
                return new Response(new { message = "Produto excluido com sucesso." });
            }
        }
    }
}
