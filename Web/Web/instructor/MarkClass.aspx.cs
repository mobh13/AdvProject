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
		/* 
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
		protected string sectionId;
		protected void Page_Load(object sender, EventArgs e)
		{
			if(Request.QueryString["cls"] == null)
			{
				/* check if there is no query string then */
				Response.Write("Error No class requested"); // show error message
				Response.End(); // stop page excution
			}
			else
			{
				sectionList = new SectionList(); // this is needed to check if the section id is valid so we instantiate it before the rest
				sectionList.Filter("SectionID", Request.QueryString["cls"]); //  filter the section with the section id to check if the section id exist
				
			}
			
			/*
			 * check if the user session exist and Account session value is Instructor and the sectionID is valid
			 */
			if (Session["User"] != null && Session["Account"].ToString() == "Instructor" && sectionList.List.Count != 0)
			{
	    	/*
			 * instantiate classes when the page loads 
		     */
				sectionStudentList = new SectionStudentList();
				studentList = new StudentList();
				taughtCoursesList = new TaughtCourseList();
				courseList = new CourseList();
				sectionId = Request.QueryString["cls"]; // get the section id passed in the page url and assign it to secionId var
				sectionList.Filter("SectionID", sectionId); // filter the sectionList with the sectionID
				section = (Section)sectionList.List.ElementAt(0); // get the first element in the list and cast it to (Section)
				taughtCoursesList.Filter("TaughtCourseID", section.TaughtCourseID);// filter the taughtCoursesList with the TaughtCourseID
				taughtCourses = (TaughtCourse)taughtCoursesList.List.ElementAt(0);// get the first element in the list and cast it to (TaughtCourse)
				course = new Course(); // create new Course object
				course.setID(taughtCourses.CourseID.ToString());// set the id of the course object to the value from the taughtCourse object
				courseList.Populate(course); //populate object
				sectionStudentList.Filter("SectionID", sectionId); //filter the sectionstudentList with sectionId
				SectionIdLbl.Text = section.getID(); // set the sectionLable text to the section id 
				CourseID.Text = taughtCourses.CourseID; // set the courseid lable text to the course id 
				CourseName.Text = course.Title; // set courseName lable text to the course title
				GenerateTable(); // call GenerateTable method to fill the grid view with data
			}
			else if (Session["User"] != null && Session["Account"].ToString() != "Instructor")
			{
			/*
			 * else if the user session exist but the account session value is not student show error message 
			 */
				Response.Write("Error You are not allowed to be here");// show error message
				Response.End();// stop page excution
			}
			else if (Session["User"] != null && Session["Account"].ToString() == "Instructor" && sectionList.List.Count == 0)
			{
				/* else if the user session exist and Account session value is Instructor and the sectionID is not valid */
				Response.Write("Error Class not found");// show error message
				Response.End();// stop page excution
			}
			else
			{
			/*
			 * else show error message
			 */
				Response.Write("Error please log in before trying to Access this page..!");// show error message
				Response.End();// stop page excution
			}
		}
		/* Method: GenerateTable
		 * Areguments: none
		 * Return: none
		 * Des: this method is to fill data into the grid view
		 */
		protected void GenerateTable()
		{
			DataTable table = new DataTable();// create data table object					  
            // add the table columns
			table.Columns.Add("Student Id");
			table.Columns.Add("Student Name");
			table.Columns.Add("Mark");
			foreach (SectionStudent sectionStudent in sectionStudentList.List)
			{
				/* foreach element in the sectionStudentList */
				Student student = new Student(sectionStudent.StudentID); // create new student object and pass the id from the element
				studentList.Populate(student); // populate student object
				table.Rows.Add(student.getID(), student.FirstName + " " + student.LastName,sectionStudent.Grade); // add informtaion to table as row
			}
			detailsGridView.DataSource = table; // set the data source of the grid view as the table
			detailsGridView.DataBind(); // bind the data of the grid view

		}
		protected void DetailsGridView_SelectedIndexChanged(object sender, EventArgs e)
		{
			/* this method is called when the selected row index is changed */

			GridViewRow row = detailsGridView.SelectedRow; // decalre a gridview var and assign it to the selected row in the my classes grid view
			Mark.Text= row.Cells[3].Text; // get the mark of the student and assign it to the Mark text box element

		}
		protected void SubmitMarks_Click(object sender, EventArgs e)
		{   /* this method is called when the submit mark button is clicked*/
			double test; // create a dummy double var 

			/*validate if the input can be converted to a double , this method returns true if the 
			 * result can be converted and false if not. assign the result of this method to the 
			 * createe bool var called Isvalid
			 * 
			 * this is an input validation for the mark input
			 */
			bool IsValid = double.TryParse(Mark.Text, out test);

			if (IsValid)
			{
				/* if the input is valid and can be converted to double then */
				GridViewRow row = detailsGridView.SelectedRow; // decalre a gridview var and assign it to the selected row in the my classes grid view
				SectionStudent sectionStudent = new SectionStudent(sectionId, row.Cells[1].Text.ToString()); //declare sectionstudent object and pass the section id as id and student id as a joinID
				sectionStudent.Grade = Mark.Text; // set the sectionStudent grade as the mark text box value
				sectionStudentList.Update(sectionStudent); // update the section student record with the new information
			}
			else
			{
				/* else show error message in a popup */
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('Please enter a valid mark !')", true); // show a message in a popup

			}


		}
	}
}