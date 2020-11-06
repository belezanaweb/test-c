using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Boticario.BelezaWeb.Infra.Data.Repositories
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(DbContext context)
			: base(context)
		{
		}

		public async Task<Product> FindBySku(int sku)
		{
			return await Context
				.Set<Product>()
				.Include(p => p.Inventory)
				.ThenInclude(p => p.Warehouses)
				.FirstOrDefaultAsync(p => p.Sku == sku);
		}
	}
}
