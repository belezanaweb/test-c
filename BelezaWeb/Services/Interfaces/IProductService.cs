using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    /// <summary>
    /// Interface for Product Service
    /// </summary>
    public interface IProductService
    {
        #region Methods

        /// <summary>
        /// Check if the  product exists by SKU
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        Task<bool> ProductExists(int sku);

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<ProductDTO> CreateProduct(ProductDTO product);

        /// <summary>
        /// Edit a product
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<ProductDTO> EditProduct(int sku, ProductDTO product);

        /// <summary>
        /// Get product by SKU
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        Task<ProductDTO> GetProduct(int sku);

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        Task<IList<ProductDTO>> GetProducts();

        /// <summary>
        /// Delete product by SKU
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        Task<bool> DeleteProduct(int sku);

        #endregion
    }
}
