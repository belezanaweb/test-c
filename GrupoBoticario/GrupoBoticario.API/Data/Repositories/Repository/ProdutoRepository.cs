using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GrupoBoticario.API.Data.Repositories.IRepository;
using GrupoBoticario.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace GrupoBoticario.API.Data.Repositories.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Produtos> CreateBySku(Produtos produto)
        {
            //throw new System.NotImplementedException();
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<bool> DeleteBySku(Produtos produto)
        {
            if (produto == null)
                return false;

            _context.Remove(produto);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Produtos>> ListBySku(int sku)
        {
            var produto = await _context.Produtos
                .Where(x => x.Sku == sku)
                .Include(x => x.Inventory)
                .Include(x => x.Inventory.Warehouses)
                .AsNoTracking()
                .ToListAsync();

            return produto;
        }

        public async Task<Produtos> ProdutoBySku(int sku)
        {
            var produto = await _context.Produtos
                .Include(x => x.Inventory)
                .Include(x => x.Inventory.Warehouses)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Sku == sku);

            return produto;
        }

        public async Task<Produtos> UpdateBySku(Produtos produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return produto;
        }
    }
}
