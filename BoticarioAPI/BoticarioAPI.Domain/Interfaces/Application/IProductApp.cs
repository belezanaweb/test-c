using BoticarioAPI.Domain.TransferObjects;

namespace BoticarioAPI.Domain.Interfaces.Application
{
    public interface IProductApp
    {
        bool Add(NewProductTO newProduct);
        bool Update(NewProductTO product);
        ProductTO Get(int sku);
        bool Delete(int sku);
    }
}
