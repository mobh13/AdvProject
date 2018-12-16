using System;
using System.Collections.Generic;
using System.Data;
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
		protected TaughtCourseList taughtCoursesList;
		protected TaughtCourse taughtCourses;
		protected CourseList courseList;
		protected Course course;
		protected string sectionId;
		protected void Page_Load(object sender, EventArgs e)
		{

			if (Session["User"] != null && Session["Account"].ToString() == "Instructor")
			{
				sectionList = new SectionList();
				sectionStudentList = new SectionStudentList();
				studentList = new StudentList();
				taughtCoursesList = new TaughtCourseList();
				courseList = new CourseList();
				sectionId = Request.QueryString["cls"];
				sectionList.Filter("SectionID", sectionId);
				section = (Section)sectionList.List.ElementAt(0);
				taughtCoursesList.Filter("TaughtCourseID", section.TaughtCourseID);
				taughtCourses = (TaughtCourse)taughtCoursesList.List.ElementAt(0);
				course = new Course();
				course.setID(taughtCourses.CourseID.ToString());
				courseList.Populate(course);
				sectionStudentList.Filter("SectionID", sectionId);
				SectionIdLbl.Text = section.getID();
				CourseID.Text = taughtCourses.CourseID;
				CourseName.Text = course.Title;
				GenerateTable();

			}
			else if (Session["User"] != null && Session["Account"].ToString() != "Instructor")
			{
				Response.Write("Error You are not allowed to be here");
				Response.End();
			}
			else
			{
				Response.Write("Error please log in before trying to Access this page..!");
				Response.End();
			}
			

		}
		protected void GenerateTable()
		{
			DataTable table = new DataTable();
			table.Columns.Add("Student Id");
			table.Columns.Add("Student Name");
			table.Columns.Add("Mark");
			foreach (SectionStudent sectionStudent in sectionStudentList.List)
			{
				Student student = new Student(sectionStudent.StudentID);
				studentList.Populate(student);
				table.Rows.Add(student.getID(), student.FirstName + " " + student.LastName,sectionStudent.Grade);
			}
			detailsGridView.DataSource = table;
			detailsGridView.DataBind();

		}
		protected void DetailsGridView_SelectedIndexChanged(object sender, EventArgs e)
		{

			GridViewRow row = detailsGridView.SelectedRow;
			Mark.Text= row.Cells[3].Text;

		}
		protected void SubmitMarks_Click(object sender, EventArgs e)
		{
			GridViewRow row = detailsGridView.SelectedRow;

			SectionStudent sectionStudent = new SectionStudent(sectionId, row.Cells[1].Text.ToString());
			sectionStudent.Grade = Mark.Text;
			sectionStudentList.Update(sectionStudent);

		}
	}
}