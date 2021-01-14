using AutoMapper;
using BelezaNaWeb.Application.Interfaces;
using BelezaNaWeb.Application.ViewModel;
using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace BelezaNaWeb.Application
{
    public class ProdutoAppService : IProdutoAppService
    {
        public readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoAppService(IMapper mapper, IProdutoService produtoService)
        {
            _mapper = mapper;
            _produtoService = produtoService;
        }

        public async Task<ProdutoViewModel> Adicionar(ProdutoViewModel produtoView)
        {
            var produto = _mapper.Map<Produto>(produtoView);

            var ret = await _produtoService.Adicionar(produto);

            return _mapper.Map<ProdutoViewModel>(ret);
        }

        public async Task<ProdutoViewModel> Atualizar(ProdutoViewModel produtoView)
        {
            var produto = _mapper.Map<Produto>(produtoView);

            var ret = await _produtoService.Atualizar(produto);

            return _mapper.Map<ProdutoViewModel>(ret);
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid produtoId)
        {
            var ret = await _produtoService.ObterPorId(produtoId);

            return _mapper.Map<ProdutoViewModel>(ret);
        }

        public async Task<ProdutoViewModel> ObterPorSku(long sku)
        {
            var ret = await _produtoService.ObterPorSku(sku);

            return _mapper.Map<ProdutoViewModel>(ret);
        }

        public async Task<ProdutoViewModel> RemoverPorSku(long sku)
        {
            var ret = await _produtoService.RemoverPorSku(sku);

            return _mapper.Map<ProdutoViewModel>(ret);
        }
    }
}
