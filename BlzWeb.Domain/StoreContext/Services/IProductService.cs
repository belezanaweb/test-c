using BlzWeb.Domain.StoreContext.Entities;

namespace BlzWeb.Domain.StoreContext.Services
{
    public interface IProductService
    {
        Product Get(int sku);
    }
}
