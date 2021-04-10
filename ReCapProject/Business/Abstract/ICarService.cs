using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetCarsByModelYear(string modelYear);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int id);
        IDataResult<List<CarDetailDto>> GetCarsBySelect(int brandId,int colorId);

    }
}
