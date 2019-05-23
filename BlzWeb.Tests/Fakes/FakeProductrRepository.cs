using BlzWeb.Domain.StoreContext.Entities;
using BlzWeb.Domain.StoreContext.Repositories;

namespace BlzWeb.Tests
{
    public class FakeProductrRepository : IProductRepository
    {
        public bool CheckSku(int sku)
        {
            return true;
        }

        public void Delete(int sku)
        {
            
        }

        public Product Get(int sku)
        {
            return new Product(43264, "L'Or�al Professionnel Expert Absolut Repair Cortex Lipidium - M�scara de Reconstru��o 500g", new Inventory(15M));
        }

        public void Save(Product customer)
        {  
        }

        public void Update(Product product)
        {
            
        }
    }
}
