using BelezaNaWeb.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Interfaces.Service
{
    public interface IProdutoService
    {
        Task<Produto> Adicionar(Produto produto);
        Task<Produto> Atualizar(Produto produto);
        Task<Produto> ObterPorId(Guid produtoId);
        Task<Produto> ObterPorSku(long sku);
        Task<Produto> RemoverPorSku(long sku);
    }
}
