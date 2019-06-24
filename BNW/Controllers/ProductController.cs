using BNW.App.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BNW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _app;
        public ProductController(IProductApplication app)
        {
            _app = app;
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<Product> GetProductBySku(int id) => await _app.GetById(id);

        [HttpPost]
        [Route("create")]
        public async void CreateProduct([FromBody] Product produto) => _app.Add(produto);

        [HttpPut]
        [Route("update")]
        public async void UpdateProduct([FromBody] Product produto) => _app.Update(produto);

        [HttpDelete]
        public async void Delete(Product produto) => _app.Remove(produto);
    }
}
