using AutoMapper;
using Belezanaweb.Application.Products.Commands;
using Belezanaweb.Application.Products.ViewModels;
using Belezanaweb.Domain.Products.Entity;
using System.Linq;

namespace Belezanaweb.Application.Profiles.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<BaseProductCommand, Product>()
                .ForMember(dest => dest.Inventory, opt => opt.MapFrom(src => src.Inventory));

            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Inventory, opt => opt.MapFrom(src => src.Inventory))
                .ForMember(dest => dest.IsMarketable, opt => opt.MapFrom(src => src.Inventory.Warehouses.Any(w => w.Quantity > 0)));
        }
    }
}
