using AutoMapper;
using BelezaWeb.Domain.Models;
using BelezaWeb.Domain.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace BelezaWeb.Infra.Cross.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AutoMapperConfig(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, CreateProductRequest>();
                cfg.CreateMap<CreateProductRequest, Product>();

                cfg.CreateMap<Inventory, InventoryInput>();
                cfg.CreateMap<InventoryInput, Inventory>();

                cfg.CreateMap<Product, ProductInput>();
                cfg.CreateMap<ProductInput, Product>();

                cfg.CreateMap<Product, UpdateProductRequest>();
                cfg.CreateMap<UpdateProductRequest, Product>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
