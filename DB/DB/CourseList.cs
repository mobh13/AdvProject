using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class CourseList : DataList
    {
        public CourseList() : base("Course", "CourseID")
        {
        }

        protected override void GenerateList()
        {
            List.Clear();
            SetDataTableColumns(new Course());
            while (Reader.Read())
            {
                Course course = new Course(Reader.GetValue(0).ToString());
                SetValues(course);
                List.Add(course);
                AddDataTableRow(course);
            }
            Reader.Close();
            Connection.Close();
        }
    }
}
