using DemoTest.Domain.Entities;
using DemoTest.Domain.Repository.Interfaces;
using DemoTest.Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoTest.Domain.Service
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository inventarioRepository;

        public InventarioService(IInventarioRepository inventarioRepository)
        {
            this.inventarioRepository = inventarioRepository;
        }

        public Inventario Adicionar(Inventario inventario)
        {
            inventarioRepository.Adicionar(inventario);
            inventarioRepository.SaveChanges();

            return inventario;
        }

        public Inventario Atualizar(Inventario inventario)
        {
            inventarioRepository.Atualizar(inventario);
            inventarioRepository.SaveChanges();

            return inventario;
        }

        public void Remover(long id)
        {
            inventarioRepository.Deletar(id);
            inventarioRepository.SaveChanges();
        }

        public List<Inventario> RecuperarPorIDProduto(long sku, bool semRastreio = false)
        {
            return inventarioRepository.RetornarQuando(x => x.Sku == sku, semRastreio).ToList();
        }
    }
}
