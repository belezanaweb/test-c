using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Produto.Domain.Models
{
    public class Invenctory: Entity
    {
        public int Quantity { get { return  this.WareHouses.Select(i => i.Quantitiy).Sum(); } }
        public IList<WareHouse> WareHouses { get; private set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Invenctory()
        {

        }

        internal Invenctory(InvenctoryBuilder invenctoryBuilder)
        {
            this.WareHouses = invenctoryBuilder.GetWareHouses();
        }
                
    }

    
}
