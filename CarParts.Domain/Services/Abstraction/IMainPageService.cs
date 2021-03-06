﻿using CarParts.DataAccess.Entities;
using CarParts.Dto.DtoModels;
using CarParts.Dto.DtoResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Services.Abstraction
{
    public interface IMainPageService
    {
        Task<CollectionResultDto<GetCategoryDto>> GetCategory();
        Task<CollectionResultDto<GetChildCategoryDto>> GetChildCategoryByCar(int catid,int carid);
        Task<CollectionResultDto<GetChildCategoryDto>> GetChildCategory(int catid);
        //Task<CollectionResultDto<CategoryDto>> GetCategoryByCar(int carid);
        Task<CollectionResultDto<ModelDto>> GetModel(List<int> id);
        Task<CollectionResultDto<BrandDto>> GetMark(int year);
        Task<SingleResultDto<List<int>>> GetYear();


    }
}
