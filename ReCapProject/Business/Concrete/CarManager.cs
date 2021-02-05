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

        public void GetCarWithId(int carId)
        {
            //It is my other business rule.
            //The rule of the authorities is to search by id if the total number of cars not more than 10.
            //Don't force the system if there are cars more than 10 and send error message for uprading.
            try
            {
                if (_carDal.CountCars() < 10)
                {

                    Console.WriteLine("**** -- SEARCHED BY ID ==> " + _carDal.GetById(carId).CarId + "  -- *******");
                    //Used the object to trigger the exception codes before write anything on console.
                    Console.WriteLine("The car information is below about your Car : ");
                    Console.WriteLine("Car Id : " + _carDal.GetById(carId).CarId);
                    Console.WriteLine("Car Brand Id : " + _carDal.GetById(carId).BrandId);
                    Console.WriteLine("Car Color Id : " + _carDal.GetById(carId).ColorId);
                    Console.WriteLine("Car Daily Price : " + _carDal.GetById(carId).DailyPrice + " TL");
                    Console.WriteLine("Car Model Year : " + _carDal.GetById(carId).ModelYear);
                    Console.WriteLine("Car Description : " + _carDal.GetById(carId).Description);
                    Console.WriteLine("****************************************************");
                }
                else
                {
                    Console.WriteLine("Your account is using lower pack and you have 10 cars " +
                        "so that you need to upgrade your pack to filter as id of car.");

                }
            }
            catch (NullReferenceException)
            {

                Console.WriteLine("Id that entered in ConsoleUI did not find in cars.");
            }
        }
    }
}
