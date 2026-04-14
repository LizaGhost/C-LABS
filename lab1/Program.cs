using System;
using System.Collections.Generic;
using lab1;
using Yureva1;

class Program
{
    static void Main(string[] args)
    {
        List<Item> items = new List<Item>();

        items.Add(new Item("Tion", "IQ200", 30, InstallationEnum.OUTDOOR, 46, 17, 17200));
        items.Add(new Item("Philips", "AC2729/10", 85, InstallationEnum.OUTDOOR,40,35,30890));
        items.Add(new Item("Ballu", "AP-130", 40, InstallationEnum.OUTDOOR,55,48,11733));
        items.Add(new Item("VITEK", "VT-8558",30, InstallationEnum.OUTDOOR,55,25,6906));
        items.Add(new Item("Dyson", "TP00-1kz",40, InstallationEnum.DESKTOP,65,56,30265));
        items.Add(new Item("Philips", "AC1715/10", 78, InstallationEnum.DESKTOP,50,27,22206));
        items.Add(new Item("Brayer", "4930", 18, InstallationEnum.DESKTOP, 55, 25, 4878));
        items.Add(new Item("Harper", "KC-41", 30, InstallationEnum.OUTDOOR, 30, 45, 8879));
        items.Add(new Item("Atmeex", "A7 Flow", 50, InstallationEnum.WALL_MOUNTED, 43, 1585, 65258));
        items.Add(new Item("Ballu", "asp", 30, InstallationEnum.WALL_MOUNTED, 36, 615, 16191));
        items.Add(new Item("Ballu", "asp-80", 30, InstallationEnum.WALL_MOUNTED, 24, 615, 16711));
        items.Add(new Item("Tion", "Lite", 20, InstallationEnum.WALL_MOUNTED, 48, 900, 33700));
        items.Add(new Item("Tion", "O2 Base", 30, InstallationEnum.WALL_MOUNTED, 52, 1450, 40650));
        items.Add(new Item("Electrolux", "EAP-2050D", 50, InstallationEnum.DESKTOP, 21, 36, 18171));
        items.Add(new Item("Harper", "KC-31", 30, InstallationEnum.OUTDOOR, 30, 35, 7440));

        Console.WriteLine("Brand      Model     Area   Installation MaxNoice  Power  Cost");
        foreach (var item in items)
        {
            Console.WriteLine(item.ToString());
        }

        Console.ReadKey();
    }
}