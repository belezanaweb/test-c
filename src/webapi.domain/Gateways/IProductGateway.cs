using webapi.domain.Entities;
using webapi.domain.Gateways.Abstractions.Respository;

namespace webapi.domain.Gateways
{
    public interface IProductGateway : IRepositoryGateway<Product, int>
    {
         
    }
}