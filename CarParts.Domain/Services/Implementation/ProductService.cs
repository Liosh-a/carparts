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
using Microsoft.Extensions.Configuration;


namespace CarParts.Domain.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public ProductService(EFDbContext context,
            IConfiguration configuration,
            IHostingEnvironment env)
        {
            _context = context;
            _configuration = configuration;
            _env = env;
        }


        public ResultDto GetCategory()
        {
            var cat = _context.Categories.Count();
            var categories = _context.Categories.ToList();
            var res = new CollectionResultDto<Category>();
            res.Data = categories;
            res.Count = categories.Count;
            return res;
        }

        public ResultDto GetMark(int year)
        {

            //var categories = _context.AllCars.Select(q=> q.ProductionStopYear).ToList();

            //var cat = _context.AllCars.Where(q=>Int64.Parse(q.ProductionStartYear)>year&&q.ProductionStopYear!="-"?Int64.Parse(q.ProductionStopYear)<year:true).Select(z=>new BrandDto{Id=z.Id,Brand=z.Brand }).Distinct().ToList();
            var res = new CollectionResultDto<BrandDto>();
            //res.Data = cat;
            return res;
        }

        public ResultDto GetModel(int mark)
        {
            var cat = _context.Categories.Count();
            var categories = _context.Categories.ToList();
            var res = new CollectionResultDto<Category>();
            res.Data = categories;
            return res;
        }

        public async Task<ResultDto> GetYear()
        {
            List<int> yearList = new List<int>();
            var productstart = _context.Products.Select(c => c.ProductionStartYear).ToList();
            var productstop = _context.Products.Select(c => c.ProductionStopYear).ToList();
            var res = yearList;

            return new ResultDto();
        }
    }
}
