using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yureva1;

namespace lab1
{
    public class Item : ItemBase
    {
        private int maxNoiceLevel;
        private int power;

        public int MaxNoiceLevel
        {
            get { return maxNoiceLevel; }
            set { maxNoiceLevel = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public Item(string brand, string model, int areaCoverage, InstallationEnum installation, int maxNoiceLevel, int power, double cost)
        {
            Brand = brand; // бренд
            Model = model; // модель
            AreaCoverage = areaCoverage; // площадь
            Installation = installation; // установка
            MaxNoiceLevel = maxNoiceLevel; // макс. уровень шума
            Power = power; // мощность
            Cost = cost; // цена
        }

        public override string ToString()
        {
            return string.Format("{0,-10}|{1,-9}|{2,-6}|{3,-12}|{4,-9}|{5,-6}|{6,3:F2}", Brand, Model, AreaCoverage, Installation, MaxNoiceLevel, Power, Cost);
        }
    }
}
