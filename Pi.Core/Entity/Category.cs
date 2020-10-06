using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pi.Core.Entity
{
    public class Category
    {
        public Category()
        {

            Products =new  Collection<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}
