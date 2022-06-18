using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuralıGroupDemo.Entity;

namespace TuralıGroupDemo.Models
{
    public class PaymentViewModel
    {
        public List<Bank> Banks { get; set; }
        public List<Case> Cases { get; set; }
    }
}