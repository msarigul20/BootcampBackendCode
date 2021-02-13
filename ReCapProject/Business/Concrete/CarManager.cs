using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice < 0 )
            {
                /*Console.WriteLine($"Car did not add the database because the daily price must be positive integer. " +
                    $"You entered :{car.DailyPrice}.");*/

                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }
            
            _carDal.Add(car);

            //Console.WriteLine($"The car that is id of {car.CarId} has been added succesfully.");
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            
            _carDal.Delete(car);
            //Console.WriteLine($"The car that is id of {car.CarId} has been deleted succesfully.");
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);
                //Console.WriteLine($"The car that is id of {car.CarId} has been updated succesfully.");
            }

            /*Console.WriteLine($"Car did not update the database because the daily price must be positive integer. " +
                $"You entered :{car.DailyPrice}.");*/

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }


        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetCarById(int id)
        {
            return _carDal.Get(c => c.CarId == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<Car> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<Car> GetCarsByModelYear(string modelYear)
        {
            return _carDal.GetAll(c => c.ModelYear.Contains(modelYear));
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetProductDetails();
        }
    }
}
