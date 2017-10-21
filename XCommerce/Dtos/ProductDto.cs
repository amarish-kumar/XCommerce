using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using XCommerce.Models;

namespace XCommerce.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }

        public double Price { get; set; }

        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        public List<ProductImage> ProductImageDtos { get; set; }
        //public string ImagePath { get; set; }
    }
}