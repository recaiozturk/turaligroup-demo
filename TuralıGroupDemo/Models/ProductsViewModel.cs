using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuralıGroupDemo.Entity;

namespace TuralıGroupDemo.Models
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }
        public int ShopCardProductCount { get; set; }
    }
}