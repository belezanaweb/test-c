using AutoMapper;
using TesteBoticario.Core.Requests;
using TesteBoticario.Core.Responses;
using TesteBoticario.Domain.Entities;

namespace TesteBoticario.Core.Mappers
{
    class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<CreateProductRequest, Product>().ReverseMap();
            CreateMap<Product, CreateProductResponse>().ReverseMap();
        }
    }
}
