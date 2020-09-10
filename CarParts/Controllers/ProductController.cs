using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParts.Domain.Services.Abstraction;
using CarParts.DataAccess;
using CarParts.DataAccess.Entities.Seeder;

namespace CarParts.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly EFDbContext _context;

        public ProductController(IProductService productService, EFDbContext context)
        {
            _productService = productService;
            _context = context;

        }

        [HttpGet("getcategory")]
        public async Task<IActionResult> getCategory()
        {
            var category = await _productService.GetCategory();

            return Ok(category);
        }

        [HttpGet("getyears")]
        public async Task<IActionResult> getYears()
        {
            var years = await _productService.GetYear();
            return Ok(years);
        }

        [HttpPost("getmark")]
        public async Task<IActionResult> getMark(int year)
        {
            var mark = await _productService.GetMark(year);

            return Ok(mark);
        }

        [HttpPost("getmodel")]
        public async Task<IActionResult> getModel(List<int> markid)
        {
            var model = await _productService.GetModel(markid);

            return Ok(model);
        }

        [HttpPost("getcategorybycar")]
        public async Task<IActionResult> getCategoryByCar(int carid)
        {
            var category = await _productService.GetCategoryByCar(carid);
            return Ok(category);
        }
    }
}
