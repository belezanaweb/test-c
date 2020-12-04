using BelezaNaWeb.Data.Models;
using BelezaNaWeb.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BelezaNaWeb.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly BelezaNaWebDbContext _warrenDbContext;

        public ProductRepository(BelezaNaWebDbContext warrenDbContext)
        {
            _warrenDbContext = warrenDbContext;
        }

        public void Insert(Product obj)
        {
            _warrenDbContext.Products.Add(obj);
            _warrenDbContext.SaveChanges();
        }

        public void Update(Product obj)
        {
            _warrenDbContext.Entry(obj).State = EntityState.Modified;
            _warrenDbContext.SaveChanges();
        }

        public void Delete(int sku)
        {
            _warrenDbContext.Products.Remove(Select(sku));
            _warrenDbContext.SaveChanges();
        }

        public IList<Product> Select() =>
            _warrenDbContext.Products.Include(x => x.Inventory).ThenInclude(x => x.WareHouses).ToList();

        public Product Select(int sku) =>
             _warrenDbContext.Products.Include(x => x.Inventory).ThenInclude(x => x.WareHouses).SingleOrDefault(x => x.Sku == sku);

        public void SaveChanges() => _warrenDbContext.SaveChanges();
    }
}
