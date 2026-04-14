using lab1;
using lab3;
using System.Threading;
using Yureva1;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop(); //создаётся экземпляр класса Shop, заполняется список товаров

            // Подписываемся на событие завершения сортировки
            shop.FinishedEvent += Shop_SortingFinished;

            shop.Items.Add(new Item("Tion", "IQ200", 30, InstallationEnum.OUTDOOR, 46, 17, 17200));
            shop.Items.Add(new Item("Philips", "AC2729/10", 85, InstallationEnum.OUTDOOR, 40, 35, 30890));
            shop.Items.Add(new Item("Ballu", "AP-130", 40, InstallationEnum.OUTDOOR, 55, 48, 11733));
            shop.Items.Add(new Item("VITEK", "VT-8558", 30, InstallationEnum.OUTDOOR, 55, 25, 6906));
            shop.Items.Add(new Item("Dyson", "TP00-1kz", 40, InstallationEnum.DESKTOP, 65, 56, 30265));
            shop.Items.Add(new Item("Philips", "AC1715/10", 78, InstallationEnum.DESKTOP, 50, 27, 22206));
            shop.Items.Add(new Item("Brayer", "4930", 18, InstallationEnum.DESKTOP, 55, 25, 4878));
            shop.Items.Add(new Item("Harper", "KC-41", 30, InstallationEnum.OUTDOOR, 30, 45, 8879));
            shop.Items.Add(new Item("Atmeex", "A7 Flow", 50, InstallationEnum.WALL_MOUNTED, 43, 1585, 65258));
            shop.Items.Add(new Item("Ballu", "asp", 30, InstallationEnum.WALL_MOUNTED, 36, 615, 16191));
            shop.Items.Add(new Item("Ballu", "asp-80", 30, InstallationEnum.WALL_MOUNTED, 24, 615, 16711));
            shop.Items.Add(new Item("Tion", "Lite", 20, InstallationEnum.WALL_MOUNTED, 48, 900, 33700));
            shop.Items.Add(new Item("Tion", "O2 Base", 30, InstallationEnum.WALL_MOUNTED, 52, 1450, 40650));
            shop.Items.Add(new Item("Electrolux", "EAP-2050D", 50, InstallationEnum.DESKTOP, 21, 36, 18171));
            shop.Items.Add(new Item("Harper", "KC-31", 30, InstallationEnum.OUTDOOR, 30, 35, 7440));

            // вывод оригинального списка
            Console.WriteLine("Обычный список:");
            shop.ShowItems();

            Console.WriteLine("Обычная сортировка по цене:"); // обычный метод
            shop.Sort(Shop.CompareByCost);
            //shop.ShowItems();

            Console.WriteLine("\nОбычная сортировка по мощности с указателем"); // обычный метод плюс указатель на него
            Func<Item, Item, int> compareByPower = Shop.CompareByPower;
            shop.Sort(compareByPower.Invoke);
            //shop.ShowItems();

            // анонимный метод
            Console.WriteLine("\nАнонимная сортировка по максимальному значению шума:");
            shop.Sort(delegate (Item a, Item b) { return a.MaxNoiceLevel - b.MaxNoiceLevel; });
            //shop.ShowItems();

            // лямбда-выражение
            Console.WriteLine("\nЛямбда сортировка по макс. значению шума (Descending):");
            shop.Sort((a, b) => a.MaxNoiceLevel - b.MaxNoiceLevel, true);
            //shop.ShowItems();

            // Вызываем асинхронный метод сортировки
            Console.WriteLine("\nАсинхр. сортировка по площади:");
            shop.SortAsync(Shop.CompareByArea);
            for (int i = 0; i < 10; i++) // работа, выполняемая параллельно с сортировкой
            {
                Console.WriteLine($"Работаю... {i + 1}");
                Thread.Sleep(200); // Задержка для демонстрации параллельной работы
            }

        }
        private static void Shop_SortingFinished(Shop sender)
        {
            // Выводим отсортированную таблицу после завершения сортировки
            Console.WriteLine("Сортировка завершена:");
            sender.ShowItems();
        }
    }
}