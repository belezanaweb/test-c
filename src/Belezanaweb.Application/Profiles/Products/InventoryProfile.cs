using AutoMapper;
using Belezanaweb.Application.Products.DTOs;
using Belezanaweb.Application.Products.ViewModels;
using Belezanaweb.Domain.Products.Entity;
using System.Linq;

namespace Belezanaweb.Application.Profiles.Products
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryDTO, Inventory>()
                .ForMember(dest => dest.Warehouses, opt => opt.MapFrom(src => src.Warehouses));

            CreateMap<Inventory, InventoryViewModel>()
                .ForMember(dest => dest.Warehouses, opt => opt.MapFrom(src => src.Warehouses))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Warehouses.Sum(w => w.Quantity)));
                
        }
    }
}
