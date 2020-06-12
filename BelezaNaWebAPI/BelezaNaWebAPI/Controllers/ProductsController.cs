using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BelezaNaWebAPI.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using BelezaNaWebAPI.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace BelezaNaWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        Repo.IProductsRepo ProductsRepo { get; }
        IMapper Mapper { get; }
        ILogger Logger { get; }

        public ProductsController(IProductsRepo productsRepo, IMapper mapper, ILogger<ProductsController> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            ProductsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
        }

        /// <summary>
        /// Get a product by sku
        /// </summary>
        /// <param name="sku">A product sku</param>
        [ProducesResponseType(typeof(Dto.Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("{sku}")]
        public Dto.Product GetBySku(int sku)
        {
            Model.Product product = ProductsRepo.GetBySku(sku);
            product.inventory.quantity = product.inventory.warehouses.Sum(a => a.quantity);
            product.isMarketable = product.inventory.quantity > 0;
            return Mapper.Map<Dto.Product>(product);
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="sku">A new product sku</param>
        /// <param name="newProductDto">New product data</param>
        /// <response code="201">The created product</response>
        [ProducesResponseType(typeof(Dto.Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("{sku}")]
        public IActionResult Create(int sku, [FromBody] Dto.UpdateProduct newProductDto)
        {
            var newProduct = new Model.Product(sku);
            Mapper.Map(newProductDto, newProduct);
            ProductsRepo.Create(newProduct);

            var createdProduct = ProductsRepo.GetBySku(sku);

            Logger.LogInformation("New product was created: {@product}", createdProduct);

            return Created($"{sku}", Mapper.Map<Dto.Product>(createdProduct));
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="sku">sku of the product to update</param>
        /// <param name="productDto">Product data</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [Route("{sku}")]
        public IActionResult Update(int sku, [FromBody] Dto.UpdateProduct productDto)
        {
            var product = ProductsRepo.GetBySku(sku);
            Mapper.Map(productDto, product);
            ProductsRepo.Update(product);
            return Ok();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="sku">sku of the product to delete</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [Route("{sku}")]
        public IActionResult Delete(int sku)
        {
            ProductsRepo.Delete(sku);
            return Ok();
        }
    }
}
