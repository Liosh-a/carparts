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
    public class MainPageController : ControllerBase
    {
        private readonly IMainPageService _productService;

        public MainPageController(IMainPageService productService)
        {
            _productService = productService;
        }

        [HttpGet("getcategory")]
        public async Task<IActionResult> getCategory()
        {
            var category = await _productService.GetCategory();

            return Ok(category);
        }

        [HttpPost("getchildcategory")]
        public async Task<IActionResult> getChildCategory(int catid)
        {
            var category = await _productService.GetChildCategory(catid);

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

        [HttpPost("getchildcategorybycar")]
        public async Task<IActionResult> getchildCategoryByCar(int catid, int carid)
        {
            var category = await _productService.GetChildCategoryByCar(catid, carid);
            return Ok(category);
        }
    }
}
