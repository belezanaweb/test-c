using BW.Application;
using BW.Application.Repository.Product;
using BW.Domain;
using NoDb;
using System.Linq;
using System.Threading.Tasks;

namespace BW.INFRA
{
    public class ProductRepository : IProductRepositoryReadOnlyRepository, IProductRepositoryrWriteOnlyRepository
    {
        private readonly IBasicCommands<ProductDomain> _productDBWrite;
        private readonly IBasicQueries<ProductDomain> _productDBRead;
        const string DB = "BELEZA_NA_WEB";

        public ProductRepository(
            IBasicCommands<ProductDomain> productDBWrite,
            IBasicQueries<ProductDomain> productDBRead
            )
        {
            _productDBWrite = productDBWrite;
            _productDBRead = productDBRead;
        }

        public async Task<ProductDomain> Get(int sku)
        {
            var listDB = await _productDBRead.GetAllAsync(DB).ConfigureAwait(false);
            
            if (listDB.Any())
            {
                return listDB.Where(x => x.Sku.Equals(sku)).FirstOrDefault();
            }

            return null;
        }
        public async Task Add(ProductDomain product)
        {               
            await _productDBWrite.CreateAsync(DB, product.Sku.ToString(), product);

        }
        public async Task Delete(int sku)
        {
            await _productDBWrite.DeleteAsync(DB, sku.ToString());
        }        
        public async Task Update(ProductDomain product)
        {            
            await _productDBWrite.UpdateAsync(DB, product.Sku.ToString(), product);
        }
    }
}
