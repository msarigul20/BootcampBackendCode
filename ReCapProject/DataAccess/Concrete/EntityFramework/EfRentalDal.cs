using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from rental in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars on rental.CarId equals car.CarId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join customer in context.Customers on rental.CustomerId equals customer.Id
                             join user in context.Users on customer.UserId equals user.Id
                             select new RentalDetailDto()
                             {
                                 Id = rental.Id,
                                 CarId = rental.CarId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 CompanyName = customer.CompanyName,
                                 UserFullName = user.FirstName + " " + user.LastName,
                                 UserEmail = user.Email,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
