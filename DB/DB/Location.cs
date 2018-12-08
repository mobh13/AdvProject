using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class Location : Item
    {
        private string name;
        private int capacity;

        public string LocationID { get => base.getID(); set => base.setID(value); }
        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }

        public Location(String ID) : base(ID)
        {

        }
        public Location()
        {

        }
        public override string ToString()
        {
            return LocationID;
        }
    }
}
