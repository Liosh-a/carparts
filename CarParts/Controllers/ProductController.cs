﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarParts.Domain.Services.Abstraction;
using CarParts.Dto.DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("getproductbyid")]
        public async Task<IActionResult> GetProductById(string unickName)
        {
            var res = _productService.GetProductById(unickName);
            return Ok(res);
        }

        [HttpPost("getFilterList")]
        public async Task<IActionResult> GetFilterList(int categoryId)
        {
            var res = _productService.GetListFilter(categoryId);
            return Ok(res);
        }

        [HttpPost("getProductbyCategoryId")]
        public async Task<IActionResult> GetProductbyCatId(int categoryId, int paginationinfo)
        {
            var res = _productService.GetProductbyCatId(categoryId, paginationinfo);
            return Ok(new { });
        }

        [HttpPost("getProductbyCategoryIdandCar")]
        public async Task<IActionResult> GetProductbyCatIdandCar(int categoryId, int paginationinfo, int carId)
        {
            var res = new ProductDto();
            return Ok(new { });
        }

        [HttpPost("getProductbyCategoryIdandCarandFilter")]
        public async Task<IActionResult> GetProductbyCatIdandCarandFilter(int categoryId, int paginationinfo, int carId)
        {
            var res = new ProductDto();
            return Ok(new { });
        }

    }
}