using DemoTest.Domain.Entities;
using System.Collections.Generic;

namespace DemoTest.Domain.Service.Interfaces
{
    public interface IInventarioService
    {
        Inventario Adicionar(Inventario inventario);
        Inventario Atualizar(Inventario inventario);
        List<Inventario> RecuperarPorIDProduto(long sku, bool semRastreio = false);
        void Remover(long id);
    }
}
