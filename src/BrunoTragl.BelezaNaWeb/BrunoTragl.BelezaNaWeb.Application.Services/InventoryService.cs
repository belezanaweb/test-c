using BrunoTragl.BelezaNaWeb.Application.Services.Interfaces;
using BrunoTragl.BelezaNaWeb.Domain.Model;
using BrunoTragl.BelezaNaWeb.Domain.Repository.Interfaces;
using System;

namespace BrunoTragl.BelezaNaWeb.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IProductRepository _productRepository;
        public InventoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public uint CalculateInventory(long sku)
        {
            try
            {
                Product product = _productRepository.Get(sku);
                var haveWarehouses = product?.Inventory?.Warehouses;
                return haveWarehouses == null ? 0 : (uint)haveWarehouses.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
