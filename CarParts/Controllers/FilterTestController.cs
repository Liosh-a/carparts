using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CarParts.DataAccess;
using CarParts.DataAccess.Entities;
using CarParts.Dto;
using CarParts.Dto.ViewModels;
using CarParts.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarParts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterTestController : ControllerBase
    {
        private readonly EFDbContext _context;

        private readonly ILogger<FilterTestController> _logger;

        public FilterTestController(ILogger<FilterTestController> logger, EFDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get( )
        {
            var filtersList = GetListFilters(_context);
            long[] filterValueSearchList = {1}; //масив ID вибраних фільтрів
            var query = _context
                .Cars
                .Include(f => f.Filtres)
                .AsQueryable();
            foreach (var fName in filtersList)
            {
                int countFilter = 0; //Кількість співпадінь у даній групі фільрів
                var predicate = PredicateBuilder.False<Car>();
                foreach (var fValue in fName.Children)
                {
                    for (int i = 0; i < filterValueSearchList.Length; i++)
                    {
                        var idV = fValue.Id;
                        if (filterValueSearchList[i] == idV)
                        {
                            predicate = predicate
                                .Or(p => p.Filtres

                                    .Any(f => f.FilterValueId == idV));
                            countFilter++;
                        }
                    }
                }
                if (countFilter != 0)
                    query = query.Where(predicate);
            }
            int count = query.Count();

            var res = query
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Filters = p.Filtres
                        .Select(f => new
                        {
                            Filter = f.FilterNameOf.Name,
                            ValueId = f.FilterValueId,
                            Value = f.FilterValueOf.Name
                        })

                })
                .ToList();

            return Ok(res);

        }

        private List<FNameViewModel> GetListFilters(EFDbContext context)
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

            return result.ToList();
        }

    }
}
