using GrupoBoticarioTeste.Business.ViewModels;
using System;

namespace GrupoBoticarioTeste.Business.Interfaces.Services
{
    public interface IProductService : IDisposable
    {
        bool Add(ProductViewModel product);
        bool Change(int sku, ChangeViewModel changeViewModel);
        SearchProductViewModel SearchById(int sku);
        bool Remove(int sku);
    }
}
