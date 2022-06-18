using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuralıGroupDemo.Entity;

namespace TuralıGroupDemo.Models
{
    public class ShopCardViewModel
    {
        public List<OrderLine> Orderlines { get; set; }

        public decimal generalDiscountAmount { get; set; }
        public decimal generalKDVAmount { get; set; }

        
        public decimal generalTotalPriceAmount { get; set; }
    }
}