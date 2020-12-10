using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteGuilhermeHelaehil.Models;

namespace TesteGuilhermeHelaehil
{
    // Essa classe representa uma fonte de dados que seria consumida dentro do ProductService
    public class MyProducts
    {
        // Lista de produtos para serem consumidos
        public static List<Product> ProductsList = new List<Product> { };
    }
}
