using BelezaNaWeb.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWeb.Service.Interfaces
{
    public interface  IProdutoService : IDisposable
    {
        Task AddAsync(ProdutoViewModel entity);
        Task<ProdutoViewModel> GetByIdAsync(long id);
        Task<ProdutoViewModel> GetBySku(long id);
        Task Update(ProdutoViewModel entity);
        Task Deletar(long id);
        Task<List<ProdutoViewModel>> GetAllAsync();
    }
}
