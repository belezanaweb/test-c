using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBelezaNaWeb.API.Core.Entities;
using TesteBelezaNaWeb.API.Models.InputModels;
using TesteBelezaNaWeb.API.Models.ViewModel;
using TesteBelezaNaWeb.API.Persistence;

namespace TesteBelezaNaWeb.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper, ProductDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;

        }

      
        [HttpGet("{sku}")]
        public IActionResult Get(int sku)
        {
            Product product = _dbContext.Products.Include(x => x.inventory).Include(x => x.inventory.warehouses).SingleOrDefault(x => x.sku == sku);
            
            if (product == null)
                return NotFound();

             
            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(product);
      
            return Ok(productViewModel);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> lstProduct = _dbContext.Products.Include(x => x.inventory).Include(x => x.inventory.warehouses).ToList();

            if (lstProduct.Count() == 0)
                return NotFound();

            List<ProductViewModel> lstProductViewModel = _mapper.Map<List<ProductViewModel>>(lstProduct);

            return Ok(lstProductViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductInputModel inputModel)
        {
            Product product = _dbContext.Products.SingleOrDefault(x => x.sku == inputModel.sku);

            if (product != null)
            {
                throw new Exception("Dois produtos são considerados iguais se os seus skus forem iguais");
            }

             product = _mapper.Map<Product>(inputModel);
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { sku = product.sku }, inputModel);
        }


        [HttpPut]
        public IActionResult Put([FromBody] CreateProductInputModel inputModel)
        {
            Product product = _dbContext.Products.Include(x => x.inventory).Include(x => x.inventory.warehouses).SingleOrDefault(x => x.sku == inputModel.sku);

            if (product == null)
                return NotFound();

            Product productUpdate = (Product)_mapper.Map(inputModel,product, typeof(CreateProductInputModel),typeof(Product) );
            foreach (var warehouse in productUpdate.inventory.warehouses)
            {
                product = _dbContext.Products.Include(x => x.inventory).Include(x => x.inventory.warehouses).SingleOrDefault(x => x.sku == inputModel.sku);
                warehouse.id = product.inventory.warehouses.Where(x => x.type == warehouse.type).SingleOrDefault().id;
            }

            _dbContext.Products.Update(productUpdate);
            _dbContext.SaveChanges();


            return CreatedAtAction(nameof(Get), new { sku = product.sku }, inputModel);
        }


        [HttpDelete("{sku}")]
        public IActionResult Delete(int sku)
        {
            var product = _dbContext.Products.Include(x => x.inventory).Include(x => x.inventory.warehouses).SingleOrDefault(x => x.sku == sku);

            if (product == null)
                return NotFound();

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
