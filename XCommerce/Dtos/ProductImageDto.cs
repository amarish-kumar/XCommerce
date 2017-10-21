using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XCommerce.Dtos
{
    public class ProductImageDto
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }
    }
}