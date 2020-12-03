using AutoMapper;
using BrunoTragl.BelezaNaWeb.Domain.Model;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Inventory, InventoryModel>().ReverseMap();
            CreateMap<Warehouse, WarehouseModel>().ReverseMap();
        }
    }
}
