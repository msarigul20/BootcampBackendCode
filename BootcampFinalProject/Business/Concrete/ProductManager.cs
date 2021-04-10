using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    //23.55 - 23.23  - 00.10

    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        /* HATALI KOOOOOOOODDDDDDD
         *          productManager                  categoryDal
         * Bir Özel entityManager kendisinden başka dal enjekte edemez. 
        IProductDal _categoryDal;

        public ProductManager(IProductDal productDal , ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
        }

        */
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        //Note cross cutting concerns (01:44:12-12.Day)
        //Log - Cache - Transcation - Authorization - Performance 
        //business codes c= validation
        /*
         İş kurallarını aşağıdaki gibi yazarsan ilerde illaki spagetti ye döner ve bir daha lazım olunca dry prensibi kırmış oluruz.

        //iş kuralı parçası
         var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError)
            }

            yukarıdaki kodu add blogunun içine yazmak yerine private method halinde bu classın içinde ayrı iş kural parçacığı şeklinde yazıp 
            her yerde (sınıf içi) kullanabilirim.
         */
        /*
             * if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                if (CheckIfProductNameExists(product.ProductName).Success)
                {
                    _productDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
                }
            }
            */
        //Claim
        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());
            
            //eğer mevcut category sayısı 15 i geçtiyse yeni ürün eklenemez
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
            
        }

        [CacheAspect] //key,value
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }
        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            /*if (DateTime.Now.Hour == 01)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintainceTime);
            }*/
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetail());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //Select Count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count >15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }


    }
}
