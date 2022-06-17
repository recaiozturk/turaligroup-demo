using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuralıGroupDemo.Entity
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public decimal TotalPrice { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}