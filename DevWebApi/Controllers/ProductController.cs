using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DevWebApi.MGIWebservice;
using DevWebApi.Models;


namespace DevWebApi.Controllers
{
    public class ProductController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product {Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
            new Product {Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M},
            new Product {Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M}
        };


        // GET: Product
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }


        [HttpPost]
        public IHttpActionResult UpdateProduct()
        {
            return Ok("Update Product");
        }

        [HttpGet]
        public IHttpActionResult DeleteProduct()
        {
            return Ok("Delete Product");
        }

        //public IHttpActionResult GetProduct(int id)
        //{
        //    var product = products.FirstOrDefault((p) => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}
    }
}