using CarParts.DataAccess.Entities;
using CarParts.Dto.DtoModels;
using CarParts.Dto.DtoResult;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Services.Abstraction
{
    public interface IAccountService
    {
        Task<ResultDto> ConfirmEmail(string userid,ConfirmEmailDto entity);
        Task<ResultDto> Register(RegisterDto entity);
        Task<ResultDto> Login(LoginDto entity);
        Task<ResultDto> ForgotPassword(ForgotPasswordDto entity);
        string CreateJwtTocken(DbUser entity);

    }
}