using System;
using System.Collections.Generic;
using System.Text;

namespace Pi.Core.Entity
{
  public  class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }


        public int Id { get; set; }

        public int AppuserId { get; set; }


        public virtual Appuser Appuser { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Count { get; set; }



    }
}
