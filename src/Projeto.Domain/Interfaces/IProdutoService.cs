using Projeto.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Domain.Interfaces
{
    public interface IProdutoService
    {
        Task<bool> Create(Produto produto, IEnumerable<Warehouse> warehouses);

        Task<bool> Update(int sku, Produto produto, IEnumerable<Warehouse> warehouses);

        Task<bool> Delete(int sku);

        Task<ProdutoInventory> CalculteInventory(int sku);
    }
}
