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
            CreateMap<CreateProductRequest, Product>()
                .ForPath(p => p.Warehouses, map => map.MapFrom(r => r.Inventory.Warehouses));
            CreateMap<Product, CreateProductResponse>();
            CreateMap<Product, GetProductResponse>()
                .ForPath(r => r.Inventory.Warehouses, map => map.MapFrom(p => p.Warehouses));
            CreateMap<Product, DeleteProductResponse>();
            CreateMap<UpdateProductRequest, Product>()
                .ForPath(p => p.Warehouses, map => map.MapFrom(r => r.Inventory.Warehouses));
            CreateMap<Product, UpdateProductResponse>();
        }
    }
}
