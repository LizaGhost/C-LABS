using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class TabletItem : ItemBase
    {
        public float diagonal { get; set; }

        public TabletItem(string vendor)
        {
            Vendor = vendor;
        }

        protected override string GetDescription()
        {
            return $"{Vendor,-10}|{Model,-9}|{AreaCoverage,-6}|{Installation,-12}|{MaxNoiseLevel,-9}";
        }

        //public object Clone()
        //{
        //    throw new NotImplementedException();
        //}

        //public int CompareTo(TabletItem? other)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
