using AutoMapper;
using BelezaWeb.Domain.Command.Input.AddProduct;
using BelezaWeb.Domain.Model;
using BelezaWeb.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelezaWeb.Infra.CrossCutting.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AutoMapperConfig(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, AddProductCommand>();
                cfg.CreateMap<AddProductCommand, Product>();

                cfg.CreateMap<Inventory, InventoryInput>();
                cfg.CreateMap<InventoryInput, Inventory>();

                cfg.CreateMap<Product, ProductInput>();
                cfg.CreateMap<ProductInput, Product>();

                cfg.CreateMap<Product, UpdateProductCommand>();
                cfg.CreateMap<UpdateProductCommand, Product>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
