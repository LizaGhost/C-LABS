
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class WarehouseItem
    {
        public IItem Item { get; set; }
        public int Id { get; set; }

        public WarehouseItem(int id, IItem item)
        {
            Id = id;
            Item = item;
        }
    }
}
