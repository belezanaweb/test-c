using AutoMapper;
using webapi.application.Models;
using webapi.domain.Entities;
using webapi.domain.Gateways;

namespace webapi.application.UseCases
{
    public class CreateProductUseCase : IUseCase<CreateProductRequest, CreateProductResponse>
    {
        private readonly IMapper Mapper;
        private readonly IProductGateway productGateway;
        public CreateProductUseCase(IProductGateway productGateway, IMapper mapper)
        {
            Mapper = mapper;
            this.productGateway = productGateway;
        }

        public Task<CreateProductResponse> Execute(CreateProductRequest request)
        {
            CreateProductResponse response = new CreateProductResponse();

            try
            {
                var item = productGateway.Get(request.sku).Result;
                if (item != null)
                {
                    response.ErrorMessage = "Dois produtos são considerados iguais se os seus skus forem iguais";
                }

                if (response.IsValid)
                {
                    productGateway.Insert(Mapper.Map<Product>(request));
                }
            }
            catch (Exception ex)
            {

                response.ErrorMessage = $"Erro ao cadastrar produto {ex.Message}";
            }

            return Task.FromResult(response);

        }
    }
}