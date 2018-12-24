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
	public partial class ClassList : System.Web.UI.Page
	{
		/* 
		 * declare Variables to be used in this page
		 */
		protected SectionList sectionsList;
		protected TaughtCourseList taughtList;
		protected CourseList courseList;
		protected ScheduleList scheduleList;
		protected InstructorList instructorList;
		protected LocationList locationList;
		protected string print;
		protected string InsId;
		protected void Page_Load(object sender, EventArgs e)
		{
            /*
	    	 * check if the user session exist and Account session value is Instructor
		    */
			if (Session["User"] != null && Session["Account"].ToString() == "Instructor")
			{
				/*
				 * instantiate classes when the page loads 
				 */
				sectionsList = new SectionList();
				taughtList = new TaughtCourseList();
				locationList = new LocationList();
				courseList = new CourseList();
				scheduleList = new ScheduleList();
				scheduleList.Populate(); //populate schedule list
				instructorList = new InstructorList();
				InsId = Session["User"].ToString(); // get the id of the instructor from the session
				GenerateAllClassessGridData(); // call GenerateAllClassessGridData method to fill the all classess grid view
				GenerateMyClassessGridData(); // call GenerateMyClassessGridData method to fill the my classess grid view
			}
			else if (Session["User"] != null && Session["Account"].ToString() != "Instructor")
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
	 * Method: GenerateAllClassessGridData
	 * Areguments: none
	 * Return: none
	 * Des: this method is to fill the all classes GridView with data
	 */
		protected void GenerateAllClassessGridData()
		{
			DataTable table = new DataTable(); // create data table object
			// add the table columns
			table.Columns.Add("Course Id");
			table.Columns.Add("Section Id");
			table.Columns.Add("Course Title");
			table.Columns.Add("Location");
			table.Columns.Add("Time");
			table.Columns.Add("Date");
			table.Columns.Add("Instructor Name");

			foreach (Schedule schedule in scheduleList.List)
			{
				/* foreach element in the scheduleList 
				 */
				sectionsList.Filter("SectionID", schedule.SectionID); // filter the sectionList with sectionID
				Section section = (Section)sectionsList.List.ElementAt(0); // get the first element in the list and cast it to ( section )
				taughtList.Filter("TaughtCourseID", section.TaughtCourseID); // filter the taughtCourseList with taughtcourseID from the section object
				TaughtCourse taughtcourse = (TaughtCourse)taughtList.List.ElementAt(0);// get the first element in the list and cast it to ( TaughtCourse )
				courseList.Filter("CourseID", taughtcourse.CourseID); //filter the CoursList with courseID from taughCourse object
				Course course = (Course)courseList.List.ElementAt(0); // get the first element in the list and cast it to ( Course )
				locationList.Filter("LocationID", schedule.LocationID);// filter the locationList with locationID from the section object
				Location location = (Location)locationList.List.ElementAt(0); // get the first element in the list and cast it to ( Location )
				instructorList.Filter("InstructorID", section.InstructorID); // filter the instructorList with the instructorID from section object
				Instructor instructor = (Instructor)instructorList.List.ElementAt(0); // get the first element in the list and cast it to ( Instructor )
				table.Rows.Add(taughtcourse.CourseID, section.getID(), course.Title, location.Name, schedule.Time, schedule.Day, instructor.FirstName + " " + instructor.LastName); // add information as row to the table object

			}
			allclassListGrid.DataSource = table; // set table as the dataSource of the grid view
			allclassListGrid.DataBind(); // bind the data
		}

		/*
 * Method: GenerateAllClassessGridData
 * Areguments: none
 * Return: none
 * Des: this method is to fill the all classes GridView with data
 */

		protected void GenerateMyClassessGridData()
		{
			DataTable table = new DataTable(); // create data table object
											   // add the table columns

			table.Columns.Add("Course Id");
			table.Columns.Add("Section Id");
			table.Columns.Add("Course Title");


			sectionsList.Filter("InstructorID", InsId); // filter the sectionList with the instructor id 
			foreach (Section section in sectionsList.List)
			{
				/* foreach element in the sectionList */

				taughtList.Filter("TaughtCourseID", section.TaughtCourseID); // filter the taughtCourseList with the taughtCourseID 
				TaughtCourse taughtcourse = (TaughtCourse)taughtList.List.ElementAt(0); // get the first elment from the list and cast it to (TaughtCourse)
				courseList.Filter("CourseID", taughtcourse.CourseID); // filter the courseList with courseID 
				Course course = (Course)courseList.List.ElementAt(0);// get the first elment from the list and cast it to (Course)

				table.Rows.Add(taughtcourse.CourseID, section.getID(), course.Title);// add information as row to the table object
			}

			myclassListGrid.DataSource = table; // set table as the dataSource of the grid view
			myclassListGrid.DataBind();  // bind the data
		}
		protected void MyClasses_CheckedChanged(object sender, EventArgs e)
		{

		}
		protected void MarkClass_Click(object sender, EventArgs e)
		{
			/* this method is called when the mark class button is clicked*/
			GridViewRow row = myclassListGrid.SelectedRow; // decalre a gridview var and assign it to the selected row in the my classes grid view
			string classId = row.Cells[2].Text; // get the section id from the row and assign it to a var of type string 
			Response.Redirect("MarkClass?cls=" + classId); // redirect the user to the mark class page and pass the section id
		}
	}
}