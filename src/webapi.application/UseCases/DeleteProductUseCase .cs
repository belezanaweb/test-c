using AutoMapper;
using webapi.application.Models;
using webapi.domain.Entities;
using webapi.domain.Gateways;

namespace webapi.application.UseCases
{
    public class DeleteProductUseCase : IUseCase<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly IMapper Mapper;
        private readonly IProductGateway productGateway;
        public DeleteProductUseCase(IProductGateway productGateway, IMapper mapper)
        {
            Mapper = mapper;
            this.productGateway = productGateway;
        }

        public Task<DeleteProductResponse> Execute(DeleteProductRequest request)
        {
            DeleteProductResponse response = new DeleteProductResponse();
            try
            {
                productGateway.Delete(request.sku);
            }
            catch (Exception ex)
            {

                response.ErrorMessage = $"Erro ao deletar o produto {ex.Message}";
            }

            return Task.FromResult(response);

        }
    }
}