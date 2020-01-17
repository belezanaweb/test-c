using AutoMapper;
using DataAccess.DatabaseContext;
using DTO;
using Models;
using System.Linq;

namespace WebApi.Tests.Builder
{
    /// <summary>
    /// Builder for Products
    /// </summary>
    public class BuilderProduct
    {
        #region Methods

        /// <summary>
        /// Build a Product
        /// </summary>
        /// <returns></returns>
        public static Product BuildProduct(BelezaWebContext db, out int idItem, bool saveData = true)
        {
            idItem = 0;            

            var product = new Product
            {
              Sku = 909090,
              Name = "Test Product"
            };

            product.Warehouses.Add(new Models.Warehouse
            {
                Locality = "SP",
                Quantity = 250,
                Type = Common.WarehouseType.ECOMMERCE.ToString()
            });

            product.Warehouses.Add(new Models.Warehouse
            {
                Locality = "MOEMA",
                Quantity = 255,
                Type = Common.WarehouseType.PHYSICAL_STORE.ToString()
            });

            if (saveData)
            {
                db.Products.Add(product);
                db.SaveChanges();
                idItem = product.Id;
            }

            return product;
        }
       
        /// <summary>
        /// Build a Product
        /// </summary>
        /// <returns></returns>
        public static ProductDTO BuildProductDTO(BelezaWebContext db, out int idItem, bool saveData = true)
        {
            var product = BuildProduct(db, out idItem, saveData);

            //Configure a map for model and list of models inside
            var config = GetMapperConfigurationToProductDTO();

            //Create a Imapper
            IMapper iMapper = config.CreateMapper();
            var domainDto = iMapper.Map<Product, ProductDTO>(product);

            return domainDto;
        }

        #endregion
        
        #region Private Methods

        /// <summary>
        /// Get a config for convert from Product to ProductDTO
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        private static MapperConfiguration GetMapperConfigurationToProductDTO()
        {
            //Configure a map for model 
            var config = new MapperConfiguration(cfg =>
            {
                //Map a model 
                cfg.CreateMap<Product, ProductDTO>()
                    .ForMember(dest => dest.Inventory,
                        opts => opts.MapFrom(src => new InventoryDTO
                        {
                            Warehouses = src.Warehouses.Select(w => new WarehouseDTO { Locality = w.Locality, Quantity = w.Quantity, Type = w.Type.ToString() }).ToList()
                        }));

                cfg.CreateMap<Warehouse, WarehouseDTO>();
            });

            return config;
        }

        #endregion
    }
}
