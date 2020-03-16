using BelezaNaWeb.Application.ViewModels;
using BelezaNaWeb.Domain.Models;

namespace BelezaNaWeb.Application.Interfaces
{
    public interface IMapper
    {
        ProductViewModel Map(Product product);
        Product Map(ProductViewModel productViewModel);
    }
}
