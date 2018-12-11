using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class TaughtCoursesList : DataList
    {
        public TaughtCoursesList() : base("TaughtCourse", "TaughtCourseID")
    {
    }

    protected override void GenerateList()
    {
        List.Clear();
        SetDataTableColumns(new TaughtCourses());
        while (Reader.Read())
        {
           TaughtCourses taughtCourses = new TaughtCourses(Reader.GetValue(0).ToString());
            SetValues(taughtCourses);
            List.Add(taughtCourses);
            AddDataTableRow(taughtCourses);
        }
        Reader.Close();
        Connection.Close();
    }
   }
}
 

