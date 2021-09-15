using Projeto.Domain.Models;
using Projeto.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Data.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly static Dictionary<int, Produto> _produtos = new Dictionary<int, Produto>();

        public Task<int> Add(Domain.Models.Produto entity)
        {
            return Task.Run(() => {
                _produtos.Add(entity.Sku, entity);
                return entity.Sku;
            });
        }

        public Task<bool> Delete(int sku)
        {
            return Task.Run(() => {
                _produtos.Remove(sku);
                return true;
            });
        }

        public Task<bool> Exist(int sku)
        {
            return Task.Run(() => {
                return _produtos.ContainsKey(sku);
            });
        }

        public Task<Domain.Models.Produto> Get(int sku)
        {
            return Task.Run(() => {
                return _produtos.GetValueOrDefault(sku);
            });
        }

        public Task<int> Update(Domain.Models.Produto entity)
        {
            return Task.Run(() => {
                _produtos[entity.Sku] = entity;
                return entity.Sku;
            });
        }
    }
}
