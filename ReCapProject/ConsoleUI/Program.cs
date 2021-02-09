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
            //CarsTest(carManager);
            //BrandTest(brandManager);
            //ColorTest(colorManager);







        }

        private static void ColorTest(ColorManager colorManager)
        {
            Console.WriteLine("\nColorId\tColorName\t");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.ColorId}" +
                    $"\t{color.ColorName}" +
                    $"\t\b\b");
            }
            Console.WriteLine("***********************************************************************************");
        }
        private static void BrandTest(BrandManager brandManager)
        {
            Console.WriteLine("\nBrandId\tBrandName\t");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.BrandId}" +
                    $"\t{brand.BrandName}" +
                    $"\t\b\b");
            }
            Console.WriteLine("***********************************************************************************");
        }
        private static void CarsTest(CarManager carManager)
        {
            Console.WriteLine("\nCarId\tBrandId\tColorId\tModelYear\tDailyPrice\tDescriptions");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.CarId}" +
                    $"\t{car.BrandId}" +
                    $"\t{car.ColorId}" +
                    $"\t{car.ModelYear}" +
                    $"\t\t{car.DailyPrice}" +
                    $"\t\t{car.Descriptions}" +
                    $"\t\b\b");
            }
            Console.WriteLine("***********************************************************************************");
        }
    }
}
