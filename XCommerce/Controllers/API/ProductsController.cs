using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XCommerce.Models;
using System.Data.Entity;


namespace XCommerce.Controllers.API
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext db = null;

        public ProductsController()
        {
            db = new ApplicationDbContext();
        }

        [HttpGet]
        //[Route("api/Products/{brandId}/{productId}")]
        //public IHttpActionResult GetProducts(int? brandId, int? productId)
        public IHttpActionResult GetProducts()
        {
            var products = db.Products
                .Include(p => p.Brand)
                .Where(p => p.ProductImages.Any(pi => pi.ProductId == p.Id))
                //.Include(i => i.ProductImages)
                .ToList();

            //var products = from p in db.Products
            //               join im in db.ProductImages on p.Id equals im.ProductId
            //               select new { p.Name };

            //var products = from p in db.Products
            //               from im in p.ProductImages
            //               select new { p.Name };

            return Ok(products);
        }

        [HttpGet]
        [Route("api/Products/{brandId}")]
        //public IHttpActionResult GetProducts(int? brandId, int? productId)
        public IHttpActionResult GetProducts(int brandId)
        {
            //var products = db.Products
            //    .Include(p => p.Brand)
            //    .Where(p => p.BrandId == brandId)
            //    .Include(i => i.ProductImages)
            //    .ToList();

            var products = from d in db.Products
                           join b in db.Brands on d.BrandId equals b.Id
                           join im in db.ProductImages on d.Id equals im.ProductId
                           select new { d.Name, im.ImageId, im.ImagePath };

            return Ok(products);
        }

        //[HttpGet]
        //public IHttpActionResult GetProduct(int id)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var product = db.Products.FirstOrDefault(p => p.Id == id);

        //    if (product == null)
        //        return NotFound();
        //    else
        //        return Ok(product);

        //}

        [HttpPost]
        public IHttpActionResult CreateProduct(Product productDto)
        {
            if (!ModelState.IsValid)
                return
                    BadRequest();

            var product = db.Products.Add(productDto);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + product.Id), product);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, Product productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = db.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                //map
                return Ok();            
            }


        
        }
    }
}
