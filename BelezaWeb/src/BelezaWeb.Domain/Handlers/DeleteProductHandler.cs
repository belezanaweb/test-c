using MediatR;
using BelezaWeb.Domain.Models;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Requests;

namespace BelezaWeb.Domain.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, Response>
    {
        private readonly IRepository<Product> Repository;

        public DeleteProductHandler(IRepository<Product> productRepository)
        {
            Repository = productRepository;
        }

        public Response Handle(DeleteProductRequest payload)
        {
            var product = Repository.Get(payload.Sku).Result;

            if (product == null)
                return new Response(new { response = "Produto não encontrado" });
            else
            {
                Repository.Delete(payload.Sku);
                return new Response(new { response = "Produto excluído com sucesso" });
            }
        }
    }
}
