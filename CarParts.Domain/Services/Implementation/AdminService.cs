using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using CarParts.DataAccess;
using CarParts.Domain.Services.Abstraction;
using CarParts.DataAccess.Entities;
using CarParts.Dto.DtoResult;
using CarParts.Dto.DtoModels;
using System.Web.Http.ModelBinding;
using CarParts.Helpers;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using System.Net.Mail;
using System.Diagnostics;

namespace CarParts.Domain.Services.Implementation
{
    public class AdminService : IAdminService
    {


        private readonly EFDbContext _context;
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public AdminService(EFDbContext context,
            UserManager<DbUser> userManager,
            SignInManager<DbUser> signInManager,
            IConfiguration configuration,
            IHostingEnvironment env)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _configuration = configuration;
            _env = env;
        }


        public async Task<ResultDto> addUser(CreateUser user)
        {
            var newUser = new DbUser
            {
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = true,
                Name = user.Name,
                Surname = user.Surname
                
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    collectionResult = null,
                };
            }

            //IEmailSender emailServer = new EmailSender(this._configuration);
            //await emailServer.SendEmailAsync(model.Email, "Confirm Email",
            //   $"Please confirm your email by clicking here: " +
            //   $"<a href='{callbackUrl}'>link</a>");

            return new ResultDto
            {
                IsSuccessful = true,
                collectionResult = null,
            };
        }


        public async Task<ResultDto> deleteUser(int id)
        {
            //var user = _context.Users.Find();
            return new ResultDto
            {
                IsSuccessful = false,
                collectionResult = null,
            };
        }
    }
}
