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
using System.Data.Entity;
using CarParts.Helpers;
using Microsoft.Extensions.Configuration;

namespace CarParts.Domain.Services.Implementation
{
    public class CarService : ICarService
    {
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public CarService(EFDbContext context,
            IConfiguration configuration,
            IHostingEnvironment env)
        {
            _context = context;
            _configuration = configuration;
            _env = env;
        }

        public Task<CollectionResultDto<Car>> GetCarsByFilters(GetCarDto carDto)
        {
            throw new NotImplementedException();
        }

        //public Task<CollectionResultDto<Car>> GetCarsByFilters(GetCarDto carDto)
        //{
        //    var filtersList = GetListFilters(_context);
        //    long[] filterValueSearchList = carDto.FilterList; //масив ID вибраних фільтрів
        //    var query = _context
        //        .Cars
        //        .Include(f => f.Filtres)
        //        .AsQueryable();
        //    foreach (var fName in filtersList)
        //    {
        //        int countFilter = 0; //Кількість співпадінь у даній групі фільрів
        //        var predicate = PredicateBuilder.False<Car>();
        //        foreach (var fValue in fName.Children)
        //        {
        //            for (int i = 0; i < filterValueSearchList.Length; i++)
        //            {
        //                var idV = fValue.Id;
        //                if (filterValueSearchList[i] == idV)
        //                {
        //                    predicate = predicate
        //                        .Or(p => p.Filtres

        //                            .Any(f => f.FilterValueId == idV));
        //                    countFilter++;
        //                }
        //            }
        //        }
        //        if (countFilter != 0)
        //            query = query.Where(predicate);
        //    }
        //    int count = query.Count();

        //    var res = query
        //        .Select(p => new
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            Price = p.Price,
        //            Filters = p.Filtres
        //                .Select(f => new
        //                {
        //                    Filter = f.FilterNameOf.Name,
        //                    ValueId = f.FilterValueId,
        //                    Value = f.FilterValueOf.Name
        //                })

        //        })
        //        .OrderBy(x => x.Name).Skip(carDto.pageIndex-1*10).Take(10).ToList();

        //    return Ok(res);
        //}

        public List<FNameViewModel> GetListFilters(EFDbContext context)
        {
            var queryName = from f in context.FilterNames.AsQueryable()
                            select f;
            var queryGroup = from g in context.FilterNameGroups.AsQueryable()
                             select g;

            //Отримуємо загальну множину значень
            var query = from u in queryName
                        join g in queryGroup on u.Id equals g.FilterNameId into ua
                        from aEmp in ua.DefaultIfEmpty()
                        select new
                        {
                            FNameId = u.Id,
                            FName = u.Name,
                            FValueId = aEmp != null ? aEmp.FilterValueId : 0,
                            FValue = aEmp != null ? aEmp.FilterValueOf.Name : null,
                        };

            //Групуємо по іменам і сортуємо по спаданню імен
            //var groupNames = (from f in query
            //                  group f by new
            //                  {
            //                      Id = f.FNameId,
            //                      Name = f.FName
            //                  } into g
            //                  //orderby g.Key.Name
            //                  select g).OrderByDescending(g => g.Key.Name).AsEnumerable();

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
    }
}