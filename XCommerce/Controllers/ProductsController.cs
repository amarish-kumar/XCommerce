using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCommerce.Models;
using System.Data.Entity;

namespace XCommerce.Controllers
{
    [AllowAnonymous]
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
            //var products = db.Products
            //    .Include(p => p.Brand)
            //    .ToList();

            var products = db.Products
                    .Where(u => u.Id == 1)
                    .SelectMany(u => u.ProductImages)
                    .OrderBy(p => p.ImageId)
                    .Take(10);

            return View(products);
        }

        // GET: Products
        [Route("Products/Detail/{id}")]
        public ActionResult Detail(int id)
        {
            var product = db.Products
                .Include(p => p.Brand)
                .Include(p => p.ProductImages.Select(t => t.ImageType))
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

        [Authorize(Roles = RoleName.CanManageProducts)]
        public ActionResult Manage()
        {
            var products = db.Products
                .Include(b => b.Brand)
                .Include(i => i.ProductImages.Select(t => t.ImageType))
                .ToList();
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