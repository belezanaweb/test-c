using Boticario.BelezaWeb.Domain.Entities;
using Boticario.BelezaWeb.Domain.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boticario.BelezaWeb.Domain.Interfaces.Services
{
	public interface IProductService
	{
		Task<Result<IEnumerable<string>>> Add(Product product);
		Task<Result<IEnumerable<string>>> Edit(Product product);
	}
}
