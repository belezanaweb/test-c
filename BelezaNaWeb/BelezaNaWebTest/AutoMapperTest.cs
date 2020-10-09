using AutoMapper;
using BelezaNaWebApi.Model;
using BelezaNaWebDomain;

namespace BelezaNaWebTest
{
    public static class AutoMapperTest
    {
        public static IMapper GetMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<ProductModel, Product>();
                cfg.CreateMap<InventoryModel, Inventory>();
                cfg.CreateMap<Inventory, InventoryModel>();
                cfg.CreateMap<Warehouse, WarehouseModel>();
                cfg.CreateMap<WarehouseModel, Warehouse>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}