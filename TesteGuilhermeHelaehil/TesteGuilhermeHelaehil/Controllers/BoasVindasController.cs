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
        // endpoint para as boas vindas
        [HttpGet]
        public string Get()
        {
            return "\t Bem vindos ao meu teste, espero que gostem do que \n" +
                   "irão ver, dei o meu melhor, porém tenho mais a oferecer do que foi \n" +
                   "abordado nessa solução. Infelizmente como ainda estou aprendendo \n" +
                   "testes automatizados, não consegui terminar os teste de integração,\n" +
                   "entretanto estou empolgado para aprender mais sobre. \n\n" +
                   "\t Tomei a iniciativa de montar uma collection(v2.1) no Postman \n" +
                   "para facilitar a utilização dessa API a Collection está localizada\n" +
                   "no arquivo: \\test-c\\Teste Guilherme Helaehil.postman_collection.json.\n\n" +
                   "\t Obrigado pela oportunidade e aguardo um retorno :D ";

        }
    }
}
