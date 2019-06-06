using System.Collections.Generic;
using Domain.Dtos;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;
using System.Linq;
using System;

namespace Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductListDto> GetAll()
        {
            return AutoMapper.Mapper.ToListDto(_productRepository.GetAll().ToList());
        }

        public ProductListDto GetById(long id)
        {
            return AutoMapper.Mapper.ToDtolist(_productRepository.GetById(id));
        }

        public long Register(ProductCreateDto dto)
        {
            var sku = _productRepository.Add(AutoMapper.Mapper.ToCreateDomain(dto));

            if (!(sku > 0))
                throw new ApplicationException("Error Product Insert");

            return sku;
        }

        public void Remove(long sku)
        {
            _productRepository.Remove(sku);
            if (!(_productRepository.SaveChanges() > 0))
                throw new ApplicationException("Error Product Delete");
        }

        public long Update(ProductUpdateDto dto)
        {
            var sku = _productRepository.Update(AutoMapper.Mapper.ToUpdateDomain(dto));
            if(!(sku > 0))
                throw new ApplicationException("Error Product Update");
            return sku;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
