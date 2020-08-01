using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParts.Domain.Services.Abstraction;

namespace CarParts.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
       
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet("getproduct")]
        public string getproduct()
        {
            return "123";
        }
    }
}