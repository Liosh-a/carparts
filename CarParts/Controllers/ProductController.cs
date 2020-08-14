﻿using System;
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

        public ProductController(IProductService productService, EFDbContext context
            )
        {
            _productService = productService;
            _context = context;

        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost("getcategory")]
        public async Task<IActionResult> getCategory()
        {
            var category = _productService.GetCategory();

            return Ok(category);
        }
        [HttpPost("getmark")]
        public async Task<IActionResult> getMark(int year)
        {
            var category = _productService.GetMark(year);

            return Ok(category);
        }
        [HttpPost("getmodel")]
        public async Task<IActionResult> getModel(int model)
        {
            var category = _productService.GetModel(model);

            return Ok(category);
        }
    }
}