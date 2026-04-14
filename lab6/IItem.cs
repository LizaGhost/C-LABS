using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public interface IItem: IComparable, ICloneable
    {
        string Vendor { get; set; }
        string Model { get; set; }
        int AreaCoverage { get; set; }
        InstallationEnum Installation { get; set; }
        int MaxNoiseLevel { get; set; }
        public int Power { get; set; }
        public decimal Price { get; set; }
    }
}
