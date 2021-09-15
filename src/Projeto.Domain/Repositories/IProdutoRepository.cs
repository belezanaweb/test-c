using Projeto.Domain.Models;
using System.Threading.Tasks;

namespace Projeto.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<int> Add(Produto entity);

        Task<int> Update(Produto entity);

        Task<bool> Delete(int sku);

        Task<bool> Exist(int sku);

        Task<Produto> Get(int sku);
    }
}
