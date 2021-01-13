using AutoMapper;
using Produto.Domain.DTO;
using Produto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produto.Application.Mapping
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<ProductDTO, Product >();
            CreateMap<InvenctoryDTO, Invenctory>();
            CreateMap<WareHouseDTO, WareHouse>();
        }
    
    }
}
