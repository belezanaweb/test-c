using Boticario.API.Models;
using System.Collections.Generic;

namespace Boticario.API.Data.Repositories
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Product GetBySku(int sku);
        List<Warehouse> GetAllWarehousesAsync();
    }
}
