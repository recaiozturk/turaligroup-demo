using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuralıGroupDemo.Entity
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password  { get; set; }
        public string Surname { get; set; }

        public decimal Debt { get; set; } //borç
        public string Phone { get; set; }
        public string  City { get; set; }
    }
}