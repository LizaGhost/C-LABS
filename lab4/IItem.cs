using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public interface IItem: IComparable, ICloneable
    {
        string Vendor { get; set; }
        string Model { get; set; }
        int AreaCoverage { get; set; }
        InstallationEnum Installation { get; set; }
        int MaxNoiseLevel { get; set; }
    }
}
