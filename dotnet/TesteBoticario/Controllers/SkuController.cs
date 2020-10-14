using Domain;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TesteBoticario.ViewModels;

namespace TesteBoticario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkuController : ControllerBase
    {
        private readonly IStockKeepingUnitRepository repository;

        public SkuController(IStockKeepingUnitRepository repository)
        {
            this.repository = repository;
        }
        /// <summary>
        /// Gets sku details
        /// </summary>
        /// <param name="sku">sku number</param>
        /// <returns>StockKeepingUnit</returns>
        [HttpGet]
        public ActionResult Get([FromQuery] int? sku)
        {
            if (sku.HasValue)
            {
                var resultado = repository.GetBySku(sku.Value);
                if (resultado != null)
                    return Ok(new StockKeepingUnitVM(resultado));
                else
                    return NotFound();
            }
            else
            {
                return Ok(repository.GetAll().Select(x => new StockKeepingUnitVM(x)));
            }
        }
        /// <summary>
        /// Adds sku
        /// </summary>
        /// <param name="sku"></param>
        /// <returns>Added sku</returns>
        [HttpPost]
        public ActionResult Post([FromBody] StockKeepingUnit sku)
        {
            try
            {
                return Ok(repository.Add(sku));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Alter sku
        /// </summary>
        /// <param name="sku"></param>
        /// <returns>Altered sku</returns>
        [HttpPut]
        public ActionResult Put(StockKeepingUnit sku)
        {
            try
            {
                return Ok(repository.Update(sku));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Remove sku
        /// </summary>
        /// <param name="sku">sku number</param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete([FromQuery] int sku)
        {
            try
            {
                repository.Delete(sku);
                return Ok($"Sucesso ao excluir SKU {sku}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
