using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {

        public void Add(Car entity)
        {
            //IDisposable pattern implementation of C# to gain memory speed by triggering garbage collector after terminating snippet.
            using (CarDbContext context = new CarDbContext())
            {
                //Catch the reference
                var addedEntity = context.Entry(entity);
                //Its object that will add.
                addedEntity.State = EntityState.Added;
                //Save all changes.(Really added.)
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entitiy)
        {
            //IDisposable pattern implementation of C# to gain memory speed by triggering garbage collector after terminating snippet.
            using (CarDbContext context = new CarDbContext())
            {
                var updatedEntity = context.Entry(entitiy);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
