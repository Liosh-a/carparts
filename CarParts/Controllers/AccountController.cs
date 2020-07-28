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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto model)
        {
                var result = await _accountService.Login(model);
            if (result.IsSuccessful == false)
            {
                return BadRequest(new { invalid = "Не правильно введені дані!" });
            }
            return Ok(
            new
            {
                token = result.collectionResult.FirstOrDefault(t => t.Key == "token")
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto model)
        {
            var res = new ResultDto();
            if (!ModelState.IsValid)
            {
                var errors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errors);
            }
            var result = await _accountService.Register(model);
            if (result.IsSuccessful == false) 
            { 
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("confirmemail/{userid}")]
        //[AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userid, [FromBody]ConfirmEmailDto model)
        {
            if (!ModelState.IsValid)
            {
                var errrors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errrors);
            }
            var result = await _accountService.ConfirmEmail(userid, model);
            if (result.IsSuccessful == false)
            {
                if (result.collectionResult.ContainsKey("user"))
                {
                    return BadRequest(new { invalid = "User is not found" });
                }
                return BadRequest(result.collectionResult);
            }
            return Ok();
        }
    }
}
