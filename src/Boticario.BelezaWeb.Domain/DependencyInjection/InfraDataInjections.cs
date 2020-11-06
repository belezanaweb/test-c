using Boticario.BelezaWeb.Domain.Interfaces.Services;
using Boticario.BelezaWeb.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Boticario.BelezaWeb.Domain.DependencyInjection
{
	public static class InfraDataInjections
	{
		public static IServiceCollection DomainDependencies(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
			return services;
		}
	}
}
