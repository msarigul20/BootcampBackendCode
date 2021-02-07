using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand brand)
        {
            //IDisposable pattern implementation of C# to gain memory speed by triggering garbage collector after terminating snippet.
            using (CarDbContext context =  new CarDbContext())
            {
                //catch the reference
                var addedEntity = context.Entry(brand);
                //ıts the object will add
                addedEntity.State = EntityState.Added;
                //Save all changes.(Added really)
                context.SaveChanges();

            }
        }

        public void Delete(Brand brand)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var deletedEntity = context.Entry(brand);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand brand)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var updatedEntity = context.Entry(brand);
                updatedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
