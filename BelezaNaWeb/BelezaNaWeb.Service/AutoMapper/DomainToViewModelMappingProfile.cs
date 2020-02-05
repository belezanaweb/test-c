using AutoMapper;
using BelezaNaWeb.Domain.Produtos;
using BelezaNaWeb.Service.ViewModels;

namespace BelezaNaWeb.Service.AutoMapper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Inventory, InventoryViewModel>();
            CreateMap<Warehouse, WarehouseViewModel>();
        }
    }
}
