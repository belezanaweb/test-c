using Domain.Dtos;
using System;
using System.Collections.Generic;

namespace Domain.Services.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        long Register(ProductCreateDto dto);
        IEnumerable<ProductListDto> GetAll();
        ProductListDto GetById(long id);
        long Update(ProductUpdateDto dto);
        void Remove(long id);
    }
}
