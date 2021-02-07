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
            CarManager   carManager   = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            
            //Called local print all car method to easy test.
            //LocalGetCars();

            //Tried to new car that does not fit the business rules so that it will not added in database.
            carManager.Add(new Car() { BrandId = 1001, ColorId = 1002, DailyPrice =-500, ModelYear = "2031", 
                Descriptions = "Eklenmemeli Otomatik Dizel 150.000km 18 Yaşs ınırı" });
            
            //Tried to new brand that does not fit the business rules so that it will not added in database.
            brandManager.Add(new Brand(){BrandName="E"});

            //Added new color, brand and car that has properties these added newly. 
            colorManager.Add(new Color() { ColorName = "Yeşil" });
            brandManager.Add(new Brand() { BrandName = "Mercedes" });
            carManager.Add(new Car(){ BrandId = brandManager.GetAll()[brandManager.GetAll().Count-1].BrandId,
                ColorId = colorManager.GetAll()[colorManager.GetAll().Count-1].ColorId,
                DailyPrice = 400, ModelYear = "2020",
                Descriptions = "E250 Sedan 4 Kapı 18.000km Benzin Otomatik Vites 25 Yaş Sınırı"});

            LocalGetCars();


            #pragma warning disable CS8321
            void LocalGetCars()
            {
                Console.WriteLine("\nCarId\tBrandId\tColorId\tModelYear\tDailyPrice\tDescriptions");
                foreach (var car in carManager.GetAll())
                {
                    Console.WriteLine($"{car.CarId}" +
                        $"\t{brandManager.GetBrandById(car.BrandId).BrandName}" +
                        $"\t{colorManager.GetColorById(car.ColorId).ColorName}" +
                        $"\t{car.ModelYear}" +
                        $"\t\t{car.DailyPrice}" +
                        $"\t\t{car.Descriptions}" +
                        $"\t\b\b");
                }
                Console.WriteLine("***********************************************************************************");
            }
            #pragma warning disable CS8321 
            void LocalGetColors()
            {
                Console.WriteLine("\nColorId\tColorName");
                foreach (var color in colorManager.GetAll())
                {
                    Console.WriteLine($"{color.ColorId}" +
                                      $"\t{color.ColorName}\t\b\b");
                }
                Console.WriteLine("***********************************************************************************");
            }
            #pragma warning disable CS8321 
            void LocalGetBrands()
#pragma warning restore CS8321 // Local function is declared but never used
            {
                Console.WriteLine("\nBrandId\tBrandName");
                foreach (var brand in brandManager.GetAll())
                {
                    Console.WriteLine($"{brand.BrandId}" +
                                      $"\t{brand.BrandName}\t\b\b");
                }
                Console.WriteLine("***********************************************************************************");
            }
        }

    }
}
