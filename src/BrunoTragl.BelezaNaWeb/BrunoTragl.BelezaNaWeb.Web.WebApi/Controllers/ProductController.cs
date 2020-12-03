using AutoMapper;
using BrunoTragl.BelezaNaWeb.Application.Services.Interfaces;
using BrunoTragl.BelezaNaWeb.Domain.Model;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Enumerable;
using BrunoTragl.BelezaNaWeb.Web.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrunoTragl.BelezaNaWeb.Web.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : MainController
    {
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService,
                                 IInventoryService inventoryService,
                                 IMapper mapper,
                                 ILogger<MainController> mainLogger)
            : base(mainLogger)
        {
            _productService = productService;
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        [HttpGet("{sku:long}")]
        public IActionResult Get(long sku)
        {
            try
            {
                var product = _productService.Get(sku);
                if (product == null)
                    return NotFound();

                ProductModel productModel = _mapper.Map<ProductModel>(product);

                uint quantity = _inventoryService.CalculateInventory(productModel.Sku);
                productModel.Inventory.SetQuantity(quantity);

                bool isMarketable = _productService.IsMarketable(productModel.Sku);
                productModel.SetIsMarketable(isMarketable);

                return OkResult(Resources.Product, productModel);
            }
            catch (Exception ex)
            {
                return InternalServerErrorResponse(Resources.Product, ex);
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

                    string uri = $"{Request.Host}{Request.Path}/{productModel.Sku}";
                    return CreatedResult(Resources.Product, uri, productModel);
                }

                return BadRequestResult(Resources.Product, GetModelStateErrors(ModelState));
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

                return BadRequestResult(Resources.Product, GetModelStateErrors(ModelState));
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
