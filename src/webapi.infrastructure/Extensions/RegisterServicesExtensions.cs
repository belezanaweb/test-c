using webapi.domain.Gateways;
using webapi.application.UseCases;
using webapi.application.Models;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using webapi.infrastructure.DataProviders.Repositories;
using webapi.application.Models.Comum;

namespace webapi.infrastructure.Extensions
{
    public static class RegisterServicesExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {

            services.AddTransient<IUseCase<CreateProductRequest, CreateProductResponse>, CreateProductUseCase>();
            services.AddTransient<IUseCase<UpdateProductRequest, ProductResponse>, UpdateProductUseCase>();
            services.AddTransient<IUseCase<GetProductRequest, ProductResponse>, GetProductUseCase>();
            services.AddTransient<IUseCase<DeleteProductRequest, DeleteProductResponse>, DeleteProductUseCase>();
          
            services.AddTransient<IProductGateway, ProductRepository>();
        }    
    }
}