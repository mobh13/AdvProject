using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    class SectionStudentList : DataListJoin
    {
        public SectionStudentList() : base("SectionStudent", "SectionID", "StudentID")
        {   }

        protected override void GenerateList()
        {
            SetDataTableColumns(new SectionStudent());
            List.Clear();

            while (Reader.Read())
            {
                SectionStudent sectionStudent = new SectionStudent(Reader.GetValue(0).ToString(),
                                                Reader.GetValue(1).ToString());
                SetValues(sectionStudent);
                List.Add(sectionStudent);
                AddDataTableRow(sectionStudent);
            }
            Reader.Close();
            Connection.Close();
        }
    }
}
