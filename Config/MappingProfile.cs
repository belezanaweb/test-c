using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TesteBelezaNaWeb.API.Core.Entities;
using TesteBelezaNaWeb.API.Models.InputModels;
using TesteBelezaNaWeb.API.Models.ViewModel;

namespace TesteBelezaNaWeb.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Inventory, InventoryViewModel>().ReverseMap();
            CreateMap<Warehouse, WarehouseViewModel>().ReverseMap();


            CreateMap<CreateInventoryInputModel, Inventory>().ForMember(x => x.id, Opt => Opt.Ignore());
            CreateMap<CreateWarehouseInputModel, Warehouse>().ForMember(x => x.id, Opt => Opt.Ignore());
                
                
            CreateMap<Product, ProductViewModel>()
                 .ForPath(dest => dest.inventory, opt => opt.MapFrom(src => src.inventory))
                .ForPath(dest => dest.inventory.warehouses, opt => opt.MapFrom(src => src.inventory.warehouses))
                .ForAllOtherMembers(opt => opt.Ignore());


            CreateMap<CreateProductInputModel,Product>()
                 .ForPath(dest => dest.inventory, opt => opt.MapFrom(src => src.inventory))
                .ForPath(dest => dest.inventory.warehouses, opt => opt.MapFrom(src => src.inventory.warehouses))
                ;
        }
    }
}
