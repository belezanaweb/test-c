using AutoMapper;

using BNWTC.Api.Models.Entities;
using BNWTC.Api.ViewModel;

namespace BNWTC.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<Inventory, InventoryViewModel>();
            CreateMap<InventoryViewModel, Inventory>();

            CreateMap<Warehouse, WarehouseViewModel>();
            CreateMap<WarehouseViewModel, Warehouse>();
        }
    }
}
