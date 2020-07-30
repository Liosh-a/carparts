using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParts.DataAccess.Entities.Seeder
{
    public class FilterSeeder
    {
        public static void SeedFilters(EFDbContext context)
        {
            #region tblFilterNames - Назви фільтрів
            string urlSlug = "carcase";
            string[] filterNames = { "Кузовные запчасти" };
            //var c = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
            foreach (var type in filterNames)
            {
                if (context.FilterNames.SingleOrDefault(f => f.Name == type) == null)
                {
                    context.FilterNames.Add(
                        new FilterName
                        {
                            Name = type
                        });
                    context.SaveChanges();
                }
            }
            #endregion

        }
    }
}
