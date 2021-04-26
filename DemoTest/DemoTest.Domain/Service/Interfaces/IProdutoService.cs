using DemoTest.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DemoTest.Domain.Service.Interfaces
{
    public interface IProdutoService
    {
        Produto Adicionar(Produto produto);
        Produto Atualizar(Produto produto);
        Produto RetornarPorSku(long sku, bool semRastreio = false);
        void Deletar(long sku);
    }
}
