using CarParts.Dto.DtoModels;
using CarParts.Dto.DtoResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Services.Abstraction
{
    public interface IAccountService
    {
        Task<ResultDto> Register(RegisterDto entity);
        Task<ResultDto> Login(LoginDto entity);
        Task<ResultDto> ForgotPassword(ForgotPasswordDto entity);

    }
}