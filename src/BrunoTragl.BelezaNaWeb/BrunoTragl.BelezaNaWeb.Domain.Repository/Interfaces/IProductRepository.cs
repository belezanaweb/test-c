using BrunoTragl.BelezaNaWeb.Domain.Model;

namespace BrunoTragl.BelezaNaWeb.Domain.Repository.Interfaces
{
    public interface IProductRepository
    {
        Product Get(long sku);
        void Add(Product product);
        void Update(Product product);
        void Remove(long sku);
        bool Any(long sku);
    }
}
