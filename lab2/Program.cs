using lab1;
using lab2;
using Yureva1;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop(); //создаётся экземпляр класса Shop, заполняется список товаров

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

            //Выводы товаров + сортировки

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Все товары");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();

            Shop.CostSorter costSorter= new Shop.CostSorter();
            costSorter.Sort(shop.Items);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Сортировка по цене:");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();

            Shop.PowerSorter powerSorter = new Shop.PowerSorter();
            powerSorter.Sort(shop.Items);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Сортировка по мощности:");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();

            Shop.MaxNoiceLevel maxNoiceLevel = new Shop.MaxNoiceLevel();
            maxNoiceLevel.Sort(shop.Items);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Сортировка по максимальному значению шума:");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();

            Shop.Installation installation = new Shop.Installation();
            installation.Sort(shop.Items);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Сортировка по типу установки:");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();

            Shop.AreaCoverage areaCoverage = new Shop.AreaCoverage();
            areaCoverage.Sort(shop.Items);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Сортировка по охвату площади:");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();

            Shop.Model model = new Shop.Model();
            model.Sort(shop.Items);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Сортировка по модели:");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();

            Shop.Brand brand = new Shop.Brand();
            brand.Sort(shop.Items);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Сортировка по бренду:");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();

            // Сортировка и вывод товаров с использованием алгоритмов сортировок

            Shop.BubbleSorter bubbleSorter = new Shop.BubbleSorter();
            bubbleSorter.Sort(shop.Items);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Сортировка пузырьком по цене:");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();

            Shop.InsertionSorter insertionSorter = new Shop.InsertionSorter();
            insertionSorter.Sort(shop.Items);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Сортировка вставками по цене:");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();

            Shop.CocktailSorter cocktailSorter = new Shop.CocktailSorter();
            cocktailSorter.Sort(shop.Items);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Сортировка перемешиванием по цене:");
            Console.WriteLine("---------------------------------------------------------");
            shop.ShowItems();
        }
    }
}
