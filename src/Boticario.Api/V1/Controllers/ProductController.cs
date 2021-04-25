using AutoMapper;
using Boticario.Api.Controllers;
using Boticario.Api.ViewModels;
using Boticario.Domain.Entities;
using Boticario.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Boticario.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : MainApiController
    {
        #region Properties

        private readonly IMapper _mapper;
        private readonly IProductApplication _iProductApplication;

        #endregion

        #region Constructors

        public ProductController(INotificator notificator, IMapper mapper, IProductApplication iProductApplication) : base(notificator)
        {
            _mapper = mapper;
            _iProductApplication = iProductApplication;
        }

        #endregion

        #region Public Methods

        [HttpGet("GetAll")]
        public ActionResult<IList<ProductViewModel>> GetAll()
        {
            var products = _mapper.Map<IList<ProductViewModel>>(_iProductApplication.GetAll());

            return CustomResponse(products);
        }

        [HttpGet("GetBySku/{sku}")]
        public ActionResult<ProductViewModel> GetBySku(uint sku)
        {
            var product = _mapper.Map<ProductViewModel>(_iProductApplication.GetBySku(sku));

            if (product != null)
                return CustomResponse(product);

            return CustomResponse();
        }

        [HttpPost("Create")]
        public ActionResult Create(ProductViewModel productModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var product = _iProductApplication.Create(_mapper.Map<Product>(productModel));

            return CustomResponse(product);
        }

        [HttpPut("Update")]
        public ActionResult Update(ProductViewModel productModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var product = _iProductApplication.Update(_mapper.Map<Product>(productModel));

            return CustomResponse(product);
        }

        [HttpDelete("DeleteBySku/{sku}")]
        public ActionResult DeleteBySku(uint sku)
        {
            _iProductApplication.DeleteBySku(sku);

            return CustomResponse("Produto deletado com sucesso!");
        }

        #endregion
    }
}