using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class SectionStudent : ItemJoin
    {
        private string grade;

        public string SectionID { get => base.getID(); set => base.setID(value); }
        public string StudentID { get => base.getIdJoin(); set => base.setIdJoin(value); }
        public string Grade { get => grade; set => grade = value; }

        public SectionStudent(string ID, string IDJoin) : base(ID, IDJoin)
        {

        }

        public SectionStudent()
        {

        }
    }
}
