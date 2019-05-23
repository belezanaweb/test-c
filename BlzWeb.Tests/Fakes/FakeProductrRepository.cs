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
            return new Product(43264, "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g", new Inventory(15M));
        }

        public void Save(Product customer)
        {  
        }

        public void Update(Product product)
        {
            
        }
    }
}
