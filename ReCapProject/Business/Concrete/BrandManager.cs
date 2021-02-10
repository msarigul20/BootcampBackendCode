using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine($"The brand that is id of {brand.BrandId} has been added succesfully.");
            }
            else
            {
                Console.WriteLine($"Brand did not add the database because the brand name must have 2 characters or more. " +
                    $"You entered :{brand.BrandName}.");
            }
        }
        public void Update(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Update(brand);
                Console.WriteLine($"The brand that is id of {brand.BrandId} has been updated succesfully.");
            }
            else
            {
                Console.WriteLine($"Brand did not uptade the database because the brand name must have 2 characters or more. " +
                    $"You entered :{brand.BrandName}.");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine($"The brand that is id of {brand.BrandId} has been deleted succesfully.");
        }


        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetBrandById(int id)
        {
            return _brandDal.Get(b => b.BrandId == id);
        }
        
    }
}
