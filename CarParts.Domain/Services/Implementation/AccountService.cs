using CarParts.Domain.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using CarParts.DataAccess.Entities;
using CarParts.DataAccess;
using CarParts.Dto.DtoModels;
using CarParts.Dto.DtoResult;
using System.Threading.Tasks;

namespace CarParts.Domain.Services.Implementation
{
    class AccountService : IAccountService
    {
        private readonly EFDbContext _context;
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public Task<ResultDto> ForgotPassword(ForgotPasswordDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResultDto> Login(LoginDto entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResultDto> Register(RegisterDto entity)
        {
            throw new System.NotImplementedException();
        }
    }
}