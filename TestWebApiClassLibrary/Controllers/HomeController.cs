using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace TestWebApiClassLibrary.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return Ok("Index");
        }
    }
}
