using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pi.Store.Api.DTOs
{
    public class ShoppingCartDto
    {
        [Range(1, 1000, ErrorMessage = "Please Enter Value between 1 and 1000")]
        public int Count { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public int AppuserId { get; set; }

    }

}
