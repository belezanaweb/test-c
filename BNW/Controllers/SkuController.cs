using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BNW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkuController : ControllerBase
    {
        [HttpGet("{id}", Name = "Get")]
        public string GetProductBySku(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("create")]
        public void CreateProduct([FromBody] Product produto)
        {
        }

        [HttpPut("{id}")]
        [Route("update")]
        public void UpdateProduct(int id, [FromBody] Product produto)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
