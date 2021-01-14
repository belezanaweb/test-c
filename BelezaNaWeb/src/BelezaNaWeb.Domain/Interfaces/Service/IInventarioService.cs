using BelezaNaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Interfaces.Service
{
    public interface IInventarioService
    {
        Task<Inventario> Adicionar(Inventario inventario);
        Task<IEnumerable<Inventario>> ObterPorProdutoId(Guid produtoId);
        Task Remover(Guid inventarioId);
    }
}
