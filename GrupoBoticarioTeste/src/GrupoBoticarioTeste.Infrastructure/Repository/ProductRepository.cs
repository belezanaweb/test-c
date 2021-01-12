using GrupoBoticarioTeste.Business.Interfaces.Repositories;
using GrupoBoticarioTeste.Business.Models;
using GrupoBoticarioTeste.Business.ViewModels;
using GrupoBoticarioTeste.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GrupoBoticarioTeste.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext dbContext) : base(dbContext)
        { }

        public Product BuscarProdutoPorSku(int sku)
        {
            return _dbContext.Products.AsNoTracking()
                .Include(c => c.Warehouses)
                .FirstOrDefault(c => c.Sku == sku);
        }

        public SearchProductViewModel ListProdutoPorSku(int sku)
        {
            SearchProductViewModel searchProduct = new SearchProductViewModel();

            var product =  _dbContext.Products.AsNoTracking()
                .Include(c => c.Warehouses)                
                .FirstOrDefault(c => c.Sku == sku);

            if (product == null) return null;

            List<WarehouseViewModel> warehouses = new List<WarehouseViewModel>();
            var qtd = 0;
 
            foreach(var dado in product?.Warehouses)
            {
                WarehouseViewModel warehouseViewModel = new WarehouseViewModel
                {
                    Locality = dado.Locality,
                    Quantity = dado.Quantity,
                    Type = dado.Type
                };

                warehouses.Add(warehouseViewModel);
                qtd += dado.Quantity;
            }

            InventoryViewModel inventory = new InventoryViewModel
            {
                Quantity = qtd,
                Warehouses = warehouses
            };

            return new SearchProductViewModel
            {
                Sku = product.Sku,
                Name = product.Name,
                Inventory = inventory,
                IsMarketable = inventory.Quantity > 0                
            };
        }
    }
}


