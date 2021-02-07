using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            //IDisposable pattern implementation of C# to gain memory speed by triggering garbage collector after terminating snippet.
            using (CarDbContext context = new CarDbContext())
            {
                //Catch the reference
                var addedEntity = context.Entry(entity);
                //Its object that will add.
                addedEntity.State = EntityState.Added;
                //Save all changes.(Added really)
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
             using (CarDbContext context = new CarDbContext())
             {
                 return context.Set<Color>().SingleOrDefault(filter);
             }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }
        public void Update(Color entity)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
