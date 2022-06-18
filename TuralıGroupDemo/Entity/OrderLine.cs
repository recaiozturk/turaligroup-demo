using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuralıGroupDemo.Entity
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }


        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

       

        //public decimal Discount { get; set; }

        public decimal DiscountAmount { get; set; }

        //public decimal KDV { get; set; }
        public decimal KDVAmount { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }  // her bir üründen kaçar tane var

        public decimal TotalPrice { get; set; }

    }
}