using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParts.DataAccess.Entities.Seeder
{
    public class FilterSeeder
    {
        private static void SeedFilters(EFDbContext context, IHostingEnvironment _env,
           IConfiguration _config)
        {
            List<int> productid = new List<int>();
            foreach (var el in context.Products)
            {
                productid.Add(el.Id);
            }

            #region tblFilterNames - Назви фільтрів
            string[] filterNames = { "Сторона", "Цвет", "Расположение", "Сторона Установки"  };
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
                            new string [] { "зад. лев.", "зад. пра.", "пер. лев.", "пер. пра."},//Dveri
                            new string [] { "Антрацит", "Белый", "Коричневый", "Красный", //Vse
                                            "Светлый", "Серый", "Синий", "Темно-серый", 
                                            "Темно-синий", "Темный", "Хромово-Черный", 
                                            "Хромовый", "Черно-Серый", "Чорный"},
                            new string [] { "Верхняя часть", "Внешняя часть", "Внутренняя часть", //Bamper
                                            "Нижняя часть", "Средняя часть"},
                            new string [] {  }
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
        }
    }
}
