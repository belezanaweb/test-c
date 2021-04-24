﻿using AutoMapper;
using Boticario.Api.ViewModels;
using Boticario.Domain.Entities;

namespace Boticario.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        #region Constructors

        public AutomapperConfig()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Inventory, InventoryViewModel>().ReverseMap();
            CreateMap<Warehouse, WarehouseViewModel>().ReverseMap();
        }

        #endregion
    }
}