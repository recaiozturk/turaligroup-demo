﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TuralıGroupDemo.Repository.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);
        T GetOne(Expression<Func<T, bool>> filter); //parametre olarak linq sorgusu alır
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //Iqueryble --> tekrar sorgulanabilir

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
