using AutoMapper;
using BrunoTragl.BelezaNaWeb.Application.Services.Interfaces;
using BrunoTragl.BelezaNaWeb.Domain.Model;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService,
                                 IInventoryService inventoryService,
                                 IMapper mapper,
                                 ILogger<ProductController> logger)
        {
            _productService = productService;
            _inventoryService = inventoryService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{sku:long}")]
        public IActionResult Get(long sku)
        {
            try
            {
                var product = _productService.Get(sku);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Create(ProductModel productModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productService.Add(_mapper.Map<Product>(productModel));

                    uint quantity = _inventoryService.CalculateInventory(productModel.Sku);
                    productModel.Inventory.SetQuantity(quantity);

                    bool isMarketable = _productService.IsMarketable(productModel.Sku);
                    productModel.SetIsMarketable(isMarketable);

                    return Created($"{Request.Host}{Request.Path}/{productModel.Sku}", productModel);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{sku:long}")]
        public IActionResult Update(long sku, ProductModel productModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_productService.Any(sku))
                        return NotFound();

                    _productService.Update(_mapper.Map<Product>(productModel));
                    return NoContent();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{sku:long}")]
        public IActionResult Remove(long sku)
        {
            try
            {
                if (!_productService.Any(sku))
                    return NotFound();

                _productService.Remove(sku);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
