//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using AutoMapper;
using XCommerce.Dtos;
using XCommerce.Models;

namespace XCommerce.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductImage, ProductImageDto>();
        }
        
    }
}