using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces.Repository;
using BelezaNaWeb.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Services
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;

        public InventarioService(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        public async Task<Inventario> Adicionar(Inventario inventario)
        {
            inventario.InventarioId = Guid.NewGuid();

            _inventarioRepository.Adicionar(inventario);
            _inventarioRepository.SaveChanges();

            return inventario;
        }

        public async Task Remover(Guid inventarioId)
        {
            _inventarioRepository.Remover(inventarioId);
            _inventarioRepository.SaveChanges();
        }

        public async Task<IEnumerable<Inventario>> ObterPorProdutoId(Guid produtoId)
        {
            return _inventarioRepository.Buscar(x => x.ProdutoId == produtoId);
        }
    }
}
