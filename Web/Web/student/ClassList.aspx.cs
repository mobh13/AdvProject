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
		protected StudentList studentList;
		protected SectionStudentList sectionStudentList;

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
				sectionsList = new SectionList();
				taughtList = new TaughtCourseList();
				locationList = new LocationList();
				courseList = new CourseList();
				scheduleList = new ScheduleList();
				sectionStudentList = new SectionStudentList();
				studentList = new StudentList();
				scheduleList.Populate(); // populate the sechuleList
				instructorList = new InstructorList();
				GenerateGridData();// call GenerateGridData method to fill the gridview element with data

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
			DataTable table = new DataTable();// declare and instantiate DataTable object

			/*
			 * Add Columns to the data table
			 */
			table.Columns.Add("Course Id");
			table.Columns.Add("Section Id");
			table.Columns.Add("Course Title");
			table.Columns.Add("Location");
			table.Columns.Add("Time");
			table.Columns.Add("Date");
			table.Columns.Add("Instructor Name");
			foreach (Schedule schedule in scheduleList.List)
			{
				/*
				 * Foreach Element in the scheduleList  
				 */
				sectionsList.Filter("SectionID", schedule.SectionID); // filter the sectionList using the section id from the element of scheduleList
				Section section = (Section) sectionsList.List.ElementAt(0); // get the section object from the sectionList

				taughtList.Filter("TaughtCourseID", section.TaughtCourseID); // filter the taughtCourseList usign the taughtCourse id from the section object
				TaughtCourse taughtcourse = (TaughtCourse) taughtList.List.ElementAt(0); // get the taughtCourse object from the list
				courseList.Filter("CourseID", taughtcourse.CourseID); //filter the courseList using the CourseId from the taughtCourse object
				Course course = (Course) courseList.List.ElementAt(0); // get the course object fom the couseList
				locationList.Filter("LocationID", schedule.LocationID); //filter the locationList using the location id from the element
				Location location = (Location) locationList.List.ElementAt(0); // get location object 
				instructorList.Filter("InstructorID", section.InstructorID); // filter the instructor id form the 
				Instructor instructor = (Instructor) instructorList.List.ElementAt(0); // get the instructor object form the instructorList
				table.Rows.Add(taughtcourse.CourseID, section.getID(), course.Title, location.Name, schedule.Time, schedule.Day, instructor.FirstName + " " + instructor.LastName);
				// add a row to the dataTable object with the information from the above objects
			}
			classListGrid.DataSource = table; // set the dataTable object as the dataSource of the GidView element
			classListGrid.DataBind(); // bind the data
		}
		protected void EnrollMeBtn_Click(object sender, EventArgs e)
		{
			/*
			 * This method is called when enroll me button is clicked
			 */

			/* 
			 * Declare variables and classes and instantiate them
			 */
			bool exist = false;
			bool alreadyExist = false;
			string scheduleID = "";
			GridViewRow row = classListGrid.SelectedRow; // get the selected gidview row
			string sectionId = row.Cells[2].Text.ToString(); // get the section id
			string studentID = Session["User"].ToString(); // assign the student id from User session
			Section section = new Section(sectionId);
			sectionsList.Populate(section); // populate the section object
			Student student = new Student(studentID);
			studentList.Populate(student); // populate the student object

            // get the total hours of the student
            //int totalHours = scheduleList.TotalValue("Duration", "Section", "Schedule.SectionID", "Section.SectionID", "SectionStudent", "Section.SectionID", "SectionStudent.SectionID", "StudentID", student.getID());
           
            //get the total hours of the student
            //This line calls the new total value with the less parameters
            int totalHours = scheduleList.TotalValue("Duration", "Section", "SectionID", "SectionID", "SectionStudent", "StudentID", student.getID()); 
            int sectionTotalHours = scheduleList.TotalValue("Duration", "SectionID", sectionId); // get the total hours of the section per week
			if (totalHours < 20) // check if the student registerd hours are less than 20 hours
			{

				if (totalHours + sectionTotalHours > 20)
				{  /* 
					* if the section hours and student registerd hours are more than 20 hours then display error message in a popup
					*
					*/
					ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('You can't SignUP for more than 20 hours !')", true);

				}
				else
				{

					scheduleList.Filter("SectionID", section.getID()); // filter schedual list by the sectionId taken from the section object
					foreach (Schedule schedule in scheduleList.List)
					{
						/* forEach element in the scheduleList */

						// exist = scheduleList.Exist("Section", "Schedule.SectionID", "Section.SectionID", "SectionStudent", "Section.SectionID", "SectionStudent.SectionID", "Day", schedule.Day, "Time", schedule.Time, "StudentID", student.getID()); //check if the student has a class in that day and time --  //this is the 12 parameter method 
						exist = scheduleList.Exist("Section", "SectionID", "SectionID", "SectionStudent", "Day", schedule.Day, "Time", schedule.Time, "StudentID", student.getID());//check if the student has a class in that day and time -- this is the less parameters method

						scheduleID = schedule.getID(); // get the schedule id
						while (Convert.ToInt32(schedule.Duration) > 1 && !exist)

						{
							/* 
							 * while schedual duration more than 1 and the exit var is false
							 */
							int newTime = Convert.ToInt32(schedule.Time) + 1; // get the new time by the adding 1 to the schedule time
							schedule.Time = newTime.ToString(); // assign the new time to the schedule object time

							// exist = scheduleList.Exist("Section", "Schedule.SectionID", "Section.SectionID", "SectionStudent", "Section.SectionID", "SectionStudent.SectionID", "Day", schedule.Day, "Time", schedule.Time, "StudentID", student.getID()); //check if the student has a class in that day and time --  //this is the 12 parameter method 
							exist = scheduleList.Exist("Section", "SectionID", "SectionID", "SectionStudent", "Day", schedule.Day, "Time", schedule.Time, "StudentID", student.getID());//check if the student has a class in that day and time -- this is the less parameters method

							int duration = Convert.ToInt32(schedule.Duration) - 1; // decrease the duration by 1
							schedule.Duration = duration.ToString(); // assign the new duration to the schedule object
						}

						if (exist)
						{
							/* if the exist var true make the alreadyExist var true */
							alreadyExist = true;
						}
					}

					if (alreadyExist)
					{
						/* if the alreadyExist var true display a message saying you already have class in that time in a popup */
						ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('You already have a class in that time !')", true);

					}
					else
					{
						/* else */

						sectionStudentList.Filter("SectionID", sectionId); // filter sectionstudentList by section id 
						int total = sectionStudentList.List.Count; // get the count of the students that already registerd in the section
						total = total + 1; // add one to the count 
						Schedule schedule = new Schedule(scheduleID); // create new schedule object and pass schedule id
						scheduleList.Populate(schedule); // populate schedule object
						Location location = new Location(schedule.LocationID); // create new location object and pass id from the schedule object
						locationList.Populate(location); //poulate the location object
						if (Convert.ToInt32(location.Capacity) >= total)
						{
							/* if the loccation capicty greater or equal to toatal var then add student to the section */
							SectionStudent sectionStudent = new SectionStudent(sectionId, studentID); // create new sectionStudent object
							SectionStudentList sectionStudentList = new SectionStudentList(); // create new sectionStudentList
							sectionStudentList.Add(sectionStudent); //  add the new object to the list
							ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Section Added", "alert('You have been Enrolled to this section !')", true); // show a message in a popup
						}
						else
						{
							/* else show a message that the section is already full */
							ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('The Section is Already Full !')", true);

						}


					}
				}

			}
			else
			{
				/* else show a messagw that you can signup for more than 20h in a popup */
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('You can't SignUP for more than 20 hours !')", true);

			}
		}
	}
}
