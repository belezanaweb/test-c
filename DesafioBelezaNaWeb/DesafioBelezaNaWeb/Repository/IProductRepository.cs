using DesafioBelezaNaWeb.Models;

namespace DesafioBelezaNaWeb.Repository
{
    public interface IProductRepository
    {
        (bool, Product) GetProduct(long sku);
        Product CreateProduct(Product product);
        void EditProduct(Product product);
        void DeleteProduct(long sku);
    }
}
