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
        public static void SeedFilters(EFDbContext context)
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
                                            "Хромовый", "Черно-Серый", "Чорный"
                            
                            },
                            new string [] { "Верхняя часть", "Внешняя часть", "Внутренняя часть", //Bamper
                                            "Нижняя часть", "Средняя часть"},
                            new string [] { "Слева", "Спереди", "Спарва" }, //Bumper Krulla
                            new string [] { "Аналог", "Оригінал"}, //type zapchasti (bumper)
                            new string [] { "Посередине", "Сверху", "Сзади","Сзади, слева", "Сзади, справа", "Слева", "Спереди слева", "Справа", }, //Bumper Nakladki(molding)(storona ustanovki)
                            new string [] { "Посередине", "Сверху", "Сзади", "Снизу", }, //Bumper Nakladki(molding,peredniy,)(mestorospolojenia)
                            new string [] { "Верхняя часть", "Внешняя часть", "Внутренняя часть", "Нижняя часть","Средняя часть" }, //Bumper Nakladki(molding)(sekcia/chast)
                            new string [] { "Верх под покраску", "Гладкая", "Глянцевая", "Грунтованная", "Лакированная", "Матовая", "Низ под покраску", "Под покраску", "Серебристый", "Текстурная", "Хромированная", "Хромовая", "Частично грунтованная", "полимеризированный (primer)","" }, //Bumper(peredni nakladki)(poverhnosti)
                            new string [] { "Без воздушного шлица", "Без отверстий для декоративной накладки", "Без отверстия / отверстий для расширителя", "Без отверстия / отверстий для сопла", "Без отверстия / отверстий для эмблемы", "Без отверстия / отверстий под парктроник", "Без отверстия / отверстий под противотуманные фары", "Без отверстия / отверстий под систему ассистента парковки", "Без отверстия для указателя поворота", "Без прорези / прорезей для заборника воздуха", "С воздушными шлицами", "С отверстием / отверстиями для радиатора двигателя", "С отверстием / отверстиями для расширителя", "С отверстием / отверстиями для сопла", "С отверстием / отверстиями для эмблемы", "С отверстием / отверстиями под противотуманные фары", "С отверстием / отверстиями под систему ассистента парковки", "С отверстием под указатель поворота", "С отверстиями / креплениями для узкой декоративной накладки", "С отверстиями / креплениями для широкой декоративной накладки", "С прорезью / прорезями для заборника воздуха", "С прорезью / прорезями для трубы выхлопного газа", "без отверстий для парктроника", "без отверстия / отверстий для буксирного крюка", "с нарезкой / выемкой во внутренней части", "с отверстием / отверстиями для буксирного крюка", "с отверстием / отверстиями для дополнительного радиатора", "с отверстием / отверстиями для защиты от ударов камней", "с отверстием / отверстиями для освещения номерного знака", "с отверстием / отверстиями для стеклоочистителя", "с отверстиями для декоративной накладки", "с отверстиями для парктроника", }, //Bumper Nakladki(molding)(prorezay)
                            new string [] { "2 шт", "Без декоративной полосы", "Без держателя лампы", "Без заглушки", "Без рамки", "Без рамы", "Деталь в сборе", "Из 2 частей", "Из 3 частей", "Из 4 частей", "Комплект", "С 2 фарами дальнего света", "С аксессуарами", "С внутренней частью", "С дополнительными материалами", "С кронштейном", "С полосками под фары", "С рамкой", "Цельный", "без встроенной решетки", "без декоративной накладки", "без крепления для номерного знака", "для открывающихся противотуманных фонарей", "с воздушным шлицом", "с декоративной накладкой", "с крепежом номерного знака", "с кронштейном амортизатора" }, //Bumper (setka)(komplektacia)
                            new string [] { "Для крепления номерного знака", "Накладка вертикальная", "Накладка горизонтальная", "С хромированной накладкой / накладками", "Угольник", "Узкая", "Узкий бампер", "" }, //Bumper (setka)(osebonesti ispolnenia)
                            new string [] { "В бампере", "Верхняя", "Внешняя", "Внутренняя", "Капот двигателя", "Нижняя" }, //Bumper (setka)(mestorospolojenia)
                            new string [] { "Верхняя часть ", "Внутренняя часть", "Нижняя часть", "Передний мост"}, //Bumper (molding)(sekcia)
                            new string [] { "Задняя дверь автомобиля", "Задняя сторона автомобиля", "Крыша автомобиля", "Перед автомобиля", "Посередине", "С обеих сторон", "Сзади", "Сзади, слева", "Сзади, справа", "Слева", "Снизу", "Спереди", "Спереди слева", "Спереди справа", "Справа" }, //Bumper (spoyler)(storona ustanovki)
                            new string [] { "Посередине", "С обеих сторон", "Слева", "Спереди, сзади", "Справа" }, //bagajnik (armotizatoru)(storona ustanovki)
                            new string [] { "Посередине", "Слева", "Спереди", "Справа"},
                            new string [] { "Внешняя", "С обеих сторон", "Сзади", "Сзади, слева", "Сзади, справа", "Слева", "Слева снизу", "Спереди", "Спереди слева", "Справа", "за мостом", "перед мостом" }, //kuzov (bokovie paneli)(storona ustanovki)
                            new string [] { "Внешняя", "Внутренняя", "Двусторонняя", "Крыло", "Наружное зеркало", "Посередине", "С обеих сторон", "Сверху", "Сзади", "Сзади, слева", "Сзади, справа", "Слева", "Слева снизу", "Слева, справа", "Снизу", "Со стороны водителя", "Со стороны переднего пассажира", "Со стороны переднего пассажира, со стороны водителя", "Спереди", "Спереди слева", "Спереди справа", "Справа", "Справа сверху", "Справа снизу", "боковая навеска", "кабина" }, //zerkala (bokovie zerkala)(storona ustanovki) "С обеих сторон, справа"
                            new string [] { "Механическая", "Ручная", "Электрическая", }, //zerkala (bokovie)(regulerovka)
                            new string [] { "Асферическое", "Плоское", "Слепой зоны", "Сферическое"}, //zerkala (bokovie)(typ stekla)
                            new string [] { "Обогреваемое" }, //zerkalo (vkladishi)(obogrev)
                            new string [] { "AV-выход", "G-сенсор", "GPS", "Встроенный экран", "Датчик движения" }, //zerkalo (zadnego vida)(funczii)
                            new string [] { "1920x1080 (Full HD)", "2304x1296 (Super HD)", }, //zerkalo (zadnego vida)(razreshenia)
                            new string [] { "140" }, //zerkalo (zadnego vida)(ugol)
                            new string [] { "Крыша автомобиля", "Навес", "Посередине", "С обеих сторон", "Сверху", "Сзади", "Сзади, слева", "Сзади, справа", "Слева", "Справа", "боковая навеска", "кузов" }, //fonari zad (fonari zad hoda)(storona ustanovki)
                            new string [] { "Крепление", "Фонарь"}, //fonari zad (fonari zad vida)(typ izdelia)
                            new string [] { "В бампере", "Верхняя часть", "Внешняя часть", "Внутренняя часть", "Задний мост", "Нижняя часть", "Передний мост"}, //fonari zad (fonari zad vida)(razpolajenia)
                            new string [] { "8SA", "8SB", "8SG", "8SK", "8SL", "8TC", "8TD", "8TF", "A8B", "A8C", "A8F", "A8G", "A8H", "A8S", "A8U", "K8B", "K8D", "SBR"}, //fonari zad (fonari zad vida)(kod komplektacii)
                            new string [] { "Багажник", "Внешняя", "Внутренняя", "Задняя дверь автомобиля", "Задняя сторона автомобиля", "Крыша автомобиля", "Посередине", "С обеих сторон", "Сзади", "Сзади, слева", "Сзади, справа", "Слева", "Справа", "средняя и задняя часть" }, //fonari zad (dop stop signal-3)(storona ustanovki)
                            new string [] { "Крыло" }, //krilya (pered krilia)(type)
                            new string [] { "Внутренняя", "Задний мост", "Задняя ось двусторонне", "Сверху", "Сзади", "Сзади справа, сзади слева", "Сзади, слева", "Сзади, справа", "Слева", "Спереди слева", "Спереди слева, справа", "Спереди справа", "Справа"}, //krilya (zad krilya)(storona ustanovki)
                            new string [] { "2", "2/4", "3", "3/5","4","4/5","5" }, //krilya (zad krilya)(chislo dverey)
                            new string [] { "Оцинкованный", "Полимер", "Сталь" }, //kriya (rem vstavka zad kril)(material izgotovlenia)
                            new string [] { "Крыло", "Сзади", "Сзади, слева", "Сзади, справа", "Слева", "Спереди", "Спереди слева", "Спереди справа", "Спереди, сзади", "Справа", "наружный со стороны колеса" }, //krila (rasheritel arok)(storona ustanovki)
                            new string [] { "Листовая сталь", "Металл", "Полимер", "Сталь" }, //krilya (porogi)(material izotovlenia)
                            new string [] { "Грунтованный", "Оцинкованный", "оцинкованная" }, //krilya (porogi)(poverhnost)
                            new string [] { "Внешняя", "Внутренняя", "Задний мост", "Перед автомобиля", "Передний мост справа", "Посередине", "С обеих сторон", "Сзади", "Сзади, слева", "Сзади, справа", "Слева", "Слева, справа", "Снизу", "Спереди", "Спереди слева", "Спереди справа", "Справа", "боковой монтаж", "задний ряд цилиндров", "от датчика потока воздуха к заслонке доп. подачи воздуха", "установка задней части" }, //protivotumanki (protivotumanki)(storona ustanovki)
                            //typ lampi protivotumanki spitat
                            new string [] { "DE", "FF", "Галоген", "Технология ламп накаливания", "ксеноновый", "светодиодный", "симметричный" }, //protivtuman (protivtuman)(type osvetitela)
                            new string [] { "для лево-/правосторонним управлением", "для левостороннего расположения руля", "для правостороннего расположения руля" }, //protivatuman (protivatuman)(type rula)
                            new string [] { "Белый", "Желтый", "Зеленый", "Красный", "Оранжевый", "Прозрачный", "Серебристый", "Серый", "Синий", "Темно-серый", "Темный", "Хромовый", "Черный", "жёлтый-прозрачный", "оттененный"}, //prot tuman (prot tuma)(color)
                            new string [] { "белый", "дымковый", "желтый", "красный", "оранжевый", "прозрачный", "серебряный", "черный" }, //prot tuman (prot tuman)(color skla)
                            new string [] { "H1", "H1/H3", "H1/H7", "H10", "H11", "H12", "H13", "H15", "H16", "H2", "H21W", "H27W/1", "H27W/2", "H27W/2 / H27W/2", "H3", "H3/H3", "H4", "H7", "H7 / H1", "H8", "H8/H8", "H8B", "HB3 (9005)", "HB4 (9006)", "HB4A", "LED", "P13W", "P21/5W", "P21W", "P27/7W", "PSX24W", "PSX26W", "PSY24W", "PY21W", "R5W", "W16W", "W21W", "W5W", "WY21W", "WY5W", "Н1/Н1", "Н7/Н7", "Светодиодный" }, //prot tuman (prot timan)(type skla)
                            new string [] { "Серый", "Черный", "алюминиевый", "антрацит", "дымковый", "неокрашенный", "светлосиний", "серебряный", "серобазальтовый", "темно-серый", "темный", "хром", "хром/черный", "цвета слоновой кости" }, //prot tuman (prot tuman)(cvet koghuha)
                            new string [] { "D-форма", "Дугообразный", "Круглая", "О-форма", "Овал", "Плоский", "Прямоугольный", "Треугольная", "Угловой" }, //prot tuman (prot tuman)(forma)
                            new string [] { "AL", "BOSCH", "Bosch-type", "Carello", "Cibié", "Depo", "HELLA", "Hella-type", "Koito-type", "LED", "SAMLIP", "SCANIA \"R\"", "Seogu", "T.Y.C", "TYC", "Typ Hella", "VALEO", "Visteon", "ZKW", "ryflowane szk³o" }, //prot tuman (prot tuman)(ogranichenia proizvoditela)
                            new string [] { "Рассеиватель призматический", "выпуклая шайба разброса", "закалённая шайба разброса", "прозрачная рассеивающая линза", "рассеиватель с рисунком", "ровная шайба разброса", "с акустическим подавлением", "широкоугольная шайба разброса" }, //prot tuman ()(konstrukcia rassevatela)
                            new string [] { "1998 - 2001", "2000 - 2004", "2001 - 2005", "2005 -", "Antinieblas", "H11", "H27W/1", "H3", "HB4", "KOITO", "P21W", "VALE", "W21W" }, //prot tuman ()(specifikacia)
                            //prot tumanki spitat
                            new string [] { "Изолента", "Скотч"}, //skotch izolenta (typ)
                            new string [] { "Белый", "Желто-зеленый", "Желтый", "Зеленый", "Коричневый", "Красный", "Прозрачный", "Серый", "Синий", "Черный" }, //skotch izolenta (zvet)
                            new string [] { "Алюминиевый", "Антигравийный", "Армированный", "Двусторонний", "Лента-застежка", "Малярный", "Односторонний", "Упаковочный"}, //skotch izolenta (typ lenti)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                            //new string [] { "", "", "", "","" }, //Bumper (molding)(sekcia)
                       
            
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

            #region tblFilterNameCategory - Групування груп фільтрів по категоріям

            foreach(var el in context.FilterNames)
            {

            }

            #endregion
        }
    }
}
