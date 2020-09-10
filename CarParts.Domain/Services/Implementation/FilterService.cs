using CarParts.DataAccess;
using CarParts.Domain.Services.Abstraction;
using CarParts.Dto.DtoResult;
using CarParts.Dto.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace CarParts.Domain.Services.Implementation
{
    public class FilterService : IFilterService
    {
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public FilterService(EFDbContext context,
            IConfiguration configuration,
            IHostingEnvironment env)
        {
            _context = context;
            _configuration = configuration;
            _env = env;
        }

        public Task<SingleResultDto<string>> CreateFilterName(FilterNameViewModel filterName)
        {
            if (ModelState.IsValid)
            {
                _context.FiltersName.Add(new FilterName { Name = filterName.Name });
                _context.SaveChanges();
               
            }
        }
    }
}
