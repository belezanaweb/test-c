using AutoMapper;
using BoticarioAPI.Domain.Entities;
using BoticarioAPI.Domain.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
