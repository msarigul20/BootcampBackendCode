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
        public List<Car> GetAllCars()
        {
            //It is my business rule.
            //The rule of the authorities is to show all cars, the total number of cars must be 5 or more.
            //Don't show any cars if request doesn't follow the rule.
            if (_carDal.CountCars() >= 5)
            {
                //For checking 
                Console.WriteLine("Total number of cars : " + _carDal.CountCars() + ". So that you passed the business rule.");
                return _carDal.GetAll();
            }
            else
            {
                //For checking the rule
                Console.WriteLine("Total number of cars : " + _carDal.CountCars() + ". So that you did not pass the business rule.");
                Console.WriteLine("The total car numbers should be 5 or more. Please add new car(s).");
                return null; 
            }
        }
    }
}
