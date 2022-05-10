using API.ApiModels;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }


        [HttpGet("{sku}")]
        public ActionResult<ProductDTO> Get(int sku)
        {
            var product = this.productService.GetProduct(sku);

            if (product == null)
                return NotFound();

            return Ok(ProductDTO.FromProduct(product));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductCreateDTO productCreate)
        {
            if (productCreate is null)
                throw new ArgumentException($"{nameof(productCreate)} is null");

            var product = this.productService.InsertProduct(productCreate.ToProduct());

            return Ok(ProductDTO.FromProduct(product));
        }


        [HttpPut("{sku}")]
        public ActionResult Put(int sku, [FromBody] ProductCreateDTO productCreate)
        {

            if (productCreate is null)
                return BadRequest($"{nameof(productCreate)} is null");

            if (sku == 0)
                return BadRequest($"{nameof(sku)} is zero");

            if (!sku.Equals(productCreate.Sku))
                return BadRequest($"Product.{nameof(productCreate.Sku)} and {nameof(sku)} are differents");

            var product = productCreate.ToProduct();

            try
            {
                product = this.productService.UpdateProduct(sku, product);
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{sku}")]
        public ActionResult Delete(int sku)
        {
            if (sku == 0)
                return BadRequest($"{nameof(sku)} is zero");

            try
            {
                var deleted = this.productService.DeleteProduct(sku);


                return Ok("Product deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
