using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                Console.WriteLine("Car added succesfully.");
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine($"Car did not add the database because the daily price must be positive integer. You entered :{car.DailyPrice}.");
            }
        }

        public void Delete(Car car)
        {
            Console.WriteLine($"The car that is id of {car.CarId} has been deleted succesfully.");
            _carDal.Delete(car);
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

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                Console.WriteLine("Car updated succesfully.");
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine($"Car did not update the database because the daily price must be positive integer. You entered :{car.DailyPrice}.");
            }
        }
        /*



public List<Car> GetAll()
{
  return _carDal.GetAll();
}

public List<Car> GetCarsByBrandId(int id)
{
   return _carDal.GetAll(c => c.BrandId == id);
}

public List<Car> GetCarsByColorId(int id)
{
   return _carDal.GetAll(c => c.ColorId == id);
}
*/
    }
}
