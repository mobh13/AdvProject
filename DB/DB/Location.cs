using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Location : Item
    {
        private string name;
        private string capacity;

        public string LocationID { get => base.getID(); set => base.setID(value); }
        public string Name { get => name; set => name = value; }
        public string Capacity { get => capacity; set => capacity = value; }

        public Location(String ID) : base(ID)
        {

        }
        public Location()
        {

        }
        public override string ToString()
        {
            return base.getID();
        }
    }
}
