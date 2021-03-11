using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    // We created controllers and their attribute to control and handle coming request. 

    // Attribute  (C#)
    // Annotation (Java)
    [Route("api/[controller]")] // How the client will request data. 
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //Naming Concention ([_]productService) to specify global variable.
        //IoC container (Inversion of Control) 
        // A client that wants to use our api know that will work with ProductService but 
        // does not know what is the ProductService so that the program did not wok in first time then 
        // we configured the startuo file in WebApi layer with IoC structure.
        // ex. 
        // services.AddSingleton<IProductService, ProductManager>();
        // services.AddSingleton<IProductDal, EfProductDal>();
        // * If ProductManager has parameter for another class (ex. EfProductDal),
        // * you need to add also "services.AddSingleton<IProductDal, EfProductDal>();" because of dependency.
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger (Ready-made Documentation Structure)
            //Dependency chain (BAD THING
            // IProductService needs ProductManager that needs EfProductDal:)
            // IProductService productService = new ProductManager(new EfProductDal());
            // --Loosely Coupling--
            // We re-factored with global variable initalization then access from construtor.

            //To check spinner.
            Thread.Sleep(3000);

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
        // Controller knows places that are methods as ;
            // IActionResult GetById(int id), IActionResult Add(Product product),  IActionResult GetAll().
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
