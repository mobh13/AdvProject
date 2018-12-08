using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class Course : Item
    {
       private string courseID;
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
        public string CourseID { get => courseID; set => courseID = value; }
        public string Title { get => title; set => title = value; }
        public string Credits { get => credits; set => credits = value; }
    }
}
