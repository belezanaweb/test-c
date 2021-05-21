using BelezaNaWebAvaliacao.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BelezaNaWebAvaliacao.DataAccess.Repositories
{
    public class RepositoryProduct
    {
        private readonly DataContext dataContext;
        public RepositoryProduct(DataContext context)
        {
            dataContext = context;
        }


        public async Task<string> insertProduct(Product product)
        {
            try
            {
                await dataContext.Products.AddAsync(product);
                await dataContext.SaveChangesAsync();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public async Task<Product> GetProduct(int sku)
        {
            try
            {
                var productExisting = await dataContext.Products.Include(x => x.Inventory).Include(x => x.Inventory.Warehouses)
               .FirstOrDefaultAsync(x => x.Sku == sku);

                return productExisting;

            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao consultar o produto de sku: " + sku);
            }
        }

        public async Task<string> UpdateProduct(int sku, Product product)
        {
            try
            {
                var productExisting = await GetProduct(product.Sku);

                product.Id = productExisting.Id;
                product.Inventory.Id = productExisting.Inventory.Id;

                dataContext.Entry(product).State = EntityState.Modified;

                foreach (var wsWxisting in productExisting.Inventory.Warehouses)
                {
                    var wsNew = product.Inventory.Warehouses.Where(x => x.id == 0).FirstOrDefault();

                    wsNew.id = wsWxisting.id;

                    dataContext.Entry(wsNew).State = EntityState.Modified;
                }

                dataContext.SaveChanges();

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public async Task<string> DeleteProduct(int sku)
        {
            try
            {
                var product = await dataContext.Products.Include(x => x.Inventory).Include(x => x.Inventory.Warehouses)
                .FirstOrDefaultAsync(x => x.Sku == sku);

                dataContext.Products.Remove(product);
                await dataContext.SaveChangesAsync();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


    }
}
