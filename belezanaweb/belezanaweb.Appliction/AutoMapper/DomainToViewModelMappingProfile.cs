using AutoMapper;
using belezanaweb.Domain.Entities;
using belezanaweb.Domain.ViewModels.Inventory;
using belezanaweb.Domain.ViewModels.Product;

namespace belezanaweb.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<Inventory, InventoryViewModel>();
        }
    }
}
