using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuralıGroupDemo.Entity
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Extra { get; set; }

    }
}