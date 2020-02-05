using AutoMapper;
using BelezaNaWeb.Domain.Produtos;
using BelezaNaWeb.Service.ViewModels;

namespace BelezaNaWeb.Service.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<InventoryViewModel, Inventory>();
            CreateMap< WarehouseViewModel,Warehouse > ();
        }
    }
}
