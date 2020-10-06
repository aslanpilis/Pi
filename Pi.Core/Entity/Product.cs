using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pi.Core.Entity
{
    public class Product
    {
        public Product()
        {

            ShoppingCarts = new Collection<ShoppingCart>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public Decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string InnerBarcode { get; set; }

        public virtual Category Category { get; set; }


        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public bool IsDelete { get; set; }
    }
}
