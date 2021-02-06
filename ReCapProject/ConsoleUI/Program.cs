using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            try
            {
                foreach (var car in carManager.GetAllCars())
                {
                    Console.WriteLine("Car Id : " + car.Id);
                    Console.WriteLine("Car Brand Id : " + car.BrandId);
                    Console.WriteLine("Car Color Id : " + car.ColorId);
                    Console.WriteLine("Car Daily Price : " + car.DailyPrice + " TL");
                    Console.WriteLine("Car Model Year : " + car.ModelYear);
                    Console.WriteLine("Car Description : " + car.Description);
                    Console.WriteLine("----------------------------------------------------");
                }
            }
            catch (System.NullReferenceException)
            {

                Console.WriteLine("Your request returned as a null. Please check your rules or requests.");
            }
            carManager.GetCarWithId(1);
            
        }
    }
}
