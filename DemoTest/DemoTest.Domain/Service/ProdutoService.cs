using DemoTest.Domain.Entities;
using DemoTest.Domain.Entities.Exceptions;
using DemoTest.Domain.Repository.Interfaces;
using DemoTest.Domain.Service.Interfaces;
using System;
using System.Linq;

namespace DemoTest.Domain.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IInventarioService inventarioService;

        public ProdutoService(IProdutoRepository produtoRepository, IInventarioService inventarioService)
        {
            this.produtoRepository = produtoRepository;
            this.inventarioService = inventarioService;
        }

        public Produto Adicionar(Produto produto)
        {
            // Buscando produto direto do repositório para validação
            var pCadastrado = produtoRepository.RetornarPorID(produto.Sku);

            if (pCadastrado != null)
                throw new ProdutoJaCadastradoExcecao();

            produtoRepository.Adicionar(produto);
            produtoRepository.SaveChanges();

            // Atualizando os inventórios com o ID e SKU do produto criado
            foreach (var item in produto.Inventario)
            {
                item.Sku = produto.Sku;
                
                inventarioService.Adicionar(item);
            }

            return produto;
        }

        public Produto Atualizar(Produto produto)
        {
            // buscando produto pelo SKU sem rastreio para atualização
            var pCadastrado = RetornarPorSku(produto.Sku, true);
            
            pCadastrado.Nome = produto.Nome;
            
            foreach (var i in pCadastrado.Inventario)
                inventarioService.Remover(i.Id);

            pCadastrado.Inventario = produto.Inventario;

            produtoRepository.Atualizar(produto);
            produtoRepository.SaveChanges();

            // Atualizando os inventórios com o ID e SKU do produto criado
            foreach (var item in produto.Inventario)
            {
                item.Sku = produto.Sku;

                inventarioService.Adicionar(item);
            }

            return produto;
        }

        public void Deletar(long sku)
        {
            var produto = RetornarPorSku(sku);

            foreach (var i in produto.Inventario)
                inventarioService.Remover(i.Id);

            // Removendo produto do contexto na memória
            produtoRepository.Deletar(sku);
            
            produtoRepository.SaveChanges();
        }

        public Produto RetornarPorSku(long sku, bool semRastreio = false)
        {
            // buscando produto pelo SKU
            var produto = produtoRepository.RetornarPorID(sku, semRastreio);

            // Produto não encontrado, excessão disparada
            if (produto == null)
                throw new ProdutoNaoCadastradoExcecao();

            produto.Inventario = inventarioService.RecuperarPorIDProduto(sku, semRastreio);

            return produto;
        }
    }
}
