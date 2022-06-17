using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TuralıGroupDemo.Repository.Abstract;

namespace TuralıGroupDemo.Repository.ConcreteEF
{
    public class EfGenericRepository<T, TContext> : IRepository<T>
        //kısıtlamaları ekledik
        where T : class
        where TContext : DbContext, new()
    {
        public void Create(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                //context.Set<T>().Remove(entity);
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<T>().ToList()
                    : context.Set<T>().Where(filter).ToList();
            }
        }

        public T GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Where(filter).SingleOrDefault();
            }
        }

        public void Update(T entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}