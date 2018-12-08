using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Schedule : Item
    {
        private string sectionID;
        private string locationID;
        private string day;
        private string time;
        private string duration;

        public string ScheduleID { get => base.getID(); set => base.setID(value); }
        public string SectionID { get => sectionID; set => sectionID = value; }
        public string LocationID { get => locationID; set => locationID = value; }
        public string Day { get => day; set => day = value; }
        public string Time { get => time; set => time = value; }
        public string Duration { get => duration; set => duration = value; }

        public Schedule(string ID) : base(ID)
        {

        }
        public Schedule()
        {

        }
        public override string ToString()
        {
            return base.getID();
        }
    }
}
