using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarParts.Dto.DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("getproductbyid")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var res=new ProductDto();
            return Ok(new{ });
        }

        [HttpPost("getFilterList")]
        public async Task<IActionResult> GetFilterList(int categoryId)
        {
            var res = new ProductDto();
            return Ok(new { });
        }

        [HttpPost("getProductbyCategoryId")]
        public async Task<IActionResult> GetProductbyCatId(int categoryId, int paginationinfo)
        {
            var res = new ProductDto();
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