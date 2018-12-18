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
	{   /* 
		 * declare Variables to be used in this page
		 */
		protected SectionList sectionList;
		protected SectionStudentList sectionStudentList;
		protected StudentList studentList;
		protected Section section;
		protected TaughtCourseList taughtCoursesList;
		protected TaughtCourse taughtCourses;
		protected CourseList courseList;
		protected Course course;
		protected Instructor instructor;
		protected InstructorList instructorList;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["User"] != null && Session["Account"].ToString() == "Student")
			{
				/*
				 * check if the user session exist and Account session value is student
				 */

				/*
			instantiate classes when the page loads 
			*/
				sectionList = new SectionList();
				sectionStudentList = new SectionStudentList();
				studentList = new StudentList();
				taughtCoursesList = new TaughtCourseList();
				courseList = new CourseList();
				instructorList = new InstructorList();
				string studentID = Session["User"].ToString(); //declare , get the id of the student from the session and assign it to variable 
				sectionStudentList.Filter("StudentID", studentID); // filter the section student list using the studentID
				GenerateGridData(); //call GenerateGridData method to add data to the gridView

			}
			else if (Session["User"] != null && Session["Account"].ToString() != "Student")
			{
				/*
				 * else if the user session exist but the account session value is not student show error message 
				 */
				Response.Write("Error You are not allowed to be here");
				Response.End();
			}
			else
			{
				/*
				 * else show error message
				 */
				Response.Write("Error please log in before trying to Access this page..!");
				Response.End();

			}



		}

		/*
		 * Method: GenerateGridData
		 * Areguments: none
		 * Return: none
		 * Des: this method is to fill the GridView with data
		 */
		protected void GenerateGridData()
		{
			DataTable table = new DataTable(); // declare and instantiate DataTable object
											   /*
												* Add Columns to the data table
												*/
			table.Columns.Add("Course Id");
			table.Columns.Add("Section Id");
			table.Columns.Add("Course Name");
			table.Columns.Add("Instructor Name");
			table.Columns.Add("Mark");

			foreach (SectionStudent sectionStudent in sectionStudentList.List)
			{
				/*
				 * Foreach Element in the sectionStudentList  
				 */

				section = new Section(sectionStudent.SectionID); // create new section object and pass the section id to it
				sectionList.Populate(section); // populate the section object
				instructor = new Instructor(section.InstructorID); // create new instructor object and pass the  id to it
				instructorList.Populate(instructor); // populate the instructor object
				taughtCourses = new TaughtCourse(section.TaughtCourseID); // create new TaughtCourse object and pass the TaughtCourse id to it
				taughtCoursesList.Populate(taughtCourses);// populate TaughtCourse
				course = new Course(taughtCourses.CourseID); // create new course object and pass the course id to it
				courseList.Populate(course);//populate the course object

				table.Rows.Add(course.getID(), section.getID(), course.Title, instructor.FirstName + " " + instructor.LastName, sectionStudent.Grade);
				// add a row to the dataTable object with the information from the above objects
			}
			MarksGrid.DataSource = table; // set the dataTable object as the dataSource of the GidView element
			MarksGrid.DataBind(); // bind the data
		}
	}
}
