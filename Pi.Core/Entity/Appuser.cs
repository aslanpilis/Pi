using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pi.Core.Entity
{
    public class Appuser
    {
        public Appuser()
        {

            ShoppingCarts = new Collection<ShoppingCart>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public bool IsDelete { get; set; }



    }
}
