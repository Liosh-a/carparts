 using AutoMapper.Configuration;
using CarParts.DataAccess;
using CarParts.DataAccess.Entities;
using CarParts.Domain.Services.Abstraction;
using CarParts.Dto;
using CarParts.Dto.DtoModels;
using CarParts.Dto.DtoResult;
using CarParts.Helpers;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<FNameViewModel> GetListFilter(int categoryId)
        {
            var queryName = from f in _context.FilterNames
                            .Where(c=>c==_context.FilterNameCategories.Select(y=>y.CategoryId==categoryId))
                            .AsQueryable()
                            select f;
            var queryGroup = from g in _context.FilterNameGroups.AsQueryable()
                             select g;

            //Отримуємо загальну множину значень
            var query = from u in queryName
                        join g in queryGroup on u.Id equals g.FilterNameId  into ua
                        from aEmp in ua.DefaultIfEmpty()
                        select new
                        {
                            FNameId = u.Id,
                            FName = u.Name,
                            FValueId = aEmp != null ? aEmp.FilterValueId : 0,
                            FValue = aEmp != null ? aEmp.FilterValueOf.Name : null,
                        };

            var groupNames = query
                        .AsEnumerable()
                        .GroupBy(f => new { Id = f.FNameId, Name = f.FName })
                        .Select(g => g)
                        .OrderByDescending(p => p.Key.Name);

            //По групах отримуємо
            var result = from fName in groupNames
                         select
                         new FNameViewModel
                         {
                             Id = fName.Key.Id,
                             Name = fName.Key.Name,
                             Children = (from v in fName
                                         group v by new FValueViewModel
                                         {
                                             Id = v.FValueId,
                                             Value = v.FValue
                                         } into g
                                         select g.Key)
                                         .OrderBy(l => l.Value).ToList()
                         };
            return new List<FNameViewModel>(result);

        }

        public Task<CollectionResultDto<Product>> GetProductbyCarIdCategoryandFilteres(int carId, FilterOnUse filterOnUse, int page)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionResultDto<Product>> GetProductbyCategoryandFilters(int categoryId, FilterOnUse filterOnUse, int page)
        {
            throw new NotImplementedException();
        }

        public Task<SingleResultDto<Product>> GetProductById(string productUnickName)
        {
            throw new NotImplementedException();
        }
    }
}
