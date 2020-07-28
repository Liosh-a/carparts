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

            chidlUrlSlug = "Mirrors";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Зеркала",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Wings";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Крылья и их части",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Hoods";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Капоты и их части",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Autoglass";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Автостекла",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Trunk";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Багажник, задние панали и их детали",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Frontpanels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Передние панели",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Bodypanels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели, накладки и молдинги кузова",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Thresholds";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Пороги и накладки",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Lowervehicle";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Нижняя часть кузова и рама атомобиля",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Roofs";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Крыши",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Sidecomponents";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Боковые панели и состовляющие",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Rearlights";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Задние фонари",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Foglights";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Противотуманные фонари",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Trunkdoors";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Крышки багажника",
                    ParentId = parent.Id,
                    UrlSlug = chidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            chidlUrlSlug = "Gassprings";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == urlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Пружины газовые (багажника, капота  и другие)",
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
