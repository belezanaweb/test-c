using BrunoTragl.BelezaNaWeb.Domain.Model;

namespace BrunoTragl.BelezaNaWeb.Application.Services.Interfaces
{
    public interface IProductService
    {
        Product Get(long sku);
        void Add(Product product);
        void Update(Product product);
        void Remove(long sku);
        bool Any(long sku);
        bool IsMarketable(long sku);
    }
}
