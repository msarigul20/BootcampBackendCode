using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=100, ModelYear="2018",Description= "Fiat Egea Sedan 4 Kapı 120.000km Dizel Otomatik Vites 25 Yaş Sınırı"},
                new Car{CarId=2,BrandId=2,ColorId=2,DailyPrice=150, ModelYear="2019",Description= "Renault Clio Hatchback 4 Kapı 80.000km Benzin Düz Vites 22 Yaş Sınırı"},
                new Car{CarId=3,BrandId=3,ColorId=1,DailyPrice=80, ModelYear="2016",Description= "Hyundai i20 Hatchback 4 Kapı 290.000km LPG-Benzin Düz Vites 18 Yaş Sınırı"},
                new Car{CarId=4,BrandId=1,ColorId=3,DailyPrice=250, ModelYear="2020",Description= "Fiat 124 Spider Cabrio 2 Kapı 30.000km Benzin Otomatik Vites 22 Yaş Sınırı"},
               // new Car{CarId=4,BrandId=4,ColorId=4,DailyPrice=225, ModelYear="2019",Description= "Nissan Qashqai SUV 4 Kapı 100.000km Dizel Düz Vites 20 Yaş Sınırı"}

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
           
        }
        //Coded for businessrule.
        public int CountCars()
        {
            return _cars.Count();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);   
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(c => c.CarId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }


    }
}
