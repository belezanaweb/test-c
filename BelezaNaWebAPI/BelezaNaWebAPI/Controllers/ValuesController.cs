using BelezaNaWebAPI.Models;
using BelezaNaWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BelezaNaWebAPI.Controllers
{
    //Inicio 20h35
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        [ResponseType(typeof(Response))]
        public IHttpActionResult Get()
        {
            var response = new Response();
            DbRepository _repo = new DbRepository();
            try
            {
               response = _repo.Get_Products();
             
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        // POST api/values
        [HttpPost]
        [ResponseType(typeof(Response))]
        public IHttpActionResult Post([FromBody]JsonModel value)
        {
            var response = new Response();
            DbRepository _repo = new DbRepository();
            try
            {
                string retorno = ValidaRequisicao(value);

                if (!string.IsNullOrEmpty(retorno))
                {
                    return BadRequest(retorno);
                }
                else
                {
                   response = _repo.Insert_Product(value);
                }
               
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(response);


        }

        // Patch api/values/value
        [HttpPatch]
        [ResponseType(typeof(Response))]
        public IHttpActionResult Patch([FromBody]JsonModel value)
        {
            var response = new Response();
            DbRepository _repo = new DbRepository();
            try
            {
                string retorno = ValidaRequisicao(value);

                if (!string.IsNullOrEmpty(retorno))
                {
                    return BadRequest(retorno);
                }
                else
                {
                    response = _repo.Update_Product(value);
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(response);


        }


        // DELETE api/values/VALUE
        [HttpDelete]
        [ResponseType(typeof(Response))]
        public IHttpActionResult Delete([FromBody]JsonModel value)
        {
            var response = new Response();
            DbRepository _repo = new DbRepository();
            try
            {
                string retorno = ValidaRequisicao(value);

                if (!string.IsNullOrEmpty(retorno))
                {
                    return BadRequest(retorno);
                }
                else
                {
                    response = _repo.Delete_Product(value);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }

        string ValidaRequisicao(JsonModel values)
        {
            try
            {
                values.name = values.name.Replace("´", "");
                values.name = values.name.Replace("'", "");

                if (string.IsNullOrEmpty(values.sku))
                {
                    return "Número do SKU necessário";
                }
                else if(values.inventory.warehouses==null 
                    || values.inventory.warehouses.Count()==0)
                {
                    return "Informar o warehouse do produto";
                }
                else if(string.IsNullOrEmpty(values.inventory.warehouses[0].locality))
                {
                    return "Informar a localidade do warehouse do produto";
                }
                else if (string.IsNullOrEmpty(values.inventory.warehouses[0].type))
                {
                    return "Informar o tipo da localidade do warehouse do produto";
                }
                return "";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
