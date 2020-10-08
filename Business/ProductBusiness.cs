using Business.Entity;
using Business.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class ProductBusiness : IProductBusiness
    {

        private readonly ApiContext _context;
        private readonly string productNotFound = "Produto Não Encontrado";

        public ProductBusiness(ApiContext context)
        {
            _context = context;
        }

        public async Task<ReturnProductViewModel> Add(ProductViewModel model)
        {
            bool exists = await Exists(model.SKU);
            if (exists)
                throw new System.ArgumentException("Dois produtos são considerados iguais se os seus skus forem iguais");

            var product = MapModelToProduct(model);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return MapProductToModel(product);
        }

        public async Task<List<ReturnProductViewModel>> GetAll()
        {
            return await _context.Products
                 .Include(x => x.ProductWarehouse)
                 .Select(x => MapProductToModel(x))
                 .ToListAsync();
        }

        public async Task<ReturnProductViewModel> GetBySKU(int sku)
        {
            bool exists = await Exists(sku);
            if (!exists)
                throw new System.ArgumentException(productNotFound);

            var product = await GetProduct(sku);
            return MapProductToModel(product);
        }

        public async Task Remove(int sku)
        {
            bool exists = await Exists(sku);
            if (!exists)
                throw new System.ArgumentException(productNotFound);

            var product = await GetProduct(sku);
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<ReturnProductViewModel> Update(ProductViewModel model)
        {
            bool exists = await Exists(model.SKU);
            if (!exists)
                throw new System.ArgumentException(productNotFound);

            var oldProduct = await GetProduct(model.SKU);
            var newProduct = MapModelToProduct(model);

            oldProduct.Name = newProduct.Name;
            oldProduct.ProductWarehouse = newProduct.ProductWarehouse;

            await _context.SaveChangesAsync();

            return MapProductToModel(oldProduct);
        }

        private static ReturnProductViewModel MapProductToModel(Product product)
        {
            return new ReturnProductViewModel
            {
                SKU = product.SKU,
                Name = product.Name,
                Inventory = new ReturnInventory
                {
                    Quantity = product.ProductWarehouse.Sum(x => x.Quantity),
                    Warehouses = product.ProductWarehouse.Select(x => new Warehouse
                    {
                        Quantity = x.Quantity,
                        Locality = x.Locality,
                        Type = x.Type
                    }).ToList()
                },
                isMarketable = product.ProductWarehouse.Sum(x => x.Quantity) > 0
            };
        }

        private static Product MapModelToProduct(ProductViewModel model)
        {
            return new Product
            {
                SKU = model.SKU,
                Name = model.Name,
                ProductWarehouse = model
                    .Inventory
                    .Warehouses
                    .Select(x => new ProductWarehouse
                    {
                        Locality = x.Locality,
                        Quantity = x.Quantity,
                        Type = x.Type
                    }).ToList()
            };
        }

        public async Task<bool> Exists(int sku)
        {
            var product = await GetProduct(sku);
            return product != null;
        }

        private async Task<Product> GetProduct(int sku)
        {
            return await _context.Products.Include(x => x.ProductWarehouse).FirstOrDefaultAsync(x => x.SKU == sku);
        }

    }
}

