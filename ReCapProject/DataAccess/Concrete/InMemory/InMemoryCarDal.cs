using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccess.Concrete.InMemory
{

    /*
     * Ignored the intheritance because of I won't use anymore InMemory way to access data.
     * I'll use EntityFramework way so that if it  implements ICarDal, this class will be error 
     *  for adding each new method into ICarDal or changing each method. 
     * Remove below comment in sign of class it you want to use InMemory way to access data.
     */
    public class InMemoryCarDal //: ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=100, ModelYear="2018",Description= "Fiat Egea Sedan 4 Kapı 120.000km Dizel Otomatik Vites 25 Yaş Sınırı"},
                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=150, ModelYear="2019",Description= "Renault Clio Hatchback 4 Kapı 80.000km Benzin Düz Vites 22 Yaş Sınırı"},
                new Car{Id=3,BrandId=3,ColorId=1,DailyPrice=80, ModelYear="2016",Description= "Hyundai i20 Hatchback 4 Kapı 290.000km LPG-Benzin Düz Vites 18 Yaş Sınırı"},
                new Car{Id=4,BrandId=1,ColorId=3,DailyPrice=250, ModelYear="2020",Description= "Fiat 124 Spider Cabrio 2 Kapı 30.000km Benzin Otomatik Vites 22 Yaş Sınırı"},
                new Car{Id=5,BrandId=4,ColorId=4,DailyPrice=225, ModelYear="2019",Description= "Nissan Qashqai SUV 4 Kapı 100.000km Dizel Düz Vites 20 Yaş Sınırı"},
                //To test business rules.
                //new Car{Id=6,BrandId=1,ColorId=1,DailyPrice=100, ModelYear="2018",Description= "Fiat Egea Sedan 4 Kapı 120.000km Dizel Otomatik Vites 25 Yaş Sınırı"},
                //new Car{Id=7,BrandId=2,ColorId=2,DailyPrice=150, ModelYear="2019",Description= "Renault Clio Hatchback 4 Kapı 80.000km Benzin Düz Vites 22 Yaş Sınırı"},
                //new Car{Id=8,BrandId=3,ColorId=1,DailyPrice=80, ModelYear="2016",Description= "Hyundai i20 Hatchback 4 Kapı 290.000km LPG-Benzin Düz Vites 18 Yaş Sınırı"},
                //new Car{Id=9,BrandId=1,ColorId=3,DailyPrice=250, ModelYear="2020",Description= "Fiat 124 Spider Cabrio 2 Kapı 30.000km Benzin Otomatik Vites 22 Yaş Sınırı"},
                //new Car{Id=10,BrandId=4,ColorId=4,DailyPrice=225, ModelYear="2019",Description= "Nissan Qashqai SUV 4 Kapı 100.000km Dizel Düz Vites 20 Yaş Sınırı"}

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        //Coded for business rule.
        public int CountCars()
        {
            return _cars.Count();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);   
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }


    }
}
