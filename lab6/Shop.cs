using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public interface IShop
    {
        public void SetItems(List<IItem> items);

        public void SortProducts(Sorter customSorter);

        public void ShowItems();
        public List<IItem> GetItems();

    }
    public class Shop: IShop, IEnumerable<IItem>
    {
        private List<IItem> _items;
        private Sorter _sorter;

        public void SetItems(List<IItem> items)
        {
            _items = items;
        }

        public List<IItem> GetItems()
        {
            return _items;
        }
        public void SortProducts(Sorter customSorter)
        {
            _sorter = customSorter;
            _sorter.Sort(_items);
        }

        public void AddItem(IItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            _items.Remove(item);
        }

        public void ShowItems() // метод для отображения всех товаров в списке
        {
            Console.WriteLine("Vendor      Model     Area   Installation MaxNoice  Power  Price");
            foreach (var item in _items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------------------------------------------------------");
        }

        public IEnumerator<IItem> GetEnumerator() //Метод GetEnumerator: Возвращает перечислитель, который перебирает элементы коллекции items
        {
            return _items.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
    public abstract class Sorter
    {
        //0: равны, -1: X меньше Y, 1: X болше Y
        public abstract int Compare(IItem X, IItem Y);
        public virtual void Sort(List<IItem> list)
        {
            list.Sort(Compare);
        }
    }

    // описание классов-сортировщиков, наследуемых от класса Sorter

    public class InstallationSorter : Sorter
    {
        public override int Compare(IItem X, IItem Y)
        {
            return X.Installation.CompareTo(Y.Installation);
        }
    }

    public class AreaCoverageSorter : Sorter
    {
        public override int Compare(IItem X, IItem Y)
        {
            return X.AreaCoverage.CompareTo(Y.AreaCoverage);
        }
    }

    public class ModelSorter : Sorter
    {
        public override int Compare(IItem X, IItem Y)
        {
            return X.Model.CompareTo(Y.Model);
        }
    }

    public class VendorSorter : Sorter
    {
        public override int Compare(IItem X, IItem Y)
        {
            return X.Vendor.CompareTo(Y.Vendor);
        }
    }
}
