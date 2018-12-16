using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class TaughtCourseList : DataList
    {
        public TaughtCourseList() : base("TaughtCourse", "TaughtCourseID")
    {
    }

    protected override void GenerateList()
    {
        List.Clear();
        SetDataTableColumns(new TaughtCourse());
        while (Reader.Read())
        {
           TaughtCourse taughtCourses = new TaughtCourse(Reader.GetValue(0).ToString());
            SetValues(taughtCourses);
            List.Add(taughtCourses);
            AddDataTableRow(taughtCourses);
        }
        Reader.Close();
        Connection.Close();
    }
   }
}
 

