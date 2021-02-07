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
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=100, ModelYear="2018",Descriptions= "Fiat Egea Sedan 4 Kapı 120.000km Dizel Otomatik Vites 25 Yaş Sınırı"},
                new Car{CarId=2,BrandId=2,ColorId=2,DailyPrice=150, ModelYear="2019",Descriptions= "Renault Clio Hatchback 4 Kapı 80.000km Benzin Düz Vites 22 Yaş Sınırı"},
                new Car{CarId=3,BrandId=3,ColorId=1,DailyPrice=80, ModelYear="2016",Descriptions= "Hyundai i20 Hatchback 4 Kapı 290.000km LPG-Benzin Düz Vites 18 Yaş Sınırı"},
                new Car{CarId=4,BrandId=1,ColorId=3,DailyPrice=250, ModelYear="2020",Descriptions= "Fiat 124 Spider Cabrio 2 Kapı 30.000km Benzin Otomatik Vites 22 Yaş Sınırı"},
                new Car{CarId=5,BrandId=4,ColorId=4,DailyPrice=225, ModelYear="2019",Descriptions= "Nissan Qashqai SUV 4 Kapı 100.000km Dizel Düz Vites 20 Yaş Sınırı"},
                //To test business rules.
                //new Car{CarId=6,BrandId=1,ColorId=1,DailyPrice=100, ModelYear="2018",Descriptions= "Fiat Egea Sedan 4 Kapı 120.000km Dizel Otomatik Vites 25 Yaş Sınırı"},
                //new Car{CarId=7,BrandId=2,ColorId=2,DailyPrice=150, ModelYear="2019",Descriptions= "Renault Clio Hatchback 4 Kapı 80.000km Benzin Düz Vites 22 Yaş Sınırı"},
                //new Car{CarId=8,BrandId=3,ColorId=1,DailyPrice=80, ModelYear="2016",Descriptions= "Hyundai i20 Hatchback 4 Kapı 290.000km LPG-Benzin Düz Vites 18 Yaş Sınırı"},
                //new Car{CarId=9,BrandId=1,ColorId=3,DailyPrice=250, ModelYear="2020",Descriptions= "Fiat 124 Spider Cabrio 2 Kapı 30.000km Benzin Otomatik Vites 22 Yaş Sınırı"},
                //new Car{CarId=10,BrandId=4,ColorId=4,DailyPrice=225, ModelYear="2019",Descriptions= "Nissan Qashqai SUV 4 Kapı 100.000km Dizel Düz Vites 20 Yaş Sınırı"}

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
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);   
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.CarId == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
        }


    }
}
