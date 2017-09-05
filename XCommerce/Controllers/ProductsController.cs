using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCommerce.Models;
using System.Data.Entity;

namespace XCommerce.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = null;

        public ProductsController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products
                .Include(p => p.Brand)
                .ToList();
            return View(products);
        }

        // GET: Products
        [Route("Products/Detail/{id}")]
        public ActionResult Detail(int id)
        {
            var product = db.Products
                .Include(p => p.Brand)
                .Single(p => p.Id == id);
            return View(product);
        }

        // GET: Products
        [Route("Products/Search/{id}")]
        public ActionResult Search(int id, string query)
        {
            var products = db.Products
                .Include(p => p.Brand);

            if (query != "")
            { 
                //products = products.Where(p => p.BrandId == );            
            }

            return View(products);
        }

        // GET: Products
        //[Route("Products/List/{brandId}")]
        public ActionResult List()
        {
            //int? brandId = null
            return View();
        }
    }
}