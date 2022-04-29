using AutoMapper;
using BackEndTest.Application.DTOs;
using BackEndTest.Domain.Entities;

namespace BackEndTest.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Inventory, InventoryDTO>().ReverseMap();
            CreateMap<Warehouse, WarehouseDTO>().ReverseMap();
        }
    }
}
