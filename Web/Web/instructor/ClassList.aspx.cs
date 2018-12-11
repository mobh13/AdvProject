using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
namespace Web.instructor
{
	public partial class ClassList : System.Web.UI.Page
	{
		protected SectionList sectionsList;
		protected TaughtCoursesList taughtList;
		protected CourseList courseList;
		protected ScheduleList scheduleList;
		protected InstructorList instructorList;
		protected LocationList locationList;
		protected string print;
		protected void Page_Load(object sender, EventArgs e)
		{
			

			sectionsList = new SectionList();
			taughtList = new TaughtCoursesList();
			locationList = new LocationList();
			courseList = new CourseList();
			scheduleList = new ScheduleList();
			scheduleList.Populate();
			instructorList = new InstructorList();
		}

		protected void MyClasses_CheckedChanged(object sender, EventArgs e)
		{
			
		}
	}
}