using Belezanaweb.Application.Core.Middlewares;
using Belezanaweb.Application.Products.Commands;
using Belezanaweb.Application.Profiles.Products;
using Belezanaweb.Application.Validators;
using Belezanaweb.Application.Validators.Products;
using Belezanaweb.Domain.Products.Repositories;
using Belezanaweb.Infra.Data.Repositories.Products;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Belezanaweb.Infra.IoC
{
    public static class IoC
    {
        public static void Load(IServiceCollection services)
        {
            services.AddGlobalExceptionHandlerMiddleware();
            services.AddMediatR(typeof(BaseProductCommand).Assembly);
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddAutoMapper(typeof(InventoryProfile).Assembly);
        }
    }
}
