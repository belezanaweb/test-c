using BackendTest.Domain.Commands.Requests;
using BackendTest.Domain.Commands.Responses;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BackendTest.Domain.Commands.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly ApiContext _apiContext;

        public DeleteProductHandler(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _apiContext.Products.FirstOrDefault(x => x.Sku == request.Sku);
                if (product == null)
                {
                    return Task.FromResult(DeleteProductResponse.NExists());
                }

                _apiContext.Products.Remove(product);
                _apiContext.SaveChanges();

                return Task.FromResult(DeleteProductResponse.Success());
            }
            catch (Exception ex)
            {
                return Task.FromResult(DeleteProductResponse.Error(ex.InnerException.Message));
            }
        }
    }
}
