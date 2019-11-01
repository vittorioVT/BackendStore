using BackendStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackendStore.Controllers
{
    [EnableCors("http://localhost:4200","*","*")]
    public class ProductsController : ApiController
    {
        public IHttpActionResult GetProducts()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var products = context.Products.ToList();
                    return Ok(products);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public IHttpActionResult PostProducts([FromBody]Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new AppDbContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();

                    return Ok("{Product was created");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }



}
