using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Queries;
using System.Collections.Generic;

namespace BelezaNaWeb.Domain.Repositories
{
    public interface IProductRepository {
        public bool checkSkuExists(int sku);
        public void save(Product product);
        public bool update(Product product);
        public ProductResult getProduct(int sku);
        public List<ProductResult> getAll();
        public bool delete(int sku);

    }
}
