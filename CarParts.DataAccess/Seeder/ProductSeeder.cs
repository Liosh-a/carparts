using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bogus;
using CarParts.DataAccess.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CarParts.DataAccess.Seeder
{
    public class ProductSeeder
    {
        public static void SeedProduct(EFDbContext _context)
        {
            var faker = new Faker();
            var start = 0;
            for (int i = 0; i <= 1000; i++)
            {
                start = faker.Random.Int(1999, 2019);
                _context.Products.AddAsync(new Product
                {
                    Name = faker.Commerce.ProductName(),
                    PurchasePrice = faker.Random.Decimal(10, 100),
                    SellingPrice = faker.Random.Decimal(1000, 10000),
                    ProductionStartYear = faker.Random.Int(1998, start),
                    ProductionStopYear = faker.Random.Int(start, 2020),
                    UniqueName = faker.UniqueIndex.ToString() + i.ToString(),
                    CarId= faker.Random.Int(1,1109),
                    CategoryId = faker.Random.Int(1,20),
                }); 
                
                
            }
            //List<Filter> filters = new List<Filter>();
            //var productid = _context.Products.Select(x => x.Id).ToList();
            //var filtergroup = _context.FilterNameGroups.Select(x => x).ToList();
            //var filterNames = _context.FilterNames.Select(x => x.Id).ToList();
            //foreach (var el in filterNames) {
            //    var idlist = filtergroup.Where(y => y.FilterNameId == el.Id).Select(x => x.FilterValueId)
            //        }
            
            //foreach (var el in productid)
            //{

            //    filters.Add(new Filter { FilterNameId = 1, FilterValueId = faker.Random.Int(1, 8), ProductId = el });

            //}



            //foreach (var item in filters)
            //{
            //    var f = _context.Filters.SingleOrDefault(p => p == item);
            //    if (f == null)
            //    {
            //        _context.Filters.Add(new Filter { FilterNameId = item.FilterNameId, FilterValueId = item.FilterValueId, ProductId = item.ProductId });
            //        _context.SaveChanges();
            //    }
            //}
        }
    }
}
