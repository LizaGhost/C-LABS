using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static lab4.Shop;

namespace lab4
{
    public class PhoneItem : ItemBase
    {
        public int Power { get; set; }
        public decimal Price { get; set; }


        public PhoneItem(string vendor, string model, int areaCoverage, InstallationEnum installation, int maxNoiseLevel, int power, decimal price)
        {
            Vendor = vendor;
            Model = model;
            AreaCoverage = areaCoverage;
            Installation = installation;
            MaxNoiseLevel = maxNoiseLevel;
            Power = power;
            Price = price;
        }

        protected override string GetDescription()
        {
            return $"{Vendor,-10}|{Model,-9}|{AreaCoverage,-6}|{Installation,-12}|{MaxNoiseLevel,-9}|{Power,-6}|{Price,3:F2}";
        }

        // Реализация метода Clone из интерфейса ICloneable
        public object Clone()
        {
            // Возвращаем поверхностную копию объекта
            return this.MemberwiseClone();
        }

        // Реализация метода CompareTo из интерфейса IComparable<IItem>
        public int CompareTo(PhoneItem? other)
        {
            if (other == null)
                return 1;
            // Приведение типа obj к ItemBase
            if (other is ItemBase otherItem)
            {
                // Сравниваем объекты по свойству AreaCoverage
                return this.AreaCoverage.CompareTo(otherItem.AreaCoverage);
            }
            else
            {
                throw new ArgumentException("Объект не является ItemBase");
            }
        }


    }
}
