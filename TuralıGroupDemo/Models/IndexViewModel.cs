﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuralıGroupDemo.Entity;

namespace TuralıGroupDemo.Models
{
    public class IndexViewModel
    {
        
        public int  ShopCardProductCount { get; set; }

        public decimal ClientDebt { get; set; }

        public List<Bank> Banks { get; set; }
        public List<Case> Cases { get; set; }
    }
}