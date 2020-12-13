using Desafio.Domain.Models;

namespace Desafio.Domain.Interfaces
{
    public interface IProductRepository
    {
        void Create(Product product);
        bool Exists(int sku);
        Product Read(int sku);
        void Update(Product product);
        void Delete(int sku);
    }
}