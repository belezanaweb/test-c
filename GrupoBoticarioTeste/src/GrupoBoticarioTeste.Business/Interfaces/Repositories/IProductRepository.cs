using GrupoBoticarioTeste.Business.Models;
using GrupoBoticarioTeste.Business.ViewModels;

namespace GrupoBoticarioTeste.Business.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product BuscarProdutoPorSku(int sku);
        SearchProductViewModel ListProdutoPorSku(int sku);
    }
}
