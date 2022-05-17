using AutoMapper;
using webapi.application.Models;
using webapi.application.Models.Comum;
using webapi.domain.Entities;
using webapi.domain.Gateways;

namespace webapi.application.UseCases
{
    public class GetProductUseCase : IUseCase<GetProductRequest, ProductResponse>
    {
        private readonly IMapper Mapper;
        private readonly IProductGateway productGateway;
        public GetProductUseCase(IProductGateway productGateway, IMapper mapper)
        {
            Mapper = mapper;
            this.productGateway = productGateway;
        }


        public Task<ProductResponse> Execute(GetProductRequest request)
        {
            ProductResponse response = new ProductResponse();

            try
            {
                var result = productGateway.Get(request.sku).Result;
                if (result == null)
                    response.ErrorMessage = "Produto não encontrado";

                if(response.IsValid)
                    response = Mapper.Map<ProductResponse>(result);
            }
            catch (Exception ex)
            {

                response.ErrorMessage = $"Erro ao recuperar o produto {ex.Message}";
            }

            return Task.FromResult(response);
        }
    }
}