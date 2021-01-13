using System;
using System.Collections.Generic;
using System.Text;

namespace Produto.Domain.DTO
{
    public class InvenctoryDTO
    {
        public IList<WareHouseDTO> WareHouses { get; set; }
    }
}
