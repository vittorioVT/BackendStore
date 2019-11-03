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

        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, [FromBody]Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != product.Id)return BadRequest();

            try
            {
                using (var context = new AppDbContext())
                {
                    var oldProduct = context.Products.FirstOrDefault(n => n.Id == id);
                    if (oldProduct == null) return NotFound();

                    oldProduct.Id = product.Id;
                    oldProduct.Name = product.Name;
                    oldProduct.Description = product.Description;
                    oldProduct.IsStore = product.IsStore;
                    oldProduct.IsStock = product.IsStock;
                    oldProduct.Count = product.Count;
                    oldProduct.CountStore = product.CountStore;
                    oldProduct.CountStock = product.CountStock;
                    oldProduct.Color = product.Color;
                    oldProduct.Size = product.Size;
                    oldProduct.Ordered = product.Ordered;
                    oldProduct.Comment = product.Comment;

                    context.SaveChanges();

                    return Ok("Entry updated!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var product = context.Products.FirstOrDefault(n => n.Id == id);
                    if (product == null) return NotFound();

                    context.Products.Remove(product);
                    context.SaveChanges();

                    return Ok("Product deleted!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }



}
