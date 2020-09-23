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
            List<Product> test = new List<Product>();
            var categoryId = _context.Categories.Where(el => el.Categories.Count == 0).Select(el => el.Id).ToList();
            for (int i = 0; i < categoryId.Count - 1; i++)
            {
                start = faker.Random.Int(1999, 2019);
                test.Add(new Product
                {
                    Name = faker.Commerce.ProductName(),
                    PurchasePrice = faker.Random.Decimal(10, 100),
                    SellingPrice = faker.Random.Decimal(1000, 10000),
                    ProductionStartYear = faker.Random.Int(1998, start),
                    ProductionStopYear = faker.Random.Int(start, 2020),
                    UniqueName = faker.UniqueIndex.ToString() + i.ToString(),
                    CarId = faker.Random.Int(1, 1109),
                    CategoryId = categoryId[i],
                });
            }
            _context.Products.AddRange(test);
            _context.SaveChanges();

            List<Filter> filters = new List<Filter>();
            //var productid = _context.Products.Select(x => x.Id).ToList();
            var filtergroup = _context.FilterNameGroups.ToList();
            //foreach (var el in filterNames) {
            //    var idlist = filtergroup.Where(y => y.FilterNameId == el.Id).Select(x => x.FilterValueId)
            //        }

            var uniquGroupName = filtergroup.Select(el => el.FilterNameId).ToList().Distinct().ToList();

            foreach (var el in test)
            {
                var groupNameId = uniquGroupName.ToList();
                for (int i = 0; i < 3; i++)
                {
                    var useGroupName = faker.PickRandom(groupNameId);

                    filters.Add(new Filter { FilterNameId = useGroupName, FilterValueId = faker.PickRandom(filtergroup.Where(e => e.FilterNameId == useGroupName).Select(e => e.FilterValueId).ToList()), ProductId = el.Id });

                    groupNameId.Remove(useGroupName);

                }
            }

            _context.Filters.AddRange(filters);
            _context.SaveChanges();

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
