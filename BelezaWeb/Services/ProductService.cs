using AutoMapper;
using DataAccess.DatabaseContext;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Service for products
    /// </summary>
    public class ProductService : IProductService
    {
        #region Fields

        private BelezaWebContext _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context"></param>
        public ProductService(BelezaWebContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check if the  product exists by SKU
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public async Task<bool> ProductExists(int sku)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(i => i.Sku == sku);
                return await Task.FromResult<bool>(product != null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<ProductDTO> CreateProduct(ProductDTO product)
        {
            try
            {
                //Configure a map 
                var config = GetMapperConfigurationToProduct();

                //Create a Imapper
                IMapper iMapper = config.CreateMapper();
                var productToSave = iMapper.Map<ProductDTO, Product>(product);
                
                _context.Products.Add(productToSave);
                _context.SaveChanges();

                var itemResult = GetProduct(productToSave.Sku).Result;
                return await Task.FromResult<ProductDTO>(itemResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Edit a product
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<ProductDTO> EditProduct(int sku, ProductDTO product)
        {
            try
            {
                var productDb = _context.Products.FirstOrDefault(i => i.Sku == sku);

                if (productDb == null)
                    return null;

                //remove old warehouses
                var warehouses = _context.Warehouses.Where(i => i.ProductId == productDb.Id).ToList();
                _context.Warehouses.RemoveRange(warehouses);
                _context.SaveChanges();

                //Configure a map 
                var config = GetMapperConfigurationToProduct();

                //Create a Imapper
                IMapper iMapper = config.CreateMapper();
                iMapper.Map<ProductDTO, Product>(product, productDb);
                productDb.Sku = sku;

                _context.Products.Update(productDb);
                _context.SaveChanges();

                var itemResult = GetProduct(sku).Result;
                return await Task.FromResult<ProductDTO>(itemResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get product by SKU
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public async Task<ProductDTO> GetProduct(int sku)
        {
            try
            {
                var productDb = _context.Products.Include(i => i.Warehouses).FirstOrDefault(i => i.Sku == sku);

                if (productDb == null)
                    return null;

                //Configure a map 
                var config = GetMapperConfigurationToProductDTO();

                //Create a Imapper
                IMapper iMapper = config.CreateMapper();
                var productResult = iMapper.Map<Product, ProductDTO>(productDb);

                return await Task.FromResult<ProductDTO>(productResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ProductDTO>> GetProducts()
        {
            try
            {
                var productDb = _context.Products.Include(i => i.Warehouses).ToList();

                if (productDb == null)
                    return null;

                //Configure a map 
                var config = GetMapperConfigurationToProductDTO();

                //Create a Imapper
                IMapper iMapper = config.CreateMapper();
                var productsResult = iMapper.Map<IList<Product>, IList<ProductDTO>>(productDb);

                return await Task.FromResult<IList<ProductDTO>>(productsResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete product by SKU
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProduct(int sku)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(i => i.Sku == sku);

                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();

                    return await Task.FromResult<bool>(true);
                }
                return await Task.FromResult<bool>(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get a config for convert from Product to ProductDTO
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        private MapperConfiguration GetMapperConfigurationToProductDTO()
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

        /// <summary>
        /// Get a config for convert from ProductDTO to Product
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        private MapperConfiguration GetMapperConfigurationToProduct()
        {
            //Configure a map for model 
            var config = new MapperConfiguration(cfg =>
            {
                //Map a model 
                cfg.CreateMap<ProductDTO, Product>()
                    .ForMember(dest => dest.Warehouses,
                         opts => opts.MapFrom(src => src.Inventory != null ? 
                            src.Inventory.Warehouses.Select(w => 
                                new Warehouse { Locality = w.Locality, Quantity = w.Quantity, Type = w.Type }).ToList() : new List<Warehouse>()
                         ));

                cfg.CreateMap<WarehouseDTO, Warehouse>();
            });

            return config;
        }

        #endregion
    }
}
