using AutoMapper;
using webapi.application.Models;
using webapi.application.Models.Comum;
using webapi.domain.Entities;
using webapi.domain.Gateways;

namespace webapi.application.UseCases
{
    public class UpdateProductUseCase : IUseCase<UpdateProductRequest, ProductResponse>
    {
        private readonly IMapper Mapper;
        private readonly IProductGateway productGateway;
        public UpdateProductUseCase(IProductGateway productGateway, IMapper mapper)
        {
            Mapper = mapper;
            this.productGateway = productGateway;
        }
               

        public Task<ProductResponse> Execute(UpdateProductRequest request)
        {
            ProductResponse response = new ProductResponse();

            try
            {

                productGateway.Update(Mapper.Map<Product>(request));
                response = Mapper.Map<ProductResponse>(productGateway.Get(request.sku).Result);
            }
            catch (Exception ex)
            {

                response.ErrorMessage = $"Erro ao atualizar o produto {ex.Message}";
            }

            return Task.FromResult(response);
        }
    }
}