using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                /*Console.WriteLine($"Brand did not add the database because the brand name must have 2 characters or more. " +
                $"You entered :{brand.BrandName}.");*/
                return new ErrorResult(Messages.BrandNameInvalid);
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
            //Console.WriteLine($"The brand that is id of {brand.BrandId} has been added succesfully.");

        }
        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
               /* Console.WriteLine($"Brand did not uptade the database because the brand name must have 2 characters or more. " +
                    $"You entered :{brand.BrandName}."); */
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
            //Console.WriteLine($"The brand that is id of {brand.BrandId} has been updated succesfully.");

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            //Console.WriteLine($"The brand that is id of {brand.BrandId} has been deleted succesfully.");
            return new SuccessResult(Messages.BrandDeleted);
        }


        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<Brand> GetBrandById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }
        
    }
}
