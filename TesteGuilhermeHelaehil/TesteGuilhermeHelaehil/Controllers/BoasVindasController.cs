using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TesteGuilhermeHelaehil.Controllers
{
    //Esse Controller serve somente para mostrar uma mensagem legal ao executar a solução :D
    [Route("TesteGuilhermeHelaehil")]
    [ApiController]
    public class BoasVindasController
    {
        // GET: api/product
        // endpoint pras boas vindas
        [HttpGet]
        public string Get()
        {
            return "\t Bem vindos ao meu teste, espero que gostem do que  \n" +
                   "verão, dei o meu melhor porem  tenho mais a oferecer do que foi \n" +
                   "abordado nessa solução, infelizmente como ainda estou aprendendo \n" +
                   "a testar, não consegui terminar os teste de integração, porem \n" +
                   "estou empolgado para aprender mais sobre. \n\n" +
                   "\t Tomei a iniciatica de montar uma collection(v2.1) no postman \n" +
                   "para facilitar a utilização dessa API a Collection está localizada\n" +
                   "no arquivo: \\test-c\\Teste Guilherme Helaehil.postman_collection.json.\n\n" +
                   "\t Obrigado pela oportunidade e aguardo um retorno :D ";
        }
    }
}
