using Boticario.BelezaWeb.Application.ViewModels.Product;
using Boticario.BelezaWeb.Domain.Results;
using System.Threading.Tasks;

namespace Boticario.BelezaWeb.Application.Interfaces
{
	public interface IProductAppService
	{
		Task<ProductViewModel> FindBySku(int sku);

		Task<Result<ProductViewModel>> Add(ProductViewModel entity);
		Task<Result<ProductViewModel>> Edit(ProductViewModel entity);
		Task<Result<ProductViewModel>> Delete(int sku);
	}
}
