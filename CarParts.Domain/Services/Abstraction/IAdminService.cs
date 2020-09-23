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
        
        Task<ResultDto> addUser(CreateUserDto user);
     
        Task<ResultDto> deleteUser(int id);

        Task<CollectionResultDto<UserDto>> listUsers(int page);
        Task<ResultDto> addCategory(CreateCategoryDto category);
        Task<ResultDto> removeCategory(int id);
        Task<ResultDto> addFilterGroup(string filterName,string[] filteValue);
        string productSeeder();

        //addCategory
        //addFilter
        //Task<DTOResult> AsynkAwait

    }
}
