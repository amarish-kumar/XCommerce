using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;


namespace XCommerce.Models
{
    public class ShoppingCartActions : IDisposable
    {
        private string ShoppingCartId { get; set; }
        private ApplicationDbContext _db = null;
        private const string CartSessionKey = "CartId";

        public ShoppingCartActions()
        {
            _db = new ApplicationDbContext();
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.User.Identity.GetUserId()))
                {
                    HttpContext.Current.Session.Add(CartSessionKey, HttpContext.Current.User.Identity.GetUserId());
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session.Add(CartSessionKey, tempCartId.ToString());
                }
            }

            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public void AddToCart(int productId)
        {
            ShoppingCartId = GetCartId();

            var cart = _db.ShoppingCarts
                .SingleOrDefault(c => c.CartID == ShoppingCartId && c.ProductId == productId);

            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    CartID = ShoppingCartId,
                    ProductId = productId,
                    Quantity = 1,
                    CreationDate = DateTime.Now
                };
                _db.ShoppingCarts.Add(cart);

            }
            else
            {
                cart.Quantity++;
            }
            _db.SaveChanges();

        }

        public void UpdateProduct(string cartId, int productId, int quantity)
        {
            try
            {
                var cart = _db.ShoppingCarts.SingleOrDefault(c => c.CartID == cartId && c.ProductId == productId);

                if (cart != null)
                {
                    cart.Quantity = quantity;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: Unable to Update Cart Item -" + ex.Message.ToString(), ex);
            }
        }

        public IEnumerable<ShoppingCart> GetCarts()
        {
            var carts = _db.ShoppingCarts.Include(i => i.Product).ToList();
            return carts;
        }

        public IEnumerable<ShoppingCart> GetCartsByUser(string cartId)
        {
            var carts = _db.ShoppingCarts.Include(i => i.Product).Where(c => c.CartID == cartId).ToList();
            return carts;
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }
    }
}