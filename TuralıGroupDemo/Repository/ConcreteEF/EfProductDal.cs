using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuralıGroupDemo.Entity;
using TuralıGroupDemo.Repository.Abstract;

namespace TuralıGroupDemo.Repository.ConcreteEF
{
    public class EfProductDal:EfGenericRepository<Product, Context>,IProductDal
    {
    }
}