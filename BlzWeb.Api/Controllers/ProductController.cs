using BlzWeb.Domain.StoreContext.CustomerCommands.Inputs;
using BlzWeb.Domain.StoreContext.Entities;
using BlzWeb.Domain.StoreContext.Handlers;
using BlzWeb.Domain.StoreContext.Queries;
using BlzWeb.Domain.StoreContext.Repositories;
using BlzWeb.Domain.StoreContext.Services;
using BlzWeb.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BlzWeb.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly ProductHandler _handler;

        public ProductController(IProductService service, ProductHandler handler)
        {
            _service = service;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/products/{sku}")]
        public Product Get(int sku)
        {
            return _service.Get(sku);            
        }

        [HttpDelete]
        [Route("v1/products/{sku}")]
        public ICommandResult Delete(int sku)
        {
            var result = (CommandResult)_handler.Delete(sku);
            return result;
        }

        [HttpPost]
        [Route("v1/products")]
        public ICommandResult Post([FromBody]CreateProductCommand command)
        {
            var result = (CommandResult)_handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/products")]
        public ICommandResult Put([FromBody]UpdateProductCommand command)
        {
            var result = (CommandResult)_handler.Handle(command);
            return result;
        }
    }
}