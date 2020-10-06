using AutoMapper;
using Pi.Core.Entity;
using Pi.Core.Models;
using Pi.Store.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.Store.Api.Mapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithProductDto>();
            CreateMap<CategoryWithProductDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();  
            
            CreateMap<ShoppingCartWithProductDto, ShoppingCart>();
            CreateMap<ShoppingCart, ShoppingCartWithProductDto>(); 
            
            CreateMap<ShoppingCartWithProductDto, ShoppingCart>();
            CreateMap<ShoppingCart, ShoppingCartWithProductDto>(); 
            
            CreateMap<ShoppingCartDto, ShoppingCart>();
            CreateMap<ShoppingCart, ShoppingCartDto>();


            

        }


     }
}
