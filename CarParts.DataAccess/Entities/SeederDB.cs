using Bogus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarParts.DataAccess.Entities
{
    public class SeederDB
    {
        //public static void SeedUsers(UserManager<DbUser> userManager,
        //   RoleManager<DbRole> roleManager)
        //{
        //    string roleName = "User";
        //    var role = roleManager.FindByNameAsync(roleName).Result;
        //    if (role == null)
        //    {
        //        role = new DbRole
        //        {
        //            Name = roleName
        //        };
        //        var addRoleResult = roleManager.CreateAsync(role).Result;
        //    }
        //    var userEmail = "bomba@gmail.com";
        //    var user = userManager.FindByEmailAsync(userEmail).Result;
        //    if (user == null)
        //    {
        //        user = new DbUser
        //        {
        //            Email = userEmail,
        //            UserName = userEmail
        //        };
        //        var result = userManager.CreateAsync(user, "Qwerty1-").Result;
        //        if (result.Succeeded)
        //        {
        //            result = userManager.AddToRoleAsync(user, roleName).Result;
        //        }

        //    }
        //}
        //public static void SeedData(IServiceProvider services, IHostingEnvironment env,
        //    IConfiguration config)
        //{
        //    using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        //    {
        //        var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
        //        var managerUser = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
        //        var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();

        //        SeedUsers(managerUser, managerRole);


        //    }
        //}
        private static void SeedFilters(EFDbContext context, IHostingEnvironment _env,
           IConfiguration _config)
        {
            List<int> carid = new List<int>();
            foreach (var el in context.Products)
            {
                carid.Add(el.Id);
            }
            //            #region tblFilterNames - Назви фільтрів
            //            string[] filterNames = { "Тип кузова", "Топливо", "КПП", "Тип привода" };
            //            foreach (var type in filterNames)
            //            {
            //                if (context.FilterNames.SingleOrDefault(f => f.Name == type) == null)
            //                {
            //                    context.FilterNames.Add(
            //                        new FilterName
            //                        {
            //                            Name = type
            //                        });
            //                    context.SaveChanges();
            //                }
            //            }
            //            #endregion


            //            #region tblFilterValues - Значення фільтрів
            //            List<string[]> filterValues = new List<string[]> {
            //                new string [] { "Универсал", "Седан", "Хэтчбек",
            //                    "Внедорожник/Кросовер", "Купе", "Кабриолет",
            //                    "Минивэн", "Пикап", "Лимузин", "Легковой фургон (до 1,5т)",
            //                    "Лифтбек", "Родстер", "Другой" },

            //                new string [] { "Бензин", "Дизель", "Газ", "Газ/Бензин",
            //                    "Гибрид", "Электро", "Другое", "Газ метан", "Газ пропан-бутан"},

            //                 new string [] { "Ручная/Механика", "Автомат", "Типтроник", "Адаптивная", "Вариатор"},

            //                new string [] { "Полный", "Передний", "Задний"}

            //            };

            //            foreach (var items in filterValues)
            //            {
            //                foreach (var value in items)
            //                {
            //                    if (context.FilterValues
            //                        .SingleOrDefault(f => f.Name == value) == null)
            //                    {
            //                        context.FilterValues.Add(
            //                            new FilterValue
            //                            {
            //                                Name = value
            //                            });
            //                        context.SaveChanges();
            //                    }
            //                }
            //            }
            //            #endregion

            //            #region tblFilterNameGroups - Групування по групах фільтрів

            //            for (int i = 0; i < filterNames.Length; i++)
            //            {
            //                foreach (var value in filterValues[i])
            //                {
            //                    var nId = context.FilterNames
            //                        .SingleOrDefault(f => f.Name == filterNames[i]).Id;
            //                    var vId = context.FilterValues
            //                        .SingleOrDefault(f => f.Name == value).Id;
            //                    if (context.FilterNameGroups
            //                        .SingleOrDefault(f => f.FilterValueId == vId &&
            //                        f.FilterNameId == nId) == null)
            //                    {
            //                        context.FilterNameGroups.Add(
            //                            new FilterNameGroup
            //                            {
            //                                FilterNameId = nId,
            //                                FilterValueId = vId
            //                            });
            //                        context.SaveChanges();
            //                    }
            //                }
            //            }
            //            #endregion

            //            #region tblCars - Автомобілі
            var faker = new Faker();
            //            List<string> cars = new List<string>();
            //            for (int i = 0; i < 10000; i++)
            //            {
            //                cars.Add(Path.GetRandomFileName());
            //            }

            //            foreach (var item in cars)
            //            {

            //                if (context.Cars.SingleOrDefault(f => f.UniqueName == item) == null)
            //                {

            //                    context.Cars.Add(
            //                        new Car
            //                        {
            //                            UniqueName = item,
            //                            Price = faker.Random.Int(1000, 100000),
            //                            Name = faker.Vehicle.Manufacturer() + " " + faker.Vehicle.Model()
            //                        }); ;

            //                    context.SaveChanges();
            //                }
            //            }
            //#endregion

            #region tblFilterNames - Назви фільтрів
            string[] filterNames = { "Тип кузова", "Топливо", "КПП", "Тип привода", "Безопасность", "Мультимедия", "Комфорт", "Другое" };
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


            #region tblFilterValues - Значення фільтрів
            List<string[]> filterValues = new List<string[]> {
                            new string [] { "Универсал", "Седан", "Хэтчбек",
                                "Внедорожник/Кросовер", "Купе", "Кабриолет",
                                "Минивэн", "Пикап", "Лимузин", "Легковой фургон (до 1,5т)",
                                "Лифтбек", "Родстер", "Другой" },

                            new string [] { "Бензин", "Дизель", "Газ", "Газ/Бензин",
                                "Гибрид", "Электро", "Другое", "Газ метан", "Газ пропан-бутан"},

                             new string [] { "Ручная/Механика", "Автомат", "Типтроник", "Адаптивная", "Вариатор"},

                            new string [] { "Полный", "Передний", "Задний"},

                            new string [] { "Центральный замок", "ABS", "Подушка безопасности (Airbag)", "Сигнализация",
                                "Серворуль", "Иммобилайзер", "Галогенные фары", "ESP", "ABD", "Замок на КПП", "Пневмоподвеска"},

                            new string [] { "MP3", "CD", "Магнитола", "Акустика", "DVD", "Система навигации GPS", "Сабвуфер"},

                            new string [] { "Усилитель руля", "Электростеклоподъёмник", "Бортовой компьютер", "Елктропакет",
                                "Кондиционер", "Подогрев стёкол", "Климат контроль", "Парктроник", "Датчик света", "Кожаный салон",
                                "Мультируль", "Подогрев сидений", "Круиз контроль", "Сенсор дождя", "Люк", "Омыватель фар", "Запуск кнопкой",
                                "Память сидений", "Подогрев руля"},

                            new string [] { "Тонирование стёкол", "Фаркоп", "Газовая установка (ГБО)", "Дерево", "Удлиненная база", "Правый руль"}

                        };


            foreach (var items in filterValues)
            {
                foreach (var value in items)
                {
                    if (context.FilterValues
                        .SingleOrDefault(f => f.Name == value) == null)
                    {
                        context.FilterValues.Add(
                            new FilterValue
                            {
                                Name = value
                            });
                        context.SaveChanges();
                    }
                }
            }
            #endregion

            #region tblFilterNameGroups - Групування по групах фільтрів

            for (int i = 0; i < filterNames.Length; i++)
            {
                foreach (var value in filterValues[i])
                {
                    var nId = context.FilterNames
                        .SingleOrDefault(f => f.Name == filterNames[i]).Id;
                    var vId = context.FilterValues
                        .SingleOrDefault(f => f.Name == value).Id;
                    if (context.FilterNameGroups
                        .SingleOrDefault(f => f.FilterValueId == vId &&
                        f.FilterNameId == nId) == null)
                    {
                        context.FilterNameGroups.Add(
                            new FilterNameGroup
                            {
                                FilterNameId = nId,
                                FilterValueId = vId
                            });
                        context.SaveChanges();
                    }
                }
            }
            #endregion

            //#region tblFilters -Фільтри
            //List<Filter> filters = new List<Filter>();
            //foreach (var el in carid)
            //{

            //    filters.Add(new Filter { FilterNameId = 1, FilterValueId = faker.Random.Int(1, 13), CarId = el });
            //    filters.Add(new Filter { FilterNameId = 2, FilterValueId = faker.Random.Int(14, 22), CarId = el });
            //    filters.Add(new Filter { FilterNameId = 3, FilterValueId = faker.Random.Int(23, 27), CarId = el });
            //    filters.Add(new Filter { FilterNameId = 4, FilterValueId = faker.Random.Int(28, 30), CarId = el });

            //}



            //foreach (var item in filters)
            //{
            //    var f = context.Filters.SingleOrDefault(p => p == item);
            //    if (f == null)
            //    {
            //        context.Filters.Add(new Filter { FilterNameId = item.FilterNameId, FilterValueId = item.FilterValueId, CarId = item.CarId });
            //        context.SaveChanges();
            //    }
            //}

            //#endregion



        }
        public static void SeedData(IServiceProvider services, IHostingEnvironment env,
            IConfiguration config)
        {

            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //    var managerUser = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                //    var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();

                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                SeedFilters(context, env, config);
                context.ChangeTracker.AutoDetectChangesEnabled = true;


                //    SeedUsers(managerUser, managerRole);
            }
        }
        //public static void SeedUsers(UserManager<DbUser> userManager, RoleManager<DbRole> roleManager)
        //{
        //    string roleName = "Admin";
        //    var role = roleManager.FindByNameAsync(roleName).Result;
        //    if (role == null)
        //    {
        //        role = new DbRole
        //        {
        //            Name = roleName
        //        };
        //        var addRoleResult = roleManager.CreateAsync(role).Result;
        //    }

        //    var userEmail = "admin@gmail.com";
        //    var user = userManager.FindByEmailAsync(userEmail).Result;
        //    if (user == null)
        //    {
        //        user = new DbUser
        //        {
        //            Email = userEmail,
        //            UserName = "Yura"
        //        };
        //        var result = userManager.CreateAsync(user, "Qwerty1-").Result;
        //        if (result.Succeeded)
        //        {
        //            result = userManager.AddToRoleAsync(user, "Admin").Result;
        //        }
        //    }

        //}
    }
}