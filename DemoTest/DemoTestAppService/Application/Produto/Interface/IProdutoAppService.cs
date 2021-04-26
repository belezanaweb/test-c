using DemoTest.AppService.Application.Produto.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoTest.AppService.Application.Interface
{
    public interface IProdutoAppService
    {
        ProdutoResponse Adicionar(ProdutoRequest produtoRequest);
        ProdutoResponse Atualizar(ProdutoRequest produtoRequest);
        ProdutoResponse RetornarPorSku(long sku);
        void Deletar(long sku);
    }
}
