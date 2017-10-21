using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace XCommerce.Models
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }

        //public Brand Brand { get; set; }
        //[Display(Name = "Brand Type")]
        //public int BrandId { get; set; }

        
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
        

        [StringLength(100)]
        public string ImagePath { get; set; }

        public ImageType ImageType { get; set; }

        public int ImageTypeId { get; set; }
    }
}