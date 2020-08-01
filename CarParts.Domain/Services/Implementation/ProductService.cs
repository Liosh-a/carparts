using AutoMapper.Configuration;
using CarParts.DataAccess;
using CarParts.Domain.Services.Abstraction;
using CarParts.Dto.DtoResult;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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


        public Task<ResultDto> GetCategory()
        {
            throw new NotImplementedException();
        }
    }
}
