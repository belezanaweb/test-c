using GrupoBoticario.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoBoticario.API.Services.IServices
{
    public interface IProdutoService
    {
        Task<Produtos> CreateBySku(Produtos produto);
        Task<bool> DeleteBySku(Produtos produto);
        Task<List<Produtos>> ListBySku(int sku);
        Task<Produtos> UpdateBySku(Produtos produto);
        Task<Produtos> ProdutoBySku(int sku);

    }
}
