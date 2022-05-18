using AutoMapper;
using Belezanaweb.Application.Products.DTOs;
using Belezanaweb.Application.Products.ViewModels;
using Belezanaweb.Domain.Products.Entity;

namespace Belezanaweb.Application.Profiles.Products
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<WarehouseDTO, Warehouse>();

            CreateMap<Warehouse, WarehouseViewModel>();
        }
    }
}
