using Boticario.BelezaWeb.Domain;
using Boticario.BelezaWeb.Domain.Interfaces.Repositories;
using Boticario.BelezaWeb.Infra.Data.Contexts;
using Boticario.BelezaWeb.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Boticario.BelezaWeb.Infra.Data.DependencyInjection
{
	public static class InfraDataInjections
	{
		public static IServiceCollection InfraDataDependencies(this IServiceCollection services)
		{
			services.AddDbContext<BelezaWebDbContext>(options =>
				options.UseSqlite(BelezaWebConfiguration.ConnectionStrings.PrincipalConnection));
			services.AddScoped<DbContext, BelezaWebDbContext>();
			services.AddScoped<IProductRepository, ProductRepository>();

			return services;
		}
	}
}
