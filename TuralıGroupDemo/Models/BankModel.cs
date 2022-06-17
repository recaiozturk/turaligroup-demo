using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuralıGroupDemo.Models
{
    public class BankModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Extra { get; set; }
    }
}