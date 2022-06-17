using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuralıGroupDemo.Entity;

namespace TuralıGroupDemo.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        //iskonto
        public decimal Discount { get; set; }
        public decimal KDV { get; set; }
        public string ImageUrl { get; set; }
    }

}