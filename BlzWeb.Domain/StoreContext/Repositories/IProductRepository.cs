using BlzWeb.Domain.StoreContext.Entities;

namespace BlzWeb.Domain.StoreContext.Repositories
{
    public interface IProductRepository
    {        
        void Save(Product customer);       
        bool CheckSku(int sku);
        Product Get(int sku);
        void Update(Product product);
        void Delete(int sku);
    }
}