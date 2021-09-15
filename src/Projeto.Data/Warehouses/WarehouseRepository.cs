using Projeto.Domain.Models;
using Projeto.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Data.Warehouses
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly static List<Warehouse> _warehouseList = new List<Warehouse>();

        public Task<int> Add(Warehouse entity)
        {
            return Task.Run(() => {
                _warehouseList.Add(entity);
                return entity.ProdutoSku;
            });
        }

        public Task<bool> Delete(int sku)
        {
            return Task.Run(() => {
                _warehouseList.RemoveAll(w => w.ProdutoSku == sku);
                return true;
            });
        }

        public Task<IEnumerable<Warehouse>> Get(int sku)
        {
            return Task.Run(() => {
                return _warehouseList.Where(w => w.ProdutoSku == sku);
            });
        }
    }
}
