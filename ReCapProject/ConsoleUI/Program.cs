using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using System;
using Entities.Concrete;


namespace ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {

            //defined managers
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //LocalGetCars();

            //carManager.Add(new Car() { BrandId = 1001, ColorId = 1002, DailyPrice =-500, ModelYear = "2031", Descriptions = "Eklememeli Otomatik Dizel" });
            //brandManager.Add(new Brand(){BrandName="E"});
            //colorManager.Add(new Color() {ColorName="Yellow"});
            carManager.Delete(carManager.GetCarById(1021));
            carManager.Delete(carManager.GetCarById(1022));
            carManager.Delete(carManager.GetCarById(1023));
            carManager.Delete(carManager.GetCarById(1024));






            void LocalGetCars()
            {
                Console.WriteLine("\nCarId\tBrandId\tColorId\tModelYear\tDailyPrice\tDescriptions");
                foreach (var car in carManager.GetAll())
                {
                    Console.WriteLine($"{car.CarId}\t{car.BrandId}\t{car.ColorId}\t{car.ModelYear}\t\t{car.DailyPrice}\t\t{car.Descriptions}\t\b");

                }
                Console.WriteLine("***********************************************************************************");
            }
        }

    }
}
