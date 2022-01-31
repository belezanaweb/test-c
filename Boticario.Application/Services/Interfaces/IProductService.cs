using Boticario.Application.InputModels;
using Boticario.Application.ViewModels;

namespace Boticario.Application.Services.Interfaces
{
    public interface IProductService
    {
        int Create(NewProductInputModel inputModel);
        void Update(UpdateProductInputModel inputModel);
        void Delete(int sku);
        ProductDetailsViewModel GetBySku(int sku);
    }
}
