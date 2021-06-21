using GrupoBoticario.API.Services.IServices;
using GrupoBoticario.API.Data.Repositories.IRepository;
using GrupoBoticario.API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GrupoBoticario.API.Services.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ProdutoService()
        {
        }

        public async Task<Produtos> CreateBySku(Produtos produto)
        {
            //throw new System.NotImplementedException();
            return await _produtoRepository.CreateBySku(produto);
        }

        public async Task<bool> DeleteBySku(Produtos produto)
        {
            return await _produtoRepository.DeleteBySku(produto);
        }

        public async Task<List<Produtos>> ListBySku(int sku)
        {
            return await _produtoRepository.ListBySku(sku);
        }

        public async Task<Produtos> UpdateBySku(Produtos produto)
        {
            return await _produtoRepository.UpdateBySku(produto);
        }

        public async Task<Produtos> ProdutoBySku(int sku)
        {
            return await _produtoRepository.ProdutoBySku(sku);
        }
    }
}
