using Yureva1;
using lab1;

namespace lab2
{
    public class Shop
    {
        private List<Item> items = new List<Item>(); //агрегирование (процесс, при котором один объект содержит ссылку на другой объект. Shop содержит ссылку на список объектов Item)

        public List<Item> Items // свойство для доступа к списку товаров
        {
            get { return items; }
            set { items = value; }
        }

        public void ShowItems() // метод для отображения всех товаров в списке
        {
            Console.WriteLine("Brand      Model     Area   Installation MaxNoice  Power  Cost");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------------------------------------------------------");
        }

        public abstract class Sorter // абстрактный класс сортировщик (использование только в качестве базового класса для других классов)
        {
            //0: равны, -1: X меньше Y, 1: X болше Y
            public abstract int Compare(Item X, Item Y); // абстрактный метод (метод без реализации) для сравнения двух объектов
            public virtual void Sort(List<Item> list) // виртуальный метод сортировки списка
            {
                list.Sort(Compare);
            }
        }

        // описание классов-сортировщиков, наследуемых от класса Sorter

        public class CostSorter : Sorter
        {
            public override int Compare(Item X, Item Y)
            {
                return X.Cost.CompareTo(Y.Cost);
            }
        }

        public class PowerSorter : Sorter
        {
            public override int Compare(Item X, Item Y)
            {
                return X.Power.CompareTo(Y.Power);
            }
        }

        public class MaxNoiceLevel : Sorter
        {
            public override int Compare(Item X, Item Y)
            {
                return X.MaxNoiceLevel.CompareTo(Y.MaxNoiceLevel);
            }
        }

        public class Installation : Sorter
        {
            public override int Compare(Item X, Item Y)
            {
                return X.Installation.CompareTo(Y.Installation);
            }
        }

        public class AreaCoverage : Sorter
        {
            public override int Compare(Item X, Item Y)
            {
                return X.AreaCoverage.CompareTo(Y.AreaCoverage);
            }
        }

        public class Model : Sorter
        {
            public override int Compare(Item X, Item Y)
            {
                return X.Model.CompareTo(Y.Model);
            }
        }

        public class Brand : Sorter
        {
            public override int Compare(Item X, Item Y)
            {
                return X.Brand.CompareTo(Y.Brand);
            }
        }

        // Сортировка пузырьком
        public class BubbleSorter : Sorter
        {
            public override int Compare(Item x, Item y)
            {
                // Сравнение по цене, можно изменить критерий
                return x.Cost.CompareTo(y.Cost);
            }

            public override void Sort(List<Item> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < list.Count - i - 1; j++)
                    {
                        if (Compare(list[j], list[j + 1]) > 0)
                        {
                            var temp = list[j];
                            list[j] = list[j + 1];
                            list[j + 1] = temp;
                        }
                    }
                }
            }
        }

        // Сортировка вставками
        public class InsertionSorter : Sorter
        {
            public override int Compare(Item x, Item y)
            {
                // Сравнение по цене, можно изменить критерий
                return x.Cost.CompareTo(y.Cost);
            }

            public override void Sort(List<Item> list)
            {
                for (int i = 1; i < list.Count; i++)
                {
                    var key = list[i];
                    int j = i - 1;

                    while (j >= 0 && Compare(list[j], key) > 0)
                    {
                        list[j + 1] = list[j];
                        j--;
                    }
                    list[j + 1] = key;
                }
            }
        }

        // Сортировка перемешиванием
        public class CocktailSorter : Sorter
        {
            public override int Compare(Item x, Item y)
            {
                // Сравнение по цене, можно изменить критерий
                return x.Cost.CompareTo(y.Cost);
            }

            public override void Sort(List<Item> list)
            {
                bool swapped = true;
                int start = 0;
                int end = list.Count;

                while (swapped)
                {
                    swapped = false;

                    for (int i = start; i < end - 1; ++i)
                    {
                        if (Compare(list[i], list[i + 1]) > 0)
                        {
                            var temp = list[i];
                            list[i] = list[i + 1];
                            list[i + 1] = temp;
                            swapped = true;
                        }
                    }

                    if (!swapped)
                        break;

                    swapped = false;
                    end--;

                    for (int i = end - 1; i >= start; i--)
                    {
                        if (Compare(list[i], list[i + 1]) > 0)
                        {
                            var temp = list[i];
                            list[i] = list[i + 1];
                            list[i + 1] = temp;
                            swapped = true;
                        }
                    }
                    start++;
                }
            }

        }

    }
}
