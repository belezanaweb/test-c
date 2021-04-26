using DemoTest.AppService.Application.Interface;
using DemoTest.AppService.Application.Produto.DTO;
using DemoTest.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace DemoTest.AppService.Application.Produto
{
    public class ProdutoAppService : IProdutoAppService
    {
        public readonly IProdutoService produtoService;

        public ProdutoAppService(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        public ProdutoResponse Adicionar(ProdutoRequest request)
        {
            var novoProduto = ConvertRequest(request);

            novoProduto = produtoService.Adicionar(novoProduto);

            return ConvertResponse(novoProduto);
        }

        public ProdutoResponse Atualizar(ProdutoRequest request)
        {
            var produtoAtualizar = ConvertRequest(request);

            produtoAtualizar = produtoService.Atualizar(produtoAtualizar);

            return ConvertResponse(produtoAtualizar);
        }

        public ProdutoResponse RetornarPorSku(long sku)
        {
            var produto = produtoService.RetornarPorSku(sku);

            return ConvertResponse(produto);
        }

        public void Deletar(long sku)
        {
            produtoService.Deletar(sku);
        }

        #region [ Métodos auxiliares ]
        private Domain.Entities.Produto ConvertRequest(ProdutoRequest request)
        {
            var produto = new Domain.Entities.Produto();
            produto.Nome = request.Name;
            produto.Sku = request.Sku;
            produto.Inventario = new List<Domain.Entities.Inventario>();

            foreach (var wh in request.Inventory.Warehouses)
                produto.Inventario.Add(new Domain.Entities.Inventario() { Localidade = wh.Locality, Quantidade = wh.Quantity, Tipo = wh.Type });

            return produto;
        }

        private ProdutoResponse ConvertResponse(Domain.Entities.Produto produto)
        {
            ProdutoResponse produtoResponse = new ProdutoResponse()
            {
                Name = produto.Nome,
                Sku = produto.Sku,
            };

            foreach (var wh in produto.Inventario)
                produtoResponse.Inventory.Warehouses.Add(new WarehouseResponse() { Locality = wh.Localidade, Quantity = wh.Quantidade, Type = wh.Tipo });

            return produtoResponse;
        }
        #endregion
    }
}
