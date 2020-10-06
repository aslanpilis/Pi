using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.Store.Api.DTOs
{
    public class ShoppingCartWithProductDto: ShoppingCartDto
    {
        public ProductDto Product { get; set; }
    }
}
