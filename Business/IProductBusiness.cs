using Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IProductBusiness
    {
        public Task<List<ReturnProductViewModel>> GetAll();
        public Task<ReturnProductViewModel> GetBySKU(int sku);
        public Task<bool> Exists(int sku);
        public Task<ReturnProductViewModel> Add(ProductViewModel model);
        public Task<ReturnProductViewModel> Update(ProductViewModel model);
        public Task Remove(int sku);
    }
}
