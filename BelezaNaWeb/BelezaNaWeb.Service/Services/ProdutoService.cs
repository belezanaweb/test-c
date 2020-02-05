using AutoMapper;
using BelezaNaWeb.Domain.Models.Repository;
using BelezaNaWeb.Domain.Produtos;
using BelezaNaWeb.Service.Interfaces;
using BelezaNaWeb.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWeb.Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;

        private readonly IProdutoRepository _produtoRepository;
        //private readonly IMapper mapper;

        public ProdutoService(IProdutoRepository messageRepository,  IMapper mapper)
        {
            _produtoRepository = messageRepository;
            this._mapper = mapper;
        }

        public async Task AddAsync(ProdutoViewModel vm)
        {
            var prodexistent = await _produtoRepository.GetByIdAsync(vm.Sku);
            if (prodexistent != null)
                throw new Exception("Dois produtos são considerados iguais se os seus skus forem iguais!");
            
            var entity = _mapper.Map<Produto>(vm);
            await _produtoRepository.AddAsync(entity);
            await _produtoRepository.CommitAsync();
           
        }

        public async Task Deletar(long id)
        {
            await _produtoRepository.Deletar(id);
            await _produtoRepository.CommitAsync();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

        public async Task<List<ProdutoViewModel>> GetAllAsync()
        {
            return _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.GetAllAsync());
        }

        public async Task<ProdutoViewModel> GetByIdAsync(long id)
        {
            var prod = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoViewModel>(prod);

        }
      
        public async Task<ProdutoViewModel> GetBySku(long id)
        {
            
            var prod = await _produtoRepository.GetBySku(id);
            if (prod != null)
            {
                prod.CalcularInventoryQuantity();
                prod.CalcularIsMarketable();
            }
            
            return _mapper.Map<ProdutoViewModel>(prod);
                
        }

        public async Task Update(ProdutoViewModel vm)
        {
            var entity = _mapper.Map<Produto>(vm);
            _produtoRepository.Update(entity);
            await _produtoRepository.CommitAsync();

        }
    }
}
