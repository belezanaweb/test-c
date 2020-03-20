using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class PayLoadsController : ApiController
    {

        public IList<Models.RootObject> Products;

        PayLoadsController()
        {

            var owarehouses = new List<Models.Warehouse>();

            owarehouses.Add(new Models.Warehouse { locality="SP", quantity=12 , type= "ECOMMERCE" });
            owarehouses.Add(new Models.Warehouse { locality = "MOEMA", quantity = 3, type = "PHYSICAL_STORE" });

            Products = new List<Models.RootObject>();

            Products.Add(new Models.RootObject 
            { sku= 43264,
              name= "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g",
              inventory = new Models.Inventory
              {
                  warehouses = owarehouses
                 
              }
              
            });
        }


        // GET: /PayLoads
        //traz produto por sku
        public IHttpActionResult Get()
        {

            try
            {

                return Ok(Products);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        // GET: /PayLoads/5
        //traz produto por sku
        public IHttpActionResult Get(Int32 Id)
        {

            try
            {

                var oProduct = Products.Where(x => x.sku == Id).FirstOrDefault();

                if (oProduct == null)
                {
                    return BadRequest("Produto não existe");
                }else
                {

                    oProduct.inventory.quantity = oProduct.inventory.warehouses.Count();

                    if (oProduct.inventory.quantity > 0)
                    {
                        oProduct.isMarketable = true;
                    }

                    return Ok(oProduct);
                }

            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        // Post: PayLoads
        //Criação produto
        public IHttpActionResult Post([FromBody]Models.RootObject Data)
        {

            try
            {

                var oproduct = Products.Where(x => x.sku == Data.sku).FirstOrDefault();

                if (oproduct != null)
                {
                    return BadRequest("Produto já Existe");
                }
                else
                {
                    Products.Add(Data);


                    return Ok(Data);
                }


            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        // PUT: PayLoads
        //Atualiza produto
        public IHttpActionResult Put([FromBody]Models.RootObject Data)
        {

            try
            {

                var oproduct = Products.Where(x => x.sku == Data.sku).FirstOrDefault();

                if (oproduct == null)
                {
                    return BadRequest("Erro produto não encontrado");
                }else
                {
                    Products.Remove(oproduct);
                    Products.Add(Data);


                    return Ok(Data);
                }


            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        //// DELETE: aPayLoads/5
        /////Exclui Produto
        public IHttpActionResult Delete(int Id)
        {

            try
            {

                var oProduct = Products.Where(x => x.sku == Id).FirstOrDefault();

                if (oProduct == null)
                {
                    return BadRequest("Produto não existe");
                }
                else
                {

                    Products.Remove(oProduct);

                    return Ok<string>("Produto excluido com sucesso");
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        //// GET: api/PayLoads/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/PayLoads
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/PayLoads/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/PayLoads/5
        //public void Delete(int id)
        //{
        //}
    }
}
