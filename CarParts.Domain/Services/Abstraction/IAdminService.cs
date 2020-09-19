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
    public interface IAdminService
    {
        
        Task<ResultDto> addUser(CreateUser user);
     
        Task<ResultDto> deleteUser(int id);
        //addCategory
        //addFilter
        //Task<DTOResult> AsynkAwait

    }
}
