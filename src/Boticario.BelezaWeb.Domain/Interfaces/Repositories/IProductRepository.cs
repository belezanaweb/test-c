using Boticario.BelezaWeb.Domain.Entities;
using System.Threading.Tasks;

namespace Boticario.BelezaWeb.Domain.Interfaces.Repositories
{
	public interface IProductRepository : IRepository<Product>
	{
		Task<Product> FindBySku(int sku);
	}
}
