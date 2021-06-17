using AutoMapper;
using BoticarioAPI.Domain.Entities;
using BoticarioAPI.Domain.TransferObjects;

namespace BoticarioAPI.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductTO>();
            CreateMap<Warehouse, WarehouseTO>();
        }
    }
}
