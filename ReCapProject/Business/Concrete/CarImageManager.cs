using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

       [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIsCarImageLimitExceded(carImage.CarId));
            if (result!=null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.DeleteAsync(carImage.ImagePath);
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.UpdateAsync(_carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath,file);
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIsCarImageNull(carId));
        }

        private List<CarImage> CheckIsCarImageNull(int carId)
        {
            string path = @"\Images\defaultPicture.png";
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Any();

            if (!result)
            {
                return new List<CarImage> { 
                    new CarImage() { 
                        CarId = carId, ImagePath = path, Date = DateTime.Now 
                    } 
                };
            }

            return _carImageDal.GetAll(ci => ci.CarId == carId);
        }

        private IResult CheckIsCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
