using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XCommerce.Models
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }

        public string CartID { get; set; }

        public Product Product { get; set; }

        //[Required]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }
    }
}