using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuralıGroupDemo.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}