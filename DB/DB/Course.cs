using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Course : Item
    {
        private string title;
        private string credits;

        public Course(string ID) : base(ID)
        {

        }

        public Course()
        {

        }
        public override string ToString()
        {
            return CourseID;
        }
        public string CourseID { get => base.getID(); set => base.setID(value); }
        public string Title { get => title; set => title = value; }
        public string Credits { get => credits; set => credits = value; }
    }
}
