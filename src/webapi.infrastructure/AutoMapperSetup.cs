using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.application.Models;
using webapi.application.Models.Comum;
using webapi.domain.Entities;

namespace webapi.infrastructure
{
    public static class AutoMapperSetup
    {
        public static void AutoMapperConfig(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductRequest>();
                cfg.CreateMap<ProductRequest, Product>();

                cfg.CreateMap<Product, ProductResponse>();
                cfg.CreateMap<ProductResponse, Product>();
                             

                cfg.CreateMap<Inventory, InventoryRequest>();
                cfg.CreateMap<InventoryRequest, Inventory>();

                cfg.CreateMap<Inventory, InventoryResponse>();
                cfg.CreateMap<InventoryResponse, Inventory>();

                cfg.CreateMap<Warehouse, WarehouseModel>();
                cfg.CreateMap<WarehouseModel, Warehouse>();


            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
