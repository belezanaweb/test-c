using System.Linq;
using BelezaWeb.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelezaWeb.Domain.Interfaces;

namespace BelezaWeb.Infra.Data.Repository
{
    public class Repository : IRepository<Product>
    {
        private static Dictionary<int, Product> products = new Dictionary<int, Product>();

        public async Task<IEnumerable<Product>> Get()
        {
            return await Task.Run(() => products.Values.ToList());
        }

        public async Task<Product> Get(int id)
        {
            return await Task.Run(() => products.GetValueOrDefault(id));
        }
                
        public async Task<Product> Create(Product product)
        {
            return await Task.Run(() =>
            {
                if (products.ContainsKey(product.Sku))
                    return null;

                products.Add(product.Sku, product);                
                return product;
            });
        }

        public async Task<Product> Edit(Product product)
        {
            if (!products.ContainsKey(product.Sku))
                return null;

            products.Remove(product.Sku);
            products.Add(product.Sku, product);
            
            return await Task.Run(() => products.GetValueOrDefault(product.Sku));
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => products.Remove(id));
        }
    }
}
