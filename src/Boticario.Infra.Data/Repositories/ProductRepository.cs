using Boticario.Domain.Entities;
using Boticario.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Properties

        private static readonly List<Product> memoryDatabase = new();

        #endregion

        #region Public Methods

        public IList<Product> GetAll()
        {
            return memoryDatabase;
        }

        public Product GetBySku(uint sku)
        {
            if (memoryDatabase.Any(x => x.Sku == sku))
            {
                var product = memoryDatabase.FirstOrDefault(x => x.Sku == sku);

                return product;
            }
            else
            {
                return null;
            }
        }

        public Product Create(Product product)
        {
            memoryDatabase.Add(product);
            product = memoryDatabase.FirstOrDefault(x => x.Sku == product.Sku);

            return product;
        }

        public Product Update(Product product)
        {
            if (memoryDatabase.Any(x => x.Sku == product.Sku))
            {
                var index = memoryDatabase.FindIndex(x => x.Sku == product.Sku);
                memoryDatabase[index] = product;
                product = memoryDatabase.FirstOrDefault(x => x.Sku == product.Sku);

                return product;
            }
            else
            {
                return null;
            }
        }

        public bool DeleteBySku(uint sku)
        {
            if (memoryDatabase.Any(x => x.Sku == sku))
            {
                memoryDatabase.RemoveAll(x => x.Sku == sku);
                var delete = !memoryDatabase.Any(x => x.Sku == sku);
                return delete;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}