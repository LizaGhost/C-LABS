using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public enum InstallationEnum
    {
        OUTDOOR, DESKTOP, WALL_MOUNTED
    }

    public abstract class ItemBase : IItem
    {
        public string Vendor { get; set; }
        public string Model { get; set; }
        public int AreaCoverage { get; set; }
        public InstallationEnum Installation { get; set; }
        public int MaxNoiseLevel { get; set; }
        public int Power { get; set; }
        public decimal Price { get; set; }

        protected abstract string GetDescription();

        public sealed override string ToString()
        {
            return GetDescription();
        }


        public object Clone()
        {
            // Возвращаем поверхностную копию объекта
            return this.MemberwiseClone();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;
            // Приведение типа obj к ItemBase
            if (obj is ItemBase otherItem)
            {
                // Сравниваем объекты по свойству Power
                return this.AreaCoverage.CompareTo(otherItem.AreaCoverage);
            }
            else
            {
                throw new ArgumentException("Объект не является ItemBase");
            }
        }
    }
}
