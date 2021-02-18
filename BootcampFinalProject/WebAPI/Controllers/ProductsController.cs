using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //BİZE NASIL İSTEKTE BULUNUCAKLAR
    [ApiController] //Attribute  (C#)
                    //Annotation (Java)
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //Naming Concention ([_]productService)
        //IoC container (Inversion of Control) api kullanmak isteyen kişi productService ile çalışcanı 
            //biliyor ama productservice nin ne olduğunu bilmiyor o yüzden çalışmıyor
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger hazır dökümantasyon sağlayan yapı
            //Dependency chain (BAD THING)
            // IProductService needs ProductManager that needs EfProductDal:)
            //IProductService productService = new ProductManager(new EfProductDal());


            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }




        [HttpPost("add")]
        //Controllerin bildiği yer line 49 dur(IActionResult) MethodName(()
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
