using AutoMapper;
using belezanaweb.Domain.Entities;
using belezanaweb.Domain.ViewModels.Inventory;
using belezanaweb.Domain.ViewModels.Product;

namespace belezanaweb.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<InventoryViewModel, Inventory>();
        }
    }
}
