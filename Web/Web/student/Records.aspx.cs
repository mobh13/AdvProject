using System;
using System.Collections.Generic;
using System.Data;
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
			GenerateGridData();


		}
		protected void GenerateGridData()
		{
			DataTable table = new DataTable();
			table.Columns.Add("Course Id");
			table.Columns.Add("Section Id");
			table.Columns.Add("Course Name");
			table.Columns.Add("Instructor Name");
			table.Columns.Add("Mark");

			foreach (SectionStudent sectionStudent in sectionStudentList.List)
			{
				section = new Section(sectionStudent.SectionID);
				sectionList.Populate(section);
				instructor = new Instructor(section.InstructorID);
				instructorList.Populate(instructor);
				taughtCourses = new TaughtCourses(section.TaughtCourseID);
				taughtCoursesList.Populate(taughtCourses);
				course = new Course(taughtCourses.CourseID);
				courseList.Populate(course);

				table.Rows.Add(course.getID(), section.getID(), course.Title, instructor.FirstName + " " + instructor.LastName, sectionStudent.Grade);
			}
			MarksGrid.DataSource = table;
			MarksGrid.DataBind();
		}
		}
}