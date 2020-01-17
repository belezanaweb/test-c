using DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebApi.Helpers
{
    /// <summary>
    /// Helper for generate a initial data
    /// </summary>
    public class HelperDataGenerator
    {
        #region Methods

        /// <summary>
        /// Create a data
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void CreateData(IServiceProvider serviceProvider)
        {
            using (var context = new BelezaWebContext(serviceProvider.GetRequiredService<DbContextOptions<BelezaWebContext>>()))
            {
                // Look for any Products
                if (context.Products.Any())
                {
                    return;   // Data was already exists
                }

                var product = new Models.Product
                {
                    Name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
                    Sku = 43264
                };

                product.Warehouses.Add(new Models.Warehouse
                {
                    Locality = "SP",
                    Quantity = 12,
                    Type = Common.WarehouseType.ECOMMERCE.ToString()
                });

                product.Warehouses.Add(new Models.Warehouse
                {
                    Locality = "MOEMA",
                    Quantity = 3,
                    Type = Common.WarehouseType.PHYSICAL_STORE.ToString()
                });

                context.Products.Add(product);
                context.SaveChanges();
            }
        }
    }

    #endregion
}

