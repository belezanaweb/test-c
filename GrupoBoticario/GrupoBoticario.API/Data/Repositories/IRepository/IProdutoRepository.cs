using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoBoticario.API.Models;

namespace GrupoBoticario.API.Data.Repositories.IRepository
{
    public interface IProdutoRepository
    {
        Task<List<Produtos>> ListBySku(int sku);
        Task<Produtos> CreateBySku(Produtos produto);
        Task<Produtos> UpdateBySku(Produtos produto);
        Task<bool> DeleteBySku(Produtos produto);
        Task<Produtos> ProdutoBySku(int sku);
    }
}
