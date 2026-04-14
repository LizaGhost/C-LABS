using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yureva1;
using lab1;

namespace lab3
{
    public class Shop
    {
        private List<Item> items = new List<Item>(); //агрегирование (процесс, при котором один объект содержит ссылку на другой объект. Shop содержит ссылку на список объектов Item)

        public List<Item> Items // свойство для доступа к списку товаров
        {
            get { return items; }
            set { items = value; }
        }

        public delegate int Compare(Item a, Item b);

        public delegate void Finished(Shop sender); //делегат для функции обратного вызова

        public event Finished FinishedEvent; //событие

        public void Sort(Compare compare, bool Descending = false) // descending - по убыванию
        {

            Console.WriteLine("Сортировка началась");
            items.Sort((a, b) =>
            {
                int result = compare(a, b);
                return Descending ? -result : result;
            });

            // Симуляция длительного процесса
            Thread.Sleep(500);

            // Триггер на FinishedEvent
            FinishedEvent?.Invoke(this);
        }

        public void SortAsync(Compare compare, bool Descending = false)
        {
            Task.Run(() =>
            {
                Sort(compare, Descending);
            });
        }

        public void ShowItems()
        {
            Console.WriteLine("Brand      Model     Area   Installation MaxNoice  Power  Cost");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------------------------------------------------------");
        }

        // Методы-сравнители для простой сортировки по каждому полю
        public static int CompareByCost(Item a, Item b)
        {
            return a.Cost.CompareTo(b.Cost);
        }
        public static int CompareByPower(Item a, Item b)
        {
            return a.Power.CompareTo(b.Power);
        }

        public static int CompareByMaxNoice(Item a, Item b)
        {
            return a.MaxNoiceLevel.CompareTo(b.MaxNoiceLevel);
        }

        public static int CompareByInstallation(Item a, Item b)
        {
            return a.Installation.CompareTo(b.Installation);
        }

        public static int CompareByArea(Item a, Item b)
        {
            return a.AreaCoverage.CompareTo(b.AreaCoverage);
        }

        public static int CompareByModel(Item a, Item b)
        {
            return a.Model.CompareTo(b.Model);
        }

        public static int CompareByBrand(Item a, Item b)
        {
            return a.Brand.CompareTo(b.Brand);
        }
    }
}
