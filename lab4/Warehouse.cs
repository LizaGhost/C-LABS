using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public interface IWarehouse : IList<IItem>
    {
        List<IItem> GetItems();
        void SetItems();
        void ShowItems();
        void Add(IItem item);
        void Clear();
        void Insert(int index, IItem item);
        void RemoveAt(int index);
    }

    public class Warehouse : IWarehouse
    {
        // интерфейс представляет коллекцию объектов, доступных по индексу
        List<WarehouseItem> itemsInWarehouse = new List<WarehouseItem>();
        public int ItemId { get; set; }

        public Warehouse(List<IItem> items)
        {
            SetItems(items);
        }

        public void SetItems(List<IItem> items) // создает новую коллекцию
        {
            for (int i = 0; i < items.Count; i++)
            {
                WarehouseItem newItem = new WarehouseItem(ItemId, items[i]);
                itemsInWarehouse.Add(newItem);
                ItemId++;
            }
        }
        public void ShowItems() // показывает элементы коллекции
        {
            for (int i = 0; i < itemsInWarehouse.Count; i++)
            {
                Console.Write(itemsInWarehouse[i].Id + " " + itemsInWarehouse[i].Item.ToString() + "\n");
            }
        }
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public IItem this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(IItem item) // добавляет элемент в коллекцию
        {
            WarehouseItem newItem = new WarehouseItem(ItemId, item);
            itemsInWarehouse.Add(newItem);
            ItemId++;
        }

        public void Clear() // очищает коллекцию
        {
            itemsInWarehouse.Clear();
        }

        public bool Contains(IItem item) // содержит ли коллекция элемент
        {
            WarehouseItem newItem = new WarehouseItem(ItemId, item);
            return itemsInWarehouse.Contains(newItem);
        }

        public void Insert(int index, IItem item) // вставляет элемент коллекции по указанному индексу
        {
            WarehouseItem newItem = new WarehouseItem(ItemId, item);
            itemsInWarehouse.Insert(index, newItem);
            ItemId++;
        }

        public void RemoveAt(int index) // удаляет элемент коллекции по указанному индексу
        {
            itemsInWarehouse.RemoveAt(index);
        }

        public void CopyTo(IItem[] array, int arrayIndex) // копирует элементы коллекции в массив
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public List<IItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(IItem item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IItem item)
        {
            throw new NotImplementedException();
        }

        public void SetItems()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
