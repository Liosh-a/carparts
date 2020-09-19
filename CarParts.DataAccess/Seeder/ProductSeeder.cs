using System;
using System.Collections.Generic;
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
        }
    }
}
