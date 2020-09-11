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


            #region Child childcategories

            string underchidlUrlSlug = "Bumper Molding";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Молдинг, накладки и расширители бампера",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Front Bumper";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Передние бампера (облицовка)",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Back Bumper";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Задние бамперы (облицовка)",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Bumper amplifiers";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Усилители и абсорберы бампера",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Front grilles";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Решетки передние",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Bumper spoilers";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Спойлеры бампера",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Plugs";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Заглушки",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Bumper fasteners";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Заглушки, Крепеж бампера и компелкующие",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Bumper seals";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Уплотнители бампера",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Door trim";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Накладка двери",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Door outer parts";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Наружные части двери",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }
            
            underchidlUrlSlug = "Door inner parts";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Внутренние части двери",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Sliding door rollers";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Ролики двери сдвижной",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Door handles";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Ручки двери",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Door locks";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Замки двери",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Bring the door locks";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Приводи замков двери",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Glass lifters";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Стеклоподьемники",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Door opening cables";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Тросы открытия дверей",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Door hinges and stops";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Петли двери и ограничители",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Door seals";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Уплотнители дверей",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Door trim";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Обшивки дверей",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Complete doors";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Двери в сборе",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Side mirrors";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Зеркала боковые и их составляющие",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Mirror glasses";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Стекла зеркал",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Mirror glasses";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Подсветка и указатили поворота зеркал наружних",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Mirrors of the blind zones";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Зеркала слепых (мертвых) зон",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Internal rear-view mirrors";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Зеркала внетренние заднего вида",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }
            underchidlUrlSlug = "Internal rear-view mirrors, overhead";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Зеркала внутренние заднего вида, накладные",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Towing mirrors";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Буксировочные зеркала",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Механизмы и компоненты зеркал";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Mirror mechanisms and components",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Front fenders";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Передние крылья",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Rear fenders";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Задние крылья",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Fender liners";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Накладки крыла",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Wing repair parts";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Ремонтные части крыла",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Arch extenders";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Расширители арок",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Wing boosters";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Усилители крыльев",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Wing seal";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Уплотнение для крыльев",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Wing mounts";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Крепления крыла",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

            chidlUrlSlug = "Hoods and their parts";
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

            #region Child childcategories

            underchidlUrlSlug = "Hoods";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Капоты",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Bonnet duct grilles";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Решетки воздуховодов капота",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Bonnet locks";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Замки капота",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Bonnet hinges";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Петли капота",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Front grilles";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Решетки передние",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Hood and trunk opening cables and handles";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Тросики и ручки открывания капота и багажника ",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Door glass";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Дверные стекла",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Side glasses";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Стекла боковые",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Windshields (windshields)";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Стекла ветровые (лобовые)",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Rear windows";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Задние стекла",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Automotive glass kits";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Комплекты автомобильних стекол",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Automotive glass moldings";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Молдинги для автомобильних стекол",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Window frames";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Рамки окон",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }
            underchidlUrlSlug = "Window seals";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Уплотнители для окон",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Handles, locks and hinges for side and rear windows";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Ручки, замки и шарниры боковых и задних стекол",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Sealants and adhesives";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Герметики и клеи",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }
            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Trunk lid moldings and trims (tailgate)";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Молдинги и накладки крышки багажника (задней двери)",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Trunk lids";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Крышки багажника",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }
            
            underchidlUrlSlug = "Rear Panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Задние панели",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Rear panel repair parts";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Ремчасти панелей задних",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Trunk locks";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Замки багажников",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Trunk handles";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Ручки багажников",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Gas springs (bagadnik, hood and others)";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Пружини газовие (багадника, капота и другое)",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Internal elements of the trunk";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Внутринние елементы багажника",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Trunk lid hinges (tailgate)";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Петли крышки багажника (задней двери)",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Rear sides";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Задние борта",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Front panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели передние ",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Plastic Radiator Panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Пластиковые панели радиатора ",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Front panel spare parts";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Ремчасти панелей передних",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Front panel fasteners";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Крепеж передних панелей",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Radiator supports";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Опоры радиатора",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Bumper moldings, linings and extensions";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Молдинги, накладки и расширители бампера",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Wing moldings";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Молдинги крыльев",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Door moldings";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Дверные молдинги",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Bonnet moldings and decals";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Молдинги и наклейки капота",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Deflectors on the window";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Дефлекторы на окне",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Lining and deflectors (fly swatter) hood";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Накладки и дефлекторы (мухобойки) капота",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Air intakes and hood ventilation";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Воздухозаборники и вентиляция капота",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Rear bumper and trunk panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели заднего обвеса бамперов и багажника",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Body kit panels for arches and fenders";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели обвеса арок и крыльев",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Side skirts";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели бокового обвеса",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Roof and hatch panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели обвеса крыши и люков",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Wing ventilation grilles";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Решетки вентеляции крыльев",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Trunk spoilers";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Спойлеры багажника",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Rear window spoilers and blinds";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Спойлеры и жалюзи заднего стекла",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Roof seals and moldings";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Уплотнения и молдинги крыши",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }
            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Threshold";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Пороги",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Repair parts for thresholds";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Ремчасти порогов",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Door sills";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Накладки на пороги ",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Thresholds box";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Коробка порогов",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Frames and side members";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Рамы и лонжероны",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Floor repair parts";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Ремчасти пола",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Trunk panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели багажника",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Front floor panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели пола передние",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Rear floor panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели пола задние",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Central floor panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели пола центральние",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Roof panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Панели крыши",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Roof hatches and components";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Люки крыши и компоненты",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Roof fixings and parts";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Крепления и части крыш",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Roof upholstery and accessories";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Обивка крыша и комплектующия",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Removable roofs and parts thereof";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Съемные крыши и их части",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Seals and components for removable roofs";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Уплотнения и компоненты для съемных крыш",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion

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

            #region Child childcategories

            underchidlUrlSlug = "Side panels and repair parts and side panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Боковые панели и ремчаст и боковых панелей",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Upholstery and side panels";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Обивка и накладки боковых панелей",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion            

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

            #region Child childcategories

            underchidlUrlSlug = "Rear lights (rear dimensions)";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Фонари задние (задние габариты)",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Rear light glass and diffusers (rear dimensions)";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Стекла и рассеиватели задних фонарей (задних габаритов)",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Light reflectors";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Отражатели света",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Trims and frames for rear lights";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Накладки и рамки задних фонарей",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }


            underchidlUrlSlug = "Additional brake lights(third stop)";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Дополнительные стоп-сигналы (третий стоп)",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Rear light protection";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Защита задних фонарей",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Anthers and gaskets for rear lights";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Пыльники и прокладки задних фонарей",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion  

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

            #region Child childcategories

            underchidlUrlSlug = "OEM fog lights";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Штатные противотуманные фары",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Additional fog lights";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Дополнительные противотуманные фары",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Protectors, trims and adapters for fog lamps";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Защита, накладкаи переходники противотумманых фар",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Fog light wiring and components";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Проводка и компоненты противотуманных фар",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Scotch tape and duct tape";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Скотч и изолента",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            underchidlUrlSlug = "Fuses, Holders, Breakers";
            if (context.Categories.SingleOrDefault(c => c.UrlSlug == underchidlUrlSlug) == null)
            {
                var parent = context.Categories.SingleOrDefault(c => c.UrlSlug == chidlUrlSlug);
                context.Categories.Add(new Category
                {
                    Name = "Предохранители, держатели, прерыватели ",
                    ParentId = parent.Id,
                    UrlSlug = underchidlUrlSlug,
                    Image = Path.GetRandomFileName() + ".jpg"
                });
                context.SaveChanges();
            }

            #endregion  

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
