using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of C# to gain memory speed by triggering garbage collector after terminating snippet.
            using (NorthwindContext context = new NorthwindContext())
            {
                //Catch the reference
                var addedEntity = context.Entry(entity);
                //Its object that will add.
                addedEntity.State = EntityState.Added;
                //Save all changes.(Really added.)
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Catch the reference
                var deletedEntity = context.Entry(entity);
                //Its object that will delete.
                deletedEntity.State = EntityState.Deleted;
                //Save all changes.(Really deleted.)
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //Catch the reference
                var updatedEntity = context.Entry(entity);
                //Its object that will add.
                updatedEntity.State = EntityState.Modified;
                //Save all changes.(Really updated.)
                context.SaveChanges();
            }
        }
    }
}
