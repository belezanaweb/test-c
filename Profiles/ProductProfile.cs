using AutoMapper;
using Inventory.api.Models;
using Inventory.api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<string, string>().ConvertUsing(s => s ?? "");

            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.sku, opt => opt.MapFrom(src => src.sku))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForPath(dest => dest.inventory.quantity, opt => opt.MapFrom(src => src.inventory.quantity))
                .ForPath(dest => dest.inventory.warehouses, opt => opt.MapFrom(src => src.inventory.warehouses))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}