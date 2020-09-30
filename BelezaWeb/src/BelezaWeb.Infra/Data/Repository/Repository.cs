using BelezaWeb.Domain.Model;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BelezaWeb.Domain.Interfaces;
using BelezaWeb.Domain.Models;

namespace BelezaWeb.Infra.Data.Repository
{
    public class Repository : IRepository<Product>
    {
        private static Dictionary<int, Product> produtos = new Dictionary<int, Product>();

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await Task.Run(() => produtos.Values.ToList());
        }

        public async Task<Product> Get(int id)
        {
            return await Task.Run(() => produtos.GetValueOrDefault(id));
        }
                
        public async Task<Product> Add(Product produto)
        {
            return await Task.Run(() =>
            {
                var id = produto.sku;
                produtos.Add(id, produto);
                return produto;
            });
        }

        public async Task<Product> Edit(Product produto)
        {
            produtos.Remove(produto.sku);
            produtos.Add(produto.sku, produto);
            
            return await Task.Run(() =>
                produtos.GetValueOrDefault(produto.sku)
            );
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => produtos.Remove(id));
        }
    }
}
