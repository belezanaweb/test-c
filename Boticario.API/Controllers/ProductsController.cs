using Boticario.API.Data.Repositories;
using Boticario.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Boticario.API.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }        

        [HttpPost]
        public IActionResult Post([FromBody] CreateProduct model)
        {
            try
            {
                var product = _repository.GetBySku(model.Sku);

                if (product != null)
                    return NotFound("Produto já existente.");

                _repository.Add(model);

                if (_repository.SaveChanges())
                    return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpGet("{sku}")]
        public IActionResult GetBySku(int sku)
        {
            try
            {
                var product = _repository.GetBySku(sku);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{sku}")]
        public IActionResult Put(int sku, [FromBody] Product model)
        {
            try
            {
                var product = _repository.GetBySku(sku);

                if (product == null)
                    return NotFound();

                _repository.Update(product);

                if (_repository.SaveChanges())
                    return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }        

        [HttpDelete("{sku}")]
        public IActionResult Delete(int sku)
        {
            try
            {
                var product = _repository.GetBySku(sku);

                if (product == null)
                    return NotFound();

                _repository.Delete(product);

                if (_repository.SaveChanges())
                    return Ok("Deletado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}
