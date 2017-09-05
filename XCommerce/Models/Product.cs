using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XCommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage="Please enter name")]
        [Display(Name="Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage="Please enter description")]
        public string Description { get; set; }

        public double Price { get; set; }

        public Brand Brand { get; set; }
        [Display(Name = "Brand Type")]        
        public int BrandId { get; set; }
                

        //public string ImagePath { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}