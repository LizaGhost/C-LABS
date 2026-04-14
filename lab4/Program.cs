using lab4;
using System.Numerics;
using System;
using System.Collections.Generic;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            IShop shop = new Shop();

            shop.SetItems(new List<IItem>{
                new PhoneItem("Tion", "IQ200", 30, InstallationEnum.OUTDOOR, 46, 17, 17200),
                new PhoneItem("Ballu", "asp-80", 30, InstallationEnum.WALL_MOUNTED, 24, 615, 16711),
                new PhoneItem("Tion", "Lite", 20, InstallationEnum.WALL_MOUNTED, 48, 900, 33700),
                new PhoneItem("Tion", "O2 Base", 30, InstallationEnum.WALL_MOUNTED, 52, 1450, 40650),
                new PhoneItem("Electrolux", "EAP-2050D", 50, InstallationEnum.DESKTOP, 21, 36, 18171),

                new TabletItem("Honor"),
                new TabletItem("Huawei")
            });

            IWarehouse warehouse = new Warehouse(new List<IItem>
            {
                new PhoneItem("Tion", "IQ200", 30, InstallationEnum.OUTDOOR, 46, 17, 17200),
                new PhoneItem("Ballu", "asp-80", 30, InstallationEnum.WALL_MOUNTED, 24, 615, 16711),
                new PhoneItem("Tion", "Lite", 20, InstallationEnum.WALL_MOUNTED, 48, 900, 33700),
                new PhoneItem("Tion", "O2 Base", 30, InstallationEnum.WALL_MOUNTED, 52, 1450, 40650),
                new PhoneItem("Electrolux", "EAP-2050D", 50, InstallationEnum.DESKTOP, 21, 36, 18171),

                new TabletItem("Honor"),
                new TabletItem("Huawei")
            });

            PhoneItem phone1 = new PhoneItem("Harper", "KC-41", 30, InstallationEnum.OUTDOOR, 30, 45, 8879);
            PhoneItem phone2 = new PhoneItem("Ballu", "asp", 30, InstallationEnum.WALL_MOUNTED, 36, 615, 16191);

            if (phone1.CompareTo(phone2) == 0)
            {
                Console.WriteLine(phone1.AreaCoverage + " и " + phone2.AreaCoverage + " равны");
            }
            else if (phone1.CompareTo(phone2) == 1)
            {
                Console.WriteLine(phone1.AreaCoverage + "больше чем " + phone2.AreaCoverage);
            }
            else
            {
                Console.WriteLine(phone2.AreaCoverage + "больше чем " + phone1.AreaCoverage);
            }



            Console.WriteLine("Мощность исходника: " + phone1.Power);
            Console.WriteLine("Мощность копии до: " + phone2.Power);
            phone2 = (PhoneItem)phone1.Clone();
            Console.WriteLine("Мощность копии после: " + phone2.Power);

            Console.WriteLine("Товары на складе:");
            warehouse.ShowItems();
            Console.WriteLine();

            Console.WriteLine("Добавление нового товара на склад: ");
            warehouse.Add(new PhoneItem("Brayer", "4930", 18, InstallationEnum.DESKTOP, 55, 25, 4878));
            warehouse.ShowItems();
            Console.WriteLine();

            Console.WriteLine("Изменение очередности товара: ");
            warehouse.Insert(0, new PhoneItem("Brayer", "4950", 25, InstallationEnum.DESKTOP, 62, 30, 5400));
            warehouse.ShowItems();
            Console.WriteLine();

            warehouse.Clear();
            Console.WriteLine("Товаров нет");
            warehouse.ShowItems();
            Console.WriteLine();

            Console.WriteLine("\nТовары в магазине:");
            shop.ShowItems();

            Console.WriteLine("Сортировка по площади");
            shop.SortProducts(new AreaCoverageSorter());
            shop.ShowItems();

        }
    }
}