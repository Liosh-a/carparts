using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarParts.DataAccess;
using CarParts.DataAccess.Entities;
using CarParts.Domain.Services.Abstraction;
using CarParts.Dto;
using CarParts.Dto.DtoModels;
using CarParts.Dto.ViewModels;
using CarParts.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarParts.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[ApiController]
    public class FilterTestController : ControllerBase
    {
        private readonly IFilterService _filterService;

        public FilterTestController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpPost("CreateName")]
        [ValidateAntiForgeryToken]
        public async ActionResult CreateFilterName([FromBody]FilterNameViewModel filterName)
        {
            if (ModelState.IsValid)
            {
                _context.FiltersName.Add(new FilterName { Name = filterName.Name });
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return Ok(filterName);
        }

        //private readonly EFDbContext _context;

        //private readonly ILogger<FilterTestController> _logger;

        //public FilterTestController(ILogger<FilterTestController> logger, EFDbContext context)
        //{
        //    _logger = logger;
        //    _context = context;
        //}

        //[HttpPost("filteravalibal")]
        //public IActionResult GetAvalibalFilters([FromBody]FilterOnUse filteronuse)
        //{
        //    var filteronu = filteronuse.filters;
        //    var filtersList = GetListFilters(_context);
        //    List<FilterDto> filters = new List<FilterDto>();
        //    foreach(var FName in filtersList)
        //    {
        //        foreach (var FValue in FName.Children) {
        //            if (filteronu.Contains(FValue.Id) == false)
        //            {
        //                filteronu.Add(FValue.Id);
        //                var r = CheakForFilter(filteronu);
        //                filters.Add(new FilterDto { filterCount = r, filterId = FValue.Id });
        //                filteronu.Remove(FValue.Id);
        //            }
        //        }
        //    }
        //    var res=filters.OrderBy(x=>x.filterId);

        //    return Ok(res);
        //}


        //[HttpPost("car")]
        //public IActionResult Get([FromBody] GetCarDto getCar)
        //{
        //    var filtersList = GetListFilters(_context);
        //    long[] filterValueSearchList = getCar.FilterList.ToArray(); //масив ID вибраних фільтрів
        //    var query = _context
        //        .Products
        //        .Include(f => f.Filtres)
        //        .AsQueryable();
        //    foreach (var fName in filtersList)
        //    {
        //        int countFilter = 0; //Кількість співпадінь у даній групі фільрів
        //        var predicate = PredicateBuilder.False<Product>();
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
        //            PurchasePrice = p.PurchasePrice,
        //            SellingPrice = p.SellingPrice,
        //            Filters = p.Filtres
        //                .Select(f => new
        //                {
        //                    Filter = f.FilterNameOf.Name,
        //                    ValueId = f.FilterValueId,
        //                    Value = f.FilterValueOf.Name
        //                })

        //        }).OrderBy(x=>x.Name).Skip((getCar.pageIndex-1)*10).Take(10).ToList();
        //    return Ok(res);

        //}

        //private List<FNameViewModel> GetListFilters(EFDbContext context)
        //{
        //    var queryName = from f in context.FilterNames.AsQueryable()
        //                    select f;
        //    var queryGroup = from g in context.FilterNameGroups.AsQueryable()
        //                     select g;

        //    //Отримуємо загальну множину значень
        //    var query = from u in queryName
        //                join g in queryGroup on u.Id equals g.FilterNameId into ua
        //                from aEmp in ua.DefaultIfEmpty()
        //                select new
        //                {
        //                    FNameId = u.Id,
        //                    FName = u.Name,
        //                    FValueId = aEmp != null ? aEmp.FilterValueId : 0,
        //                    FValue = aEmp != null ? aEmp.FilterValueOf.Name : null,
        //                };

        //    //Групуємо по іменам і сортуємо по спаданню імен
        //    //var groupNames = (from f in query
        //    //                  group f by new
        //    //                  {
        //    //                      Id = f.FNameId,
        //    //                      Name = f.FName
        //    //                  } into g
        //    //                  //orderby g.Key.Name
        //    //                  select g).OrderByDescending(g => g.Key.Name).AsEnumerable();

        //    var groupNames = query
        //                .AsEnumerable()
        //                .GroupBy(f => new { Id = f.FNameId, Name = f.FName })
        //                .Select(g => g)
        //                .OrderByDescending(p => p.Key.Name);

        //    //По групах отримуємо
        //    var result = from fName in groupNames
        //                 select
        //                 new FNameViewModel
        //                 {
        //                     Id = fName.Key.Id,
        //                     Name = fName.Key.Name,
        //                     Children = (from v in fName
        //                                 group v by new FValueViewModel
        //                                 {
        //                                     Id = v.FValueId,
        //                                     Value = v.FValue
        //                                 } into g
        //                                 select g.Key)
        //                                 .OrderBy(l => l.Value).ToList()
        //                 };

        //    return result.ToList();
        //}
        //private long CheakForFilter(List<long> filtertouse)
        //{
        //    var filtersList = GetListFilters(_context);
        //    long[] filterValueSearchList = filtertouse.ToArray(); //масив ID вибраних фільтрів
        //    var query = _context
        //        .Products
        //        .Include(f => f.Filtres)
        //        .AsQueryable();
        //    foreach (var fName in filtersList)
        //    {
        //        int countFilter = 0; //Кількість співпадінь у даній групі фільрів
        //        var predicate = PredicateBuilder.False<Product>();
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

        //    return count;
        //}
    }
}
