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
	public partial class TimeTable : System.Web.UI.Page
	{
		/* 
		 * declare Variables to be used in this page
		 */
		protected ScheduleList scheduleList;
		protected SectionList SectionList;
		protected SectionStudentList SectionStudentList;
		protected TaughtCourseList taughtCoursesList;
		protected CourseList courseList;
		protected string id;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["User"] != null && Session["Account"].ToString() == "Student")
			{
				/*
				 * check if the user session exist and Account session value is student
				 */

				/*
				 * instantiate classes when the page loads 
				 */
				scheduleList = new ScheduleList();
				SectionList = new SectionList();
				SectionStudentList = new SectionStudentList();
				taughtCoursesList = new TaughtCourseList();
				courseList = new CourseList();
				id = Session["User"].ToString(); //get the id of the student from the session and assign it to variable 
				SectionStudentList.Filter("StudentID", id); // filter the sectionstudentList usign the student id 
				GenerateGridView(); // call the GenerateGridView method to fill the gridView element with data

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
		 * Method: AddToGridByDayAndTime
		 * Areguments: none
		 * Return: none
		 * Des: this method is to put the information in its place in the grid view
		 */
		protected void AddToGridByDayAndTime(Section section, Course course, Schedule schedule)
		{

			string textToDispaly = section.getID() + " - " + course.getID() + " - " + course.Title; // create string var with the information wanted to be displayed
			switch (schedule.Day)
			{
				/* switch the schedule days  */
				case "Saturday":
					/* if the day is Saturday then switch between time*/
					switch (schedule.Time)
					{
						case "8":
							timeTableGridView.Rows[0].Cells[1].Text = textToDispaly;
							break;
						case "9":
							timeTableGridView.Rows[1].Cells[1].Text = textToDispaly;
							break;
						case "10":
							timeTableGridView.Rows[2].Cells[1].Text = textToDispaly;
							break;
						case "11":
							timeTableGridView.Rows[3].Cells[1].Text = textToDispaly;
							break;
						case "12":
							timeTableGridView.Rows[4].Cells[1].Text = textToDispaly;
							break;
						case "1":
							timeTableGridView.Rows[5].Cells[1].Text = textToDispaly;
							break;
						case "2":
							timeTableGridView.Rows[6].Cells[1].Text = textToDispaly;
							break;
						case "3":
							timeTableGridView.Rows[7].Cells[1].Text = textToDispaly;
							break;
						case "4":
							timeTableGridView.Rows[8].Cells[1].Text = textToDispaly;
							break;
						case "5":
							timeTableGridView.Rows[9].Cells[1].Text = textToDispaly;
							break;
					}


					break;
				case "Sunday":
					/* if the day is Sunday then switch between time*/

					switch (schedule.Time)
					{
						case "8":
							timeTableGridView.Rows[0].Cells[2].Text = textToDispaly;
							break;
						case "9":
							timeTableGridView.Rows[1].Cells[2].Text = textToDispaly;
							break;
						case "10":
							timeTableGridView.Rows[2].Cells[2].Text = textToDispaly;
							break;
						case "11":
							timeTableGridView.Rows[3].Cells[2].Text = textToDispaly;
							break;
						case "12":
							timeTableGridView.Rows[4].Cells[2].Text = textToDispaly;
							break;
						case "1":
							timeTableGridView.Rows[5].Cells[2].Text = textToDispaly;
							break;
						case "2":
							timeTableGridView.Rows[6].Cells[2].Text = textToDispaly;
							break;
						case "3":
							timeTableGridView.Rows[7].Cells[2].Text = textToDispaly;
							break;
						case "4":
							timeTableGridView.Rows[8].Cells[2].Text = textToDispaly;
							break;
						case "5":
							timeTableGridView.Rows[9].Cells[2].Text = textToDispaly;
							break;
					}

					break;
				case "Monday":
					/* if the day is Monday then switch between time*/

					switch (schedule.Time)
					{
						case "8":
							timeTableGridView.Rows[0].Cells[3].Text = textToDispaly;
							break;
						case "9":
							timeTableGridView.Rows[1].Cells[3].Text = textToDispaly;
							break;
						case "10":
							timeTableGridView.Rows[2].Cells[3].Text = textToDispaly;
							break;
						case "11":
							timeTableGridView.Rows[3].Cells[3].Text = textToDispaly;
							break;
						case "12":
							timeTableGridView.Rows[4].Cells[3].Text = textToDispaly;
							break;
						case "1":
							timeTableGridView.Rows[5].Cells[3].Text = textToDispaly;
							break;
						case "2":
							timeTableGridView.Rows[6].Cells[3].Text = textToDispaly;
							break;
						case "3":
							timeTableGridView.Rows[7].Cells[3].Text = textToDispaly;
							break;
						case "4":
							timeTableGridView.Rows[8].Cells[3].Text = textToDispaly;
							break;
						case "5":
							timeTableGridView.Rows[9].Cells[3].Text = textToDispaly;
							break;
					}

					break;
				case "Tuesday":
					/* if the day is Tuesday then switch between time*/

					switch (schedule.Time)
					{
						case "8":
							timeTableGridView.Rows[0].Cells[4].Text = textToDispaly;
							break;
						case "9":
							timeTableGridView.Rows[1].Cells[4].Text = textToDispaly;
							break;
						case "10":
							timeTableGridView.Rows[2].Cells[4].Text = textToDispaly;
							break;
						case "11":
							timeTableGridView.Rows[3].Cells[4].Text = textToDispaly;
							break;
						case "12":
							timeTableGridView.Rows[4].Cells[4].Text = textToDispaly;
							break;
						case "1":
							timeTableGridView.Rows[5].Cells[4].Text = textToDispaly;
							break;
						case "2":
							timeTableGridView.Rows[6].Cells[4].Text = textToDispaly;
							break;
						case "3":
							timeTableGridView.Rows[7].Cells[4].Text = textToDispaly;
							break;
						case "4":
							timeTableGridView.Rows[8].Cells[4].Text = textToDispaly;
							break;
						case "5":
							timeTableGridView.Rows[9].Cells[4].Text = textToDispaly;
							break;
					}

					break;
				case "Wednesday":
					/* if the day is Wednesday then switch between time*/

					switch (schedule.Time)
					{
						case "8":
							timeTableGridView.Rows[0].Cells[5].Text = textToDispaly;
							break;
						case "9":
							timeTableGridView.Rows[1].Cells[5].Text = textToDispaly;
							break;
						case "10":
							timeTableGridView.Rows[2].Cells[5].Text = textToDispaly;
							break;
						case "11":
							timeTableGridView.Rows[3].Cells[5].Text = textToDispaly;
							break;
						case "12":
							timeTableGridView.Rows[4].Cells[5].Text = textToDispaly;
							break;
						case "1":
							timeTableGridView.Rows[5].Cells[5].Text = textToDispaly;
							break;
						case "2":
							timeTableGridView.Rows[6].Cells[5].Text = textToDispaly;
							break;
						case "3":
							timeTableGridView.Rows[7].Cells[5].Text = textToDispaly;
							break;
						case "4":
							timeTableGridView.Rows[8].Cells[5].Text = textToDispaly;
							break;
						case "5":
							timeTableGridView.Rows[9].Cells[5].Text = textToDispaly;
							break;
					}

					break;
				case "Thursday":
					/* if the day is Thursday then switch between time*/

					switch (schedule.Time)
					{
						case "8":
							timeTableGridView.Rows[0].Cells[6].Text = textToDispaly;
							break;
						case "9":
							timeTableGridView.Rows[1].Cells[6].Text = textToDispaly;
							break;
						case "10":
							timeTableGridView.Rows[2].Cells[6].Text = textToDispaly;
							break;
						case "11":
							timeTableGridView.Rows[3].Cells[6].Text = textToDispaly;
							break;
						case "12":
							timeTableGridView.Rows[4].Cells[6].Text = textToDispaly;
							break;
						case "1":
							timeTableGridView.Rows[5].Cells[6].Text = textToDispaly;
							break;
						case "2":
							timeTableGridView.Rows[6].Cells[6].Text = textToDispaly;
							break;
						case "3":
							timeTableGridView.Rows[7].Cells[6].Text = textToDispaly;
							break;
						case "4":
							timeTableGridView.Rows[8].Cells[6].Text = textToDispaly;
							break;
						case "5":
							timeTableGridView.Rows[9].Cells[6].Text = textToDispaly;
							break;
					}

					break;
				case "Friday":
					/* if the day is Friday then switch between time*/

					switch (schedule.Time)
					{
						case "8":
							timeTableGridView.Rows[0].Cells[7].Text = textToDispaly;
							break;
						case "9":
							timeTableGridView.Rows[1].Cells[7].Text = textToDispaly;
							break;
						case "10":
							timeTableGridView.Rows[2].Cells[7].Text = textToDispaly;
							break;
						case "11":
							timeTableGridView.Rows[3].Cells[7].Text = textToDispaly;
							break;
						case "12":
							timeTableGridView.Rows[4].Cells[7].Text = textToDispaly;
							break;
						case "1":
							timeTableGridView.Rows[5].Cells[7].Text = textToDispaly;
							break;
						case "2":
							timeTableGridView.Rows[6].Cells[7].Text = textToDispaly;
							break;
						case "3":
							timeTableGridView.Rows[7].Cells[7].Text = textToDispaly;
							break;
						case "4":
							timeTableGridView.Rows[8].Cells[7].Text = textToDispaly;
							break;
						case "5":
							timeTableGridView.Rows[9].Cells[7].Text = textToDispaly;
							break;
					}

					break;
			}
		}
		/*
		 * Method: GenerateGridView
		 * Areguments: none
		 * Return: none
		 * Des: this method is to fill the GridView with data
		 */
		protected void GenerateGridView()
		{
			DataTable table = new DataTable(); // create new DataTable object
											   /* Fill the table with Columns and rows */

			table.Columns.Add(" ");
			table.Columns.Add("Saturday");
			table.Columns.Add("Sunday");
			table.Columns.Add("Monday");
			table.Columns.Add("Tuesday");
			table.Columns.Add("Wednesday");
			table.Columns.Add("Thursday");
			table.Columns.Add("Friday");
			table.Rows.Add("8", "", "", "", "", "", "", "");
			table.Rows.Add("9", "", "", "", "", "", "", "");
			table.Rows.Add("10", "", "", "", "", "", "", "");
			table.Rows.Add("11", "", "", "", "", "", "", "");
			table.Rows.Add("12", "", "", "", "", "", "", "");
			table.Rows.Add("1", "", "", "", "", "", "", "");
			table.Rows.Add("2", "", "", "", "", "", "", "");
			table.Rows.Add("3", "", "", "", "", "", "", "");
			table.Rows.Add("4", "", "", "", "", "", "", "");
			table.Rows.Add("5", "", "", "", "", "", "", "");
			timeTableGridView.DataSource = table; // add the table as data source for the gridview
			timeTableGridView.DataBind();// bind the data
			foreach (SectionStudent sectionStudent in SectionStudentList.List)
			{
				/* ForEach element in the sectionstudentList */
				Section section = new Section(sectionStudent.getID()); // create new student object and pass the id
				SectionList.Populate(section); // populate the section object
				TaughtCourse taught = new TaughtCourse(section.TaughtCourseID); // create new TaughtCourse object and pass the id
				taughtCoursesList.Populate(taught);// populate the TaughtCourse object
				Course course = new Course(taught.CourseID);// create new Course object and pass the id
				courseList.Populate(course);// populate the Course object

				scheduleList.Filter("SectionID", sectionStudent.getID()); // filter the schedule list according to section id
				foreach (Schedule schedule in scheduleList.List)
				{
					/* ForEeach Element in sechedule List */
					AddToGridByDayAndTime(section, course, schedule); // call AddToGridByDayAndTime to add the schedule information to the gridView 
					while (Convert.ToInt32(schedule.Duration) > 1)
					{
						/* While the schedule duration is more than 1 do*/
						int newTime = Convert.ToInt32(schedule.Time) + 1; //get the old time and add 1 and assign it to var
						schedule.Time = newTime.ToString(); // set the schedule object time to the new time
						AddToGridByDayAndTime(section, course, schedule); // call AddToGridByDayAndTime to add the schedule information to the gridView
						int duration = Convert.ToInt32(schedule.Duration) - 1; // get the duration and abstract 1 
						schedule.Duration = duration.ToString(); //  assign the new duration to the schedule duration
					}



				}
			}
		}
	}
}