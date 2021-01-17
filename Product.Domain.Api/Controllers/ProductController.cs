using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Product.Domain.Commands;
using Product.Domain.Entities;
using Product.Domain.Handlers;
using Product.Domain.Repositories;

namespace Product.Domain.Api.Controllers
{
    /// <summary>
    /// API de Produtos
    /// </summary>
    [Route("v1/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Obtem produto por sku
        /// </summary>
        /// <param name="sku">O Sku do produto</param>
        /// <returns></returns>        
        [Route("")]
        [HttpGet]
        public Entities.Product GetBySku([FromBody] int sku,
            [FromServices] IProductRepository repository 
        )
        {
            return repository.GetBySku(sku);
        }

        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <param name="product">As informações do produto a ser cadastrado</param>
        /// <returns></returns>       
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateProductCommand product, [FromServices] ProductHandler handler)
        {
            return (GenericCommandResult)handler.Handle(product);
        }

        /// <summary>
        /// Edita um produto existente
        /// </summary>
        /// <param name="product">As informações editadas do produto, incluindo o sku anterior </param>
        /// <returns></returns>       
        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateProductCommand product, [FromServices] ProductHandler handler)
        {
            return (GenericCommandResult)handler.Handle(product);
        }

        /// <summary>
        /// Deleta produto por sku
        /// </summary>
        /// <param name="command">O Sku do produto a ser deletado</param>
        /// <returns></returns>        
        [Route("")]
        [HttpDelete]
        public GenericCommandResult Delete([FromBody] DeleteProductCommand command, [FromServices] ProductHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }



    }
}
