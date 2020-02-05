using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Domain.Produtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Models.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> GetBySku(long id);
        Task<List<Produto>> GetAllAsync();
    }
}
