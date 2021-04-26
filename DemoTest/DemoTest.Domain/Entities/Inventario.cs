using System;

namespace DemoTest.Domain.Entities
{
    public class Inventario
    {
        public long Id { get; set; }        
        public long Sku { get; set; }
        public string Localidade { get; set; }
        public int Quantidade { get; set; }
        public string Tipo { get; set; }
    }
}
