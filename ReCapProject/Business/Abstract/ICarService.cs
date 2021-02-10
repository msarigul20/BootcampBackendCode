using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetCarById(int id);
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        List<Car> GetCarsByDailyPrice(decimal min, decimal max);
        List<Car> GetCarsByModelYear(string modelYear);
        List<CarDetailDto> GetCarDetails();
    }
}
