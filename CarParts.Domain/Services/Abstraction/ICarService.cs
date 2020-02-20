﻿using CarParts.DataAccess;
using CarParts.DataAccess.Entities;
using CarParts.Dto;
using CarParts.Dto.DtoModels;
using CarParts.Dto.DtoResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Services.Abstraction
{
    public interface ICarService
    {
        Task<CollectionResultDto<Car>> GetCarsByFilters(GerCarDto carDto);
        Task<CollectionResultDto<FNameViewModel>> GetListFilters(EFDbContext context);
    }
}
