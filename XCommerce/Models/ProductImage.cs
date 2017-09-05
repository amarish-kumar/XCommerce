using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace XCommerce.Models
{
    public class ProductImage
    {
        //public ProductImage()
        //{
        //    Products = new List<Product>();
        //}
        [Key]
        public int ImageId { get; set; }


        public int ProductId { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
        public virtual Product Product { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }
    }
}