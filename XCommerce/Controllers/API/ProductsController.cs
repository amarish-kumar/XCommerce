using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XCommerce.Models;
using System.Data.Entity;
using XCommerce.Dtos;
using AutoMapper;

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
        public IHttpActionResult GetProducts(int? pageCount = null)
        {
            //var products = (from u in db.Products                          
            //              from p in u.ProductImages
            //              select p).Take(10);

            var productsQuery = db.Products
                .Include(p => p.Brand)
                .Include(p => p.ProductImages.Select(i => i.ImageType))
                .OrderBy(p => p.Name).AsQueryable();

            if (pageCount != null)
            {
                int pageSkip = 10 * ((int)pageCount - 1);
                productsQuery = productsQuery.Skip(pageSkip)
                    .Take(10);
            }

            //var productsDto = Mapper.Map<Product, ProductDto>(products);
            //var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            var products = productsQuery.ToList();
            return Ok(products);
        }

        [HttpGet]
        [Route("api/Products/ByBrand/{brandId}")]
        //public IHttpActionResult GetProducts(int? brandId, int? productId)
        public IHttpActionResult GetProducts(int brandId)
        {
            var products = db.Products
                .Include(p => p.Brand)
                .Include(p => p.ProductImages.Select(i => i.ImageType))
                .ToList();

            return Ok(products);
        }

        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = db.Products
                .Include(p => p.Brand)
                .Include(p => p.ProductImages.Select(i => i.ImageType))
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }

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
        public IHttpActionResult UpdateProduct(int id, Product productDto)
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
