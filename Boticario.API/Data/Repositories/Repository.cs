using Boticario.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Boticario.API.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Product GetBySku(int sku)
        {             
            return _context.Products.FirstOrDefault(product => product.Sku == sku);
        }

        public List<Warehouse> GetAllWarehousesAsync()
        {
            return _context.Warehouses.OrderBy(warehouse => warehouse.Id).ToList();
        }        

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) > 0;
        }
       
    }
}
