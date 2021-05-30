

using AutoMapper;
using Boticario.Domain.Models;
using Boticario.Domain.ViewModels;

namespace Boticario.Domain.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        /**
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });

        }
        **/

        public AutoMapperConfig()
        {
            CreateMap<ProductViewModel, Products>().ReverseMap();
            CreateMap<ProductUpdateViewModel, Products>().ReverseMap();
            CreateMap<InventoryViewModel, Inventory>().ReverseMap();
            CreateMap<WarehouseViewModel, Warehouses>().ReverseMap();

            
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src._id.ToString()));




        }
    }
}