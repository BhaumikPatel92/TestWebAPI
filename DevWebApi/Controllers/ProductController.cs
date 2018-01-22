using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DevWebApi.MGIWebservice;
using DevWebApi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Http;
using System.Net;

namespace DevWebApi.Controllers
{
    public class ProductController : ApiController
    {
        List<Product> products = new List<Product>
        {
            new Product {Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
            new Product {Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M},
            new Product {Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M}
        };


        // GET: Product
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var jsonString = JsonConvert.SerializeObject(products);
            JArray jarray = JArray.Parse(jsonString);
            //foreach (JObject jObject in jarray)
            //{
            //    jarray.Remove(jObject);
            //}

            for (int i=jarray.Count -1 ; i >= 0; i--)
            {
                var product = (JObject)jarray[i];
                if (product["Category"].ToString() != "Groceries")
                {
                    jarray.RemoveAt(i);
                }
            }
            var str  = jarray.ToString();

       

            return products;
            

        }


        [HttpPost]
        public IHttpActionResult UpdateProduct()
        {
            return Ok("Update Product");
        }

        [HttpGet]
        public IHttpActionResult DeleteProduct(int productId)
        { 
            return Ok("Delete Product new" + productId);
        }

        [HttpGet]
        public IHttpActionResult CheckConcurrency()
        {
            Thread.Sleep(40000);
            return Ok("Concurrency check");
        }

        [HttpGet]
        public HttpResponseMessage ThrowError()
        {
            try
            {
                throw new Exception();
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex));
            }
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