using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using XCommerce.Models;

namespace XCommerce.Controllers.API
{
    public class CartsController : ApiController
    {
        private ApplicationDbContext db = null;

        public CartsController()
        {
            db = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetCarts()
        {
            //var carts = db.cart
            return Ok();
        }
    }
}
