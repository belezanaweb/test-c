using Boticario.Application.InputModels;
using Boticario.Application.Services.Interfaces;
using Boticario.Application.ViewModels;
using Boticario.Core.Entities;
using Boticario.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Boticario.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        private readonly string _connectionString;

        public ProductService(DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _connectionString = configuration.GetConnectionString("DataBaseCs");
        }

        public int Create(NewProductInputModel inputModel)
        {
            var product = new Product(inputModel.Sku, inputModel.Name/*, inputModel.IdInventory*/);

            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();

            return product.Id;
        }

        public void Delete(int sku)
        {
            var product = _dataContext.Products.SingleOrDefault(product => product.Sku == sku);

            _dataContext.Products.Remove(product);
            _dataContext.SaveChanges();
        }

        public ProductDetailsViewModel GetBySku(int sku)
        {
            var product = _dataContext.Products
                .SingleOrDefault(product => product.Sku == sku);

            if (product == null) return null;

            var productDetailsViewModel = new ProductDetailsViewModel(
                product.Sku,
                product.Name,
                //product.Inventory.Quantity,
                product.IsMarketable);

            return productDetailsViewModel;
        }

        public void Update(UpdateProductInputModel inputModel)
        {
            var product = _dataContext.Products.SingleOrDefault(product => product.Sku == inputModel.Sku);

            _dataContext.Products.Update(product);
            _dataContext.SaveChanges();
        }
    }
}
