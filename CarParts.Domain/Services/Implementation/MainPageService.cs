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
            var res = new CollectionResultDto<CategoryDto>();
            foreach (var el in categories)
            {
                if (_context.Products.FirstOrDefault(c => c.CarId == carid && c.CategoryId == el.Id)!=null)
                {
                    res.Data.Add(new CategoryDto
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
                    res.Data.Add(new CategoryDto
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
            res.Count = categories.Count;
            return res;
        }

        public async Task<CollectionResultDto<BrandDto>> GetMark(int year)
        {
            //var categories = _context.AllCars.Select(q=> q.ProductionStopYear).ToList();
            //var cat = _context.AllCars.Where(q=>Int64.Parse(q.ProductionStartYear)>year&&q.ProductionStopYear!="-"?Int64.Parse(q.ProductionStopYear)<year:true).Select(z=>new BrandDto{Id=z.Id,Brand=z.Brand }).Distinct().ToList();
            var cars = _context.AllCars.Select(c=>c).Where(c => c.Id.Equals(_context.Products.Select(t=>t).Where(a => a.ProductionStartYear >= year && a.ProductionStopYear <= year)));
            cars.OrderBy(c => c.Brand);
            var res = new CollectionResultDto<BrandDto>();

            string y=null;
            foreach(var el in cars)
            {
                if (el.Brand != y)
                {
                    if (res.Data.FirstOrDefault(c => c.Brand == y) == null)
                    {
                        res.Data.Add(new BrandDto { Brand = el.Brand, Id = new List<int>() {el.Id} });
                    }
                }
                else
                {
                    res.Data.FirstOrDefault(c => c.Brand == el.Brand).Id.Add(el.Id);
                }
                y = el.Brand;
            }
            res.Count = res.Data.Count;
            //res.Data = cat;
            return res;
        }

        public async Task<CollectionResultDto<ModelDto>> GetModel(List<int> id)
        {
            var res = new CollectionResultDto<ModelDto>();
            foreach(var el in id)
            {
                 res.Data.Add(new ModelDto { Model = _context.AllCars.FirstOrDefault(c => c.Id == el).Model, Id = el });
            }


            //var cat = _context.Categories.Count();
            //var categories = _context.Categories.ToList();
            //var res = new CollectionResultDto<Category>();
            //res.Data = categories;
            return res;
        }

        public async Task<SingleResultDto<List<int>>> GetYear()
        {
            var yearList = new List<int>();
            var product = _context.Products.Select(c => c.ProductionStartYear).ToList();
            var productstop = _context.Products.Select(c => c.ProductionStopYear).ToList();

            product.AddRange(productstop);
            product.OrderBy(i=>i);
            var y = 0;
            foreach(var el in product)
            {
                if(el==y)
                {
                    product.Remove(el);
                }
                y = el;
                
            }
            
            return new SingleResultDto<List<int>>()
            {
                Data = product
            };
        }
    }
}
