using AutoMapper;
using CarParts.DataAccess.Entities;
using CarParts.Dto.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarParts.Domain.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<DbUser, UserDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            //.AfterMap((s, d) => {
            //     foreach (var c in d.Children)
            //         c.Parent = d;
            // })
        }
    }
}
