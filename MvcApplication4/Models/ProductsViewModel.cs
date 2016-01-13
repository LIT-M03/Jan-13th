using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace MvcApplication4.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Category Category { get; set; }
    }
}