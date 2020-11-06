using AutoMapper;
using Boticario.BelezaWeb.Application.AutoMapper;
using Boticario.BelezaWeb.Application.DependencyInjection;
using Boticario.BelezaWeb.Domain.DependencyInjection;
using Boticario.BelezaWeb.Infra.Data.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Boticario.BelezaWeb.Infra.IoC
{
	public static class Injections
	{
		public static IServiceCollection InjectCashBackDependencies(this IServiceCollection services)
		{
			services.InfraDataDependencies();
			services.DomainDependencies();
			services.ApplicationDependencies();
			return services;
		}

		public static IServiceCollection InjectAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(AutoMapperConfiguration));
			var mapperConfiguration = AutoMapperConfiguration.RegisterMappings();
			var imapper = mapperConfiguration.CreateMapper();
			services.AddSingleton(imapper);
			return services;
		}

		public static IServiceCollection InjectSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "API Beleza na Web",
					Version = "v1",
					Description = "API de serviços Beleza na Web",
				});
			});
			return services;
		}
	}
}
