using Produto.Domain.Models;
using Produto.Domain.Repositories;
using Produto.Infra.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Produto.Infra.Repository
{
    public class ProductRepository : BaseRepository, IProdutoRepository
    {
        private readonly ProductDBContext produtoDBContext;

        public ProductRepository(ProductDBContext context) : base(context)
        {
            produtoDBContext = context;
        }

        public void AddAsync(Product product)
        {
            produtoDBContext.Add(product);
            produtoDBContext.SaveChanges();       
        }

        public Product FindBy(string sku)
        {
            return produtoDBContext.Products
                                .Where(p => p.Sku == sku)
                                .FirstOrDefault();
        }

        public bool Remove(Product product)
        {
            produtoDBContext.Products.Remove(product);
            return true;
        }

        public void Update(Product product)
        {
            produtoDBContext.Products.Update(product);  
        }
    }
}
