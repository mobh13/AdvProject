using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
namespace Web.student
{
	public partial class Records : System.Web.UI.Page
	{
		protected SectionList sectionList;
		protected SectionStudentList sectionStudentList;
		protected StudentList studentList;
		protected Section section;
		protected TaughtCoursesList taughtCoursesList;
		protected TaughtCourses taughtCourses;
		protected CourseList courseList;
		protected Course course;
		protected Instructor instructor;
		protected InstructorList instructorList; 
		protected void Page_Load(object sender, EventArgs e)
		{
			sectionList = new SectionList();
			sectionStudentList = new SectionStudentList();
			studentList = new StudentList();
			taughtCoursesList = new TaughtCoursesList();
			courseList = new CourseList();
			instructorList = new InstructorList();
			string studentID = Session["User"].ToString();
			sectionStudentList.Filter("StudentID", studentID);
			
			
		}
	}
}