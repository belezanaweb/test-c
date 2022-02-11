using BelezaNaWeb.Domain.Model;
using System.Threading.Tasks;

namespace BelezaNaWeb.Domain.Repositories
{
    public interface IProductRepository
    {
        int Add(Product entity);

        int Update(Product entity);

        bool Delete(int sku);

        bool Exist(int sku);

        Product? Get(int sku);

        List<Product> List();
    }
}
