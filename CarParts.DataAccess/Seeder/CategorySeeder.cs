using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CarParts.DataAccess.Entities.Seeder
{
    public class CategorySeeder
    {
        public static void SeedCategories(EFDbContext context)
        {
            string urlSlug = "carcase";
            #region Parent categories
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug) == null)
            {
                context.Categories.Add(new Category
                {
                    Name = "Кузов",
                    ParentId = null,
                    UrlSlug = urlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

            #region Child categories

            string chidlUrlSlug = "Bumper";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Бампер",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Doors";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Двери",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion
        }
    }
}
