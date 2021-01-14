using BelezaNaWeb.Application.ViewModel;
using System;
using System.Threading.Tasks;

namespace BelezaNaWeb.Application.Interfaces
{
    public interface IProdutoAppService
    {
        Task<ProdutoViewModel> Adicionar(ProdutoViewModel produtoView);
        Task<ProdutoViewModel> Atualizar(ProdutoViewModel produtoView);
        Task<ProdutoViewModel> ObterPorId(Guid produtoId);
        Task<ProdutoViewModel> ObterPorSku(long sku);
        Task<ProdutoViewModel> RemoverPorSku(long sku);
    }
}
