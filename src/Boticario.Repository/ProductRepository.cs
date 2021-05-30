using Boticario.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Boticario.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        //Precisa ser static somente por conta dos testes unitarios
        private static List<Products> productsDataBase = new List<Products>();

        private static string[] ufs = { "BA", "SP", "MG", "MA", "PA", "ES" };

        public ProductsRepository()
        {

            /**SEED***/
            for (int a= 1; a <= ufs.Length; a++)
            {
                var produto = new Products(Guid.NewGuid(), $"Produto {a}", a);
                produto.Inventory.AddWarehouse(new Warehouses(ufs[a-1], "ECOMMERCE"));

                productsDataBase.Add(produto);                
            }

        }

        public IQueryable<Products> GetCollectionAsync()
        {
            return productsDataBase.AsQueryable();
        }

        public Task<List<Products>> FindAsync(Expression<Func<Products, bool>> condition =  null, int limit=0, int page=0)
        {
            try
            {
                if (condition == null)
                    condition = x => true;

                return Task.Run(() => 
                {
                    var querie = productsDataBase.AsQueryable().Where(condition);
                    
                    if ((page - 1) > 0)
                        querie = querie.Skip((page - 1) * limit);

                    if (limit > 0)
                        querie =  querie.Take(limit);
                   

                    return querie.ToList();  
                
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<Products> FindOneAsync(Func<Products, bool> condition = null)
        {
            try
            {
                if (condition == null)
                    condition = x => true;

                return Task.Run(() => { return productsDataBase.Where(condition).FirstOrDefault(); });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<Products> FindByIdAsync(Guid id)
        {
            try
            {
                return Task.Run(() => { return productsDataBase.Where(x => x.Id == id).FirstOrDefault(); });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        

        public Task<Products> CreateAsync(Products product)
        {
            try
            {
                if (product.Id == Guid.Empty)
                    product.SetId( Guid.NewGuid());

                productsDataBase.Add(product);

                return Task.Run(()=> { return product; });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

   
        public Task<Products> UpdateAsync(Products product)
        {
            try
            {
                var p = productsDataBase.Where(x => x.Id == product.Id).FirstOrDefault();
                productsDataBase.Remove(p);

                productsDataBase.Add(product);

                return Task.Run(() => { return product; });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task DeleteByIdAsync(Guid id)
        {
            try
            {
                var p = productsDataBase.Where(x => x.Id == id).FirstOrDefault();
                productsDataBase.Remove(p);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
       


        
    }
}
