﻿using CarParts.DataAccess;
using CarParts.DataAccess.Entities;
using CarParts.Domain.Services.Abstraction;
using CarParts.Dto;
using CarParts.Dto.DtoModels;
using CarParts.Dto.DtoResult;
using CarParts.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace CarParts.Domain.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        private readonly IMapper _mapper;


        public ProductService(EFDbContext context,
            IConfiguration configuration,
            IHostingEnvironment env,
            IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _env = env;
            _mapper = mapper;
        }

        public async Task<List<FNameViewModel>> GetListFilter(int categoryId)
        {
            var queryName = from f in _context.FilterNames
                            .Where(c=>c==_context.FilterNameCategories.Select( y=> y.CategoryId==categoryId))
                            .AsQueryable()
                            select f;
            var queryGroup = from g in  _context.FilterNameGroups.AsQueryable()
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
            return result.ToList();

        }

        public async Task<CollectionResultDto<ProductDto>> GetProductbyCarIdCategoryandFilteres(int categoryId, int carId, FilterOnUse filterOnUse, int pageIndex)
        {
            var filtersList = GetListFilters();
            long[] filterValueSearchList = filterOnUse.filters.ToArray(); //масив ID вибраних фільтрів
            var query = _context
                .Products
                .Include(f => f.Filtres)
                .Include(y => y.CarId)
                .Include(c => c.CategoryId)
                .AsQueryable();
            foreach (var fName in filtersList)
            {
                int countFilter = 0; //Кількість співпадінь у даній групі фільрів
                var predicate = PredicateBuilder.False<Product>();
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
            var res = new CollectionResultDto<ProductDto>();
            var result = query
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PurchasePrice = p.PurchasePrice,
                    SellingPrice = p.SellingPrice,
                    ProductionStartYear = p.ProductionStartYear,
                    ProductionStopYear = p.ProductionStopYear,
                    UniqueName = p.UniqueName,
                    CategoryId = p.CategoryId,
                    CarId = p.CarId,
                    Filter = p.Filtres
                        .Select(f => new
                        {
                            Filter = f.FilterNameOf.Name,
                            ValueId = f.FilterValueId,
                            Value = f.FilterValueOf.Name
                        })

                }).Where(c=>c.CategoryId==categoryId && c.CarId==carId ).OrderBy(x => x.Name).Skip((pageIndex - 1) * 10).Take(10);
            res.Data =  _mapper.Map<List<ProductDto>>(result);
            res.Data.Count();
            return res;
        }

        public async Task<CollectionResultDto<ProductDto>> GetProductbyCategoryandFilters(int categoryId, FilterOnUse filterOnUse, int pageIndex)
        {
            var filtersList = GetListFilters();
            long[] filterValueSearchList = filterOnUse.filters.ToArray(); //масив ID вибраних фільтрів
            var query = _context
                .Products
                .Include(f => f.Filtres)
                .Include(y => y.CarId)
                .Include(c => c.CategoryId)
                .AsQueryable();
            foreach (var fName in filtersList)
            {
                int countFilter = 0; //Кількість співпадінь у даній групі фільрів
                var predicate = PredicateBuilder.False<Product>();
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
            var res = new CollectionResultDto<ProductDto>();
            var result = query
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PurchasePrice = p.PurchasePrice,
                    SellingPrice = p.SellingPrice,
                    ProductionStartYear = p.ProductionStartYear,
                    ProductionStopYear = p.ProductionStopYear,
                    UniqueName = p.UniqueName,
                    CategoryId = p.CategoryId,
                    CarId = p.CarId,
                    Filter = p.Filtres
                        .Select(f => new
                        {
                            Filter = f.FilterNameOf.Name,
                            ValueId = f.FilterValueId,
                            Value = f.FilterValueOf.Name
                        })

                }).Where(c => c.CategoryId == categoryId).OrderBy(x => x.Name).Skip((pageIndex - 1) * 10).Take(10);
            res.Data = _mapper.Map<List<ProductDto>>(result);
            res.Data.Count();
            return res;
        }

        public async Task<SingleResultDto<ProductDto>> GetProductById(string productUnickName)
        {
            var query = _context
                .Products
                .Include(f => f.Filtres)
                .Include(y => y.CarId)
                .Include(c => c.CategoryId)
                .AsQueryable();

            var res = query
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PurchasePrice = p.PurchasePrice,
                    SellingPrice = p.SellingPrice,
                    ProductionStartYear = p.ProductionStartYear,
                    ProductionStopYear = p.ProductionStopYear,
                    UniqueName = p.UniqueName,
                    CategoryId = p.CategoryId,
                    CarId = p.CarId,
                    Filter = p.Filtres
                        .Select(f => new
                        {
                            Filter = f.FilterNameOf.Name,
                            ValueId = f.FilterValueId,
                            Value = f.FilterValueOf.Name
                        })

                }).Where(c => c.UniqueName == productUnickName);
            var result = _mapper.Map<ProductDto>(res);


            return new SingleResultDto<ProductDto>{
                Data = result,
                IsSuccessful=true,
            };
        }

        /// //////////////////////////////////////////
        private List<FNameViewModel> GetListFilters()
        {
            var queryName = from f in _context.FilterNames.AsQueryable()
                            select f;
            var queryGroup = from g in _context.FilterNameGroups.AsQueryable()
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
