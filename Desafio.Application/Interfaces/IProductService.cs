using Desafio.Application.ViewModels.CreateUpdate;
using Desafio.Application.ViewModels.Read;
using Desafio.Domain.Command;

namespace Desafio.Application.Interfaces
{
    public interface IProductService
    {
        CommandResult Create(ProductCreateUpdateReadViewModel viewModel);
        ProductReadViewModel Read(int sku);
        CommandResult Update(ProductCreateUpdateReadViewModel viewModel);
        CommandResult Delete(int sku);
    }
}