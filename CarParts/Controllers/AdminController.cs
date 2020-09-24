using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarParts.DataAccess.Entities;
using CarParts.Domain.Services.Abstraction;
using CarParts.Dto.DtoModels;
using CarParts.Dto.DtoResult;
using CarParts.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CarParts.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("add/user")]
        public async Task<IActionResult> addUser([FromBody]CreateUserDto user)
        {
            if (!ModelState.IsValid)
            {
                var errors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errors);
            }
            var result = await _adminService.addUser(user);
            if (result.IsSuccessful == false)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("remove/user")]
        public async Task<IActionResult> deleteUser(int id)
        {

            var result = await _adminService.deleteUser(id);
            if (result.IsSuccessful == false)
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpGet("user/list/{page}")]
        public async Task<IActionResult> listuser(int page)
        {
            page = page < 1 ? 1 : page;
            var result = await _adminService.listUsers(page);
            if (result.IsSuccessful == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("add/category")]
        public async Task<IActionResult> addCategory([FromBody]CreateCategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                var errors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errors);
            }
            var result = await _adminService.addCategory(category);
            if (result.IsSuccessful == false)
            {
                return BadRequest();
            }
            return Ok();

        }
        [HttpPost("remove/category")]
        public async Task<IActionResult> removeCategory(int id)
        {
            
            var result = await _adminService.removeCategory(id);
            if (result.IsSuccessful == false)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost("add/filter")]
        public async Task<IActionResult> addFilter(string filterName,string[] filterValue)
        {
            var result = await _adminService.addFilterGroup(filterName,filterValue);
            if (result.IsSuccessful == false)
            {
                return BadRequest();
            }
            return Ok();

        }
        [HttpPost("edit/filter/value")]
        public async Task<IActionResult> editFilterValue(int id, string value)
        {
            var result = await _adminService.editFilterValue(id, value);
            if (result.IsSuccessful == false)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost("edit/filter/name")]
        public async Task<IActionResult> editFilterName(int id, string value)
        {
            var result = await _adminService.editFilterName(id, value);
            if (result.IsSuccessful == false)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost("remove/filter/value")]
        public async Task<IActionResult> removeFilterValue(int id)
        {
            var result = await _adminService.removeFilterValue(id);
            if (result.IsSuccessful == false)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost("remove/filter/name")]
        public async Task<IActionResult> removeFilterName(int id)
        {
            var result = await _adminService.removeFilterName(id);
            if (result.IsSuccessful == false)
            {
                return BadRequest();
            }
            return Ok();

        }

        //[HttpPost("test/seeder")]
        //public string productSeeder()
        //{
        //    _adminService.productSeeder();
        //    return "1";
        //}
    }
}
 