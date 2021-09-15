using AutoMapper;
using Projeto.Domain.Models;
using Projeto.Produtos.Api.Request;
using Projeto.Produtos.Api.ViewModel;

namespace Projeto.Produtos.Api.Configuration
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<ProdutoRequest, Produto>();
            CreateMap<WarehouseRequest, Warehouse>();
            CreateMap<Warehouse, WarehouseViewModel>();
        }
    }
}
