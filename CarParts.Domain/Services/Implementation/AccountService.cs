﻿using System;
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
    public class AccountService : IAccountService
    {
        private readonly EFDbContext _context;
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public AccountService(EFDbContext context,
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

        public async Task<ResultDto> ConfirmEmail(string userid, ConfirmEmailDto model)
        {
            var dictionaryResult = new Dictionary<string, string>();
            var user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                dictionaryResult.Add("user", "User is not found");
                return new ResultDto
                {
                    IsSuccessful = false,
                    collectionResult = dictionaryResult,
                };
            }
            var result = await _userManager.ConfirmEmailAsync(user, model.Code);
            if (!result.Succeeded)
            {
                var errrors = CustomValidator.GetErrorsByIdentityResult(result);
                return new ResultDto
                {
                    IsSuccessful = false,
                    collectionResult = errrors,
                };
            }
            return new ResultDto
            {
                IsSuccessful = true
            };
        }

        public string CreateJwtTocken(DbUser user)
        {

            var roles = _userManager.GetRolesAsync(user).Result;
            var claims = new List<Claim>()
                {
                    //new Claim(JwtRegisteredClaimNames.Sub, user.Id)
                    new Claim("id", user.Id.ToString()),
                    new Claim("name", user.UserName)
                };

            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("11-sdfasdf-22233222222"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                expires: DateTime.Now.AddHours(1));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<ResultDto> ForgotPassword(ForgotPasswordDto entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResultDto> Login(LoginDto model)
        {
            var dictionaryResult = new Dictionary<string, string>();
            var result = await _signInManager
                   .PasswordSignInAsync(model.Email, model.Password,
                   false, false);

            if (!result.Succeeded)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    collectionResult = null,
                };
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user.EmailConfirmed == false)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    collectionResult = null,
                };
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            dictionaryResult.Add("token", CreateJwtTocken(user));
            return new ResultDto
            {
                IsSuccessful = true,
                collectionResult = dictionaryResult,
            };
        }

        public async Task<ResultDto> Register(RegisterDto model)
        {
            var user = new DbUser
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return new ResultDto
                {
                    IsSuccessful = false,
                    collectionResult = null,
                };
            }
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var frontEndURL = _configuration.GetValue<string>("FrontEndURL");//"https://localhost:44339/";

            var callbackUrl =
                $"{frontEndURL}confirmemail?userId={user.Id}&" +
                $"code={WebUtility.UrlEncode(code)}";
            Debug.WriteLine(callbackUrl);
            //IEmailSender emailServer = new EmailSender(this._configuration);
            //await emailServer.SendEmailAsync(model.Email, "Confirm Email",
            //   $"Please confirm your email by clicking here: " +
            //   $"<a href='{callbackUrl}'>link</a>");
            CreateEmailString.SendAccountConfirm(_configuration,_env,callbackUrl,user.Email);
            return new ResultDto
            {
                IsSuccessful = true,
                collectionResult = null,
            };
        }

        //public class EmailSender : IEmailSender
        //{
        //    private readonly IConfiguration _configuration;
        //    public EmailSender(IConfiguration configuration)
        //    {
        //        _configuration = configuration;
        //    }
        //    public Task SendEmailAsync(string email, string subject, string htmlMessage)
        //    {
        //        return Execute(subject, htmlMessage, email);
        //    }

        //    public Task Execute(string subject, string body, string email)
        //    {
        //        string emailOwner = "semenplujara@gmail.com";
        //        string passwordOwner = "Qwerty1-";
        //        int portOwner = 587;
        //        string hostOwner = "smtp.gmail.com";
        //        using (MailMessage mm = new MailMessage(emailOwner, email))
        //        {
        //            mm.Subject = subject;
        //            mm.Body = body;
        //            mm.IsBodyHtml = true;
        //            SmtpClient smtp = new SmtpClient();
        //            smtp.Host = hostOwner;
        //            smtp.EnableSsl = true;
        //            NetworkCredential NetworkCred = new NetworkCredential(emailOwner, passwordOwner);
        //            smtp.UseDefaultCredentials = true;
        //            smtp.Credentials = NetworkCred;
        //            smtp.Port = portOwner;
        //            smtp.Send(mm);
        //            return Task.FromResult(0);
        //        }
        //    }
        //}
    }
}