using Boticario.BelezaWeb.Application.AppService;
using Boticario.BelezaWeb.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Boticario.BelezaWeb.Application.DependencyInjection
{
	public static class InfraDataInjections
	{
		public static IServiceCollection ApplicationDependencies(this IServiceCollection services)
		{
			services.AddScoped<IProductAppService, ProductAppService>();
			return services;
		}
	}
}
