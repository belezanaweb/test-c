using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteVagaBoticario.Interfaces.ContratosDeServicos.Dados;
using TesteVagaBoticario.Interfaces.ContratosDeServicos.Servicos;

namespace TesteVagaBoticario.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IServiceProduct servico;

        public ProductController(IServiceProduct servico)
        {
            this.servico = servico;
        }

        [HttpPost]
        public IActionResult Save([FromBody] DtoProduct dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.servico.Save(dto);

                    return Ok("Cadastrado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest();
        }

        [HttpPut]
        public ActionResult Update([FromBody] DtoProduct dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.servico.Update(dto);

                    return Ok("Alterado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return BadRequest();
        }

        [HttpGet("{sku}")]
        public ActionResult Get(int sku)
        {
            try
            {
                var model = this.servico.Get(sku);

                if (model == null)
                {
                    return NotFound("Processo não encontrado!");
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{sku}")]
        public ActionResult Remove(int sku)
        {
            try
            {
                this.servico.Remove(sku);

                return Ok("Removido!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
