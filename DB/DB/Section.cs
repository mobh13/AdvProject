using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class Section : Item
    {
        private string taughtCourseID;
        private string instructorID;
        private string capacity;

        public string SectionID { get => base.getID(); set => base.setID(value); }
        public string TaughtCourseID { get => taughtCourseID; set => taughtCourseID = value; }
        public string InstructorID { get => instructorID; set => instructorID = value; }
        public string Capacity { get => capacity; set => capacity = value; }

        public Section(String ID) : base(ID)
        {

        }
        public Section()
        {

        }
        public override string ToString()
        {
            return SectionID;
        }
    }
}
