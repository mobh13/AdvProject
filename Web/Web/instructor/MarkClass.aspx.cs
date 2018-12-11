using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
namespace Web.instructor
{
	public partial class MarkClass : System.Web.UI.Page
	{
		protected SectionList sectionList;
		protected SectionStudentList sectionStudentList;
		protected StudentList studentList;
		protected Section section;
		protected TaughtCoursesList taughtCoursesList;
		protected TaughtCourses taughtCourses;
		protected CourseList courseList;
		protected Course course;
		protected void Page_Load(object sender, EventArgs e)
		{
			sectionList = new SectionList();
			sectionStudentList = new SectionStudentList();
			studentList = new StudentList();
			taughtCoursesList = new TaughtCoursesList();
			courseList = new CourseList();
			string sectionId = Request.QueryString["cls"];
			sectionList.Filter("SectionID", sectionId);
			section = (Section)sectionList.List.ElementAt(0);
			taughtCoursesList.Filter("TaughtCourseID", section.TaughtCourseID);
			taughtCourses = (TaughtCourses)taughtCoursesList.List.ElementAt(0);
			course = new Course();
			course.setID(taughtCourses.CourseID.ToString());
			courseList.Populate(course);
			sectionStudentList.Filter("SectionID", sectionId);

		}

		protected void submitMarks_Click(object sender, EventArgs e)
		{
			foreach(SectionStudent sectionStudent in sectionStudentList.List)
			{

				
			}
		}
	}
}