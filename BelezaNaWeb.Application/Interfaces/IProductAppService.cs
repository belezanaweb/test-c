using BelezaNaWeb.Application.ViewModels;

namespace BelezaNaWeb.Application.Interfaces
{
    public interface IProductAppService
    {
        ProductViewModel GetBySku(int sku);
        void Register(ProductViewModel productViewModel);
        void Update(ProductViewModel productViewModel);
        void Remove(int sku);
    }
}
