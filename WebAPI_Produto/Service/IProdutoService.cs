using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_Produto.Models;

namespace WebAPI_Produto.Service
{
    public interface IProdutoService
    {
        Produto GetProduto(int sku);
        List<Produto> GetProduto();
        Produto CriaProduto(Produto produto);
        Produto AtualizaProduto(int id, Produto produto);
        bool RemoveProduto(int id);
    }
}