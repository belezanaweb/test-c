using BrunoTragl.BelezaNaWeb.Application.Services.Interfaces;
using BrunoTragl.BelezaNaWeb.Domain.Model;
using BrunoTragl.BelezaNaWeb.Domain.Repository.Interfaces;
using System;
using System.Linq;

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
                if (haveWarehouses == null)
                    return 0;
                return (uint)haveWarehouses.Sum(w => w.Quantity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
