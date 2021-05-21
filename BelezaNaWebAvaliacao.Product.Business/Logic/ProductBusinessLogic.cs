using BelezaNaWebAvaliacao.DataAccess;
using BelezaNaWebAvaliacao.DataAccess.Repositories;
using System.Threading.Tasks;
using models = BelezaNaWebAvaliacao.Models;
namespace BelezaNaWebAvaliacao.Product.Business.Logic
{
    public class ProductBusinessLogic
    {
        private readonly DataContext _context;
        private readonly RepositoryProduct _repositoryProduct;

        public ProductBusinessLogic(DataContext context)
        {
            _context = context;
            _repositoryProduct = new RepositoryProduct(_context);
        }

        public async Task<string> CreateProduct(models.Product product)
        {
            var producExisting = await GetProduct(product.Sku);

            if (producExisting != null)
            {
                return "Já existe produto com o sku informado!";
            }

            return await _repositoryProduct.insertProduct(product);

        }

        public async Task<models.Product> GetProduct(int sku)
        {

            return await _repositoryProduct.GetProduct(sku);

        }

        public async Task<string> UpdateProduct(models.Product product, int sku)
        {
            var producExisting = await GetProduct(sku);

            if (producExisting == null)
            {
                return "Não existe produto com o sku informado!";
            }

            return await _repositoryProduct.UpdateProduct(sku, product);
        }

        public async Task<string> DeleteProduct(int sku)
        {
            var producExisting = await GetProduct(sku);

            if (producExisting == null)
            {
                return "Não existe produto com o sku informado!";
            }

            return await _repositoryProduct.DeleteProduct(sku);
        }



    }
}
