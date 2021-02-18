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


        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetCarsByModelYear(string modelYear)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear.Contains(modelYear)));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
             _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
