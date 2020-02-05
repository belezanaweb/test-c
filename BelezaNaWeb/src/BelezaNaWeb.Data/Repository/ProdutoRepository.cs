using BelezaNaWeb.Data.Context;
using BelezaNaWeb.Domain.Models.Repository;
using BelezaNaWeb.Domain.Produtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(BelezaNaWebContext context) : base(context)
        {
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            var entities = await DbSet.Include(b => b.Inventory)
                       .Include(b => b.Inventory.Warehouses)
                       .ToListAsync();
            return entities;
        }

        public async  Task<Produto> GetBySku(long id)
        {
            return await Db.Produtos.Where(b => b.Sku == id)
                       .Include(b => b.Inventory)
                       .Include(b => b.Inventory.Warehouses)
                       .FirstOrDefaultAsync();
        }
    }
}
