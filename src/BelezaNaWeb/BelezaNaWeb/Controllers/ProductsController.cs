using System;
using System.Collections.Generic;
using AutoMapper;
using BelezaNaWeb.Application.Products.Interfaces;
using BelezaNaWeb.Core.Products.Exceptions;
using BelezaNaWeb.Domain.Products.Entities;
using BelezaNaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BelezaNaWeb.Controllers
{
    public class ProductsController : Controller
    {
        private IMapper _mapper;
        private IProductService _service;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("/products")]
        public IEnumerable<Product> GetAll()
        {
            return _service.Get();
        }

        [HttpGet("/products/{sku}")]
        public ActionResult Get(long sku)
        {
            var product = _service.Get(sku);

            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }

        [HttpPost("/products")]
        public ActionResult Post([FromBody]ProductViewModel product)
        {
            try
            {
                _service.Save(_mapper.Map<ProductViewModel, Product>(product));
                return StatusCode(201);
            }
            catch(ExistingSkuException)
            {
                return BadRequest(new { erro = "Dois produtos são considerados iguais se os seus skus forem iguais" });
            }
        }

        [HttpPut("/products/{sku}")]
        public IActionResult Put(long sku, [FromBody] ProductViewModel product)
        {
            product.Sku = sku;
            _service.Update(_mapper.Map<ProductViewModel, Product>(product));
            return StatusCode(200);
        }

        [HttpDelete("/products/{sku}")]
        public ActionResult Delete(long sku)
        {
            _service.Delete(sku);
            return Ok();
        }
    }
}
