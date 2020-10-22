using AutoMapper;
using belezanaweb.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace belezanaweb.WebApi.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
