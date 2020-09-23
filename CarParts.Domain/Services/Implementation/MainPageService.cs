using CarParts.DataAccess;
using CarParts.DataAccess.Entities;
using CarParts.Domain.Services.Abstraction;
using CarParts.Dto;
using CarParts.Dto.DtoModels;
using CarParts.Dto.DtoResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using CarParts.Helpers;
//using AutoMapper.Configuration;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CarParts.Domain.Mapping;

namespace CarParts.Domain.Services.Implementation
{
    public class MainPageService : IMainPageService
    {
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        private readonly IMapper _mapper;

        public MainPageService(EFDbContext context,
            IConfiguration configuration,
            IHostingEnvironment env,
            IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _env = env;
            _mapper = mapper;
        }


        public async Task<CollectionResultDto<GetCategoryDto>> GetCategory()
        {
            //var cat = _context.Categories.Count();
            var categories = _context.Categories.ToList();
            var paCategories = _context.Categories.Where(x=>x.ParentId==null).Select(x => x).ToList();
            var res = new List<GetCategoryDto>();
            var parentId = new CategoryDto();


            foreach(var el in categories)
            {
                if (paCategories.FirstOrDefault(x => x.Id == el.ParentId )!=null)
                {
                    var pacat = _mapper.Map<CategoryDto>(paCategories.FirstOrDefault(x => x.Id == el.ParentId));
                    if (res.FirstOrDefault(x => x.parentCategory.Id == el.ParentId) == null)
                    {
                        var list = new List<CategoryDto>();
                        list.Add(_mapper.Map<CategoryDto>(el));
                        res.Add(new GetCategoryDto
                        {
                            parentCategory = pacat,
                            childCategories = list

                        }) ;
                    }
                    else
                    {
                        res.FirstOrDefault(x => x.parentCategory.UrlSlug == pacat.UrlSlug).childCategories.Add(_mapper.Map<CategoryDto>(el));
                    }
                    
                    
                }
            }
            //foreach(var el in categories)
            //{
            //    if (el.ParentId == null)
            //    {
            //        parentId = el.Id;
            //    }
            //    if (el.ParentId == parentId)
            //    {
            //        res.Add(new CategoryDto
            //        {
            //            Id = el.Id,
            //            Name = el.Name,
            //            ParentId = el.ParentId ?? default(int),
            //            UrlSlug = el.UrlSlug,
            //            Description = el.Description ?? default(string),
            //            IsActive = true
            //        });
            //    }
            //}

            return new CollectionResultDto<GetCategoryDto> {
                Data = res,
                Count = res.Count()
            };
        }

        public async Task<CollectionResultDto<CategoryDto>> GetCategoryByCar(int carid)
        {
           // var cat = _context.Categories.Count();
            var categories =await  _context.Categories.ToListAsync();
            var res = new List<CategoryDto>();
            foreach (var el in categories)
            {
                if (_context.Products.FirstOrDefault(c => c.CarId == carid && c.CategoryId == el.Id)!=null)
                {
                    res.Add(new CategoryDto
                    {
                        Id = el.Id,
                        Name = el.Name,
                        ParentId = el.ParentId ?? default(int),
                        UrlSlug = el.UrlSlug,
                        Description = el.Description,
                        IsActive = true
                    });
                }
                else
                {
                    res.Add(new CategoryDto
                    {
                        Id = el.Id,
                        Name = el.Name,
                        ParentId = el.ParentId ?? default(int),
                        UrlSlug = el.UrlSlug,
                        Description = el.Description,
                        IsActive = false
                    });
                }
            }
            return new CollectionResultDto<CategoryDto>
            {
                Data = res,
            };
        }

        public async Task<CollectionResultDto<BrandDto>> GetMark(int year)
        {
            //var categories = _context.AllCars.Select(q=> q.ProductionStopYear).ToList();
            //var cat = _context.AllCars.Where(q=>Int64.Parse(q.ProductionStartYear)>year&&q.ProductionStopYear!="-"?Int64.Parse(q.ProductionStopYear)<year:true).Select(z=>new BrandDto{Id=z.Id,Brand=z.Brand }).Distinct().ToList();
            //var cars = _context.AllCars.Where(c => c.Id.Equals(_context.Products.Where(a => a.ProductionStartYear >= year && a.ProductionStopYear <= year).Select(x=>x.CarId)));
            //var cars = _context.Products.Where(el => el.ProductionStartYear >= year && el.ProductionStopYear <= year).Select(el => el.Cars).ToList();
            var cars = _context.AllCars.Where(el=>el.Products.Where(pr=>pr.ProductionStartYear<=year&&pr.ProductionStopYear>=year).Count()>0).ToList();
            //cars.ToList().Sort();
            var res = new List<BrandDto>();


            string y = "";
            foreach (var el in cars)
            {
                if (el.Brand != y)
                {

                        res.Add(new BrandDto { Brand = el.Brand, Id = new List<int>() { el.Id } });
                    
                }
                else
                {
                    res.FirstOrDefault(c => c.Brand == el.Brand).Id.Add(el.Id);
                }
                y = el.Brand;
            }
            //res.Data = cat;
            return new CollectionResultDto<BrandDto>
            {
                Data=res,
            };
        }

        public async Task<CollectionResultDto<ModelDto>> GetModel(List<int> id)
        {
            var res = new List<ModelDto>();
            foreach(var el in id)
            {
                 res.Add(new ModelDto { Model = _context.AllCars.FirstOrDefault(c => c.Id == el).Model, Id = el });
            }


            //var cat = _context.Categories.Count();
            //var categories = _context.Categories.ToList();
            //var res = new CollectionResultDto<Category>();
            //res.Data = categories;
            return new CollectionResultDto<ModelDto>
            {
                Data=res,
            };
        }

        public async Task<SingleResultDto<List<int>>> GetYear()
        {
            var yearList = new List<int>();
            yearList.AddRange( _context.Products.Select(c => c.ProductionStartYear).ToList());
            yearList.AddRange(_context.Products.Select(c => c.ProductionStopYear).ToList());

            yearList = yearList.Distinct().ToList();
            yearList.Sort();
            return new SingleResultDto<List<int>>()
            {
                Data = yearList,
            };
        }
    }
}
