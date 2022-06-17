using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuralıGroupDemo.Entity
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }

        //iskonto
        public decimal Discount { get; set; }

        public decimal KDV { get; set; }

        public string  ImageUrl { get; set; }

    }
}