using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces.Repository;
using BelezaNaWeb.Domain.Interfaces.Service;
using System;
using System.Linq;
using System.Threading.Tasks;
using DomainValidationCore.Validation;

namespace BelezaNaWeb.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IInventarioService _inventarioService;

        public ProdutoService(IProdutoRepository produtoRepository, IInventarioService inventarioService)
        {
            _produtoRepository = produtoRepository;
            _inventarioService = inventarioService;
        }

        public async Task<Produto> Adicionar(Produto produto)
        {
            var produtoExistente = await ObterPorSku(produto.Sku);

            if(produtoExistente != null)
            {
                produto.Validacao.Add(new ValidationError("Produto existente", "Produto com o mesmo SKU já existente"));
                return produto;
            }

            produto.ProdutoId = Guid.NewGuid();

            _produtoRepository.Adicionar(produto);
            _produtoRepository.SaveChanges();

            foreach (var item in produto.Inventario)
            {
                item.ProdutoId = produto.ProdutoId;
                item.Sku = produto.Sku;
                await _inventarioService.Adicionar(item);
            }

            return produto;
        }

        public async Task<Produto> Atualizar(Produto produto)
        {
            var produtoExistente = await ObterPorSku(produto.Sku);

            if (produtoExistente != null)
                await RemoverPorSku(produtoExistente.Sku);

            await Adicionar(produto);

            return produto;
        }

        public async Task<Produto> ObterPorId(Guid produtoId)
        {
            return _produtoRepository.ObterPorIdNoTracking(produtoId);
        }

        public async Task<Produto> ObterPorSku(long sku)
        {
            var produto = _produtoRepository.Buscar(x => x.Sku == sku).FirstOrDefault();

            if (produto != null)
                produto.Inventario = await _inventarioService.ObterPorProdutoId(produto.ProdutoId);

            return produto;
        }

        public async Task<Produto> RemoverPorSku(long sku)
        {
            var produto = await ObterPorSku(sku);

            if (produto != null)
            {
                foreach (var item in produto.Inventario)
                    await _inventarioService.Remover(item.InventarioId);

                _produtoRepository.Remover(produto.ProdutoId);
                _produtoRepository.SaveChanges();
            }

            return produto;
        }
    }
}
