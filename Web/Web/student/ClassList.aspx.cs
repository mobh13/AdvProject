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
			bool exist = false;
			bool alreadyExist = false;
			string scheduleID = "";
			GridViewRow row = classListGrid.SelectedRow;
			string sectionId = row.Cells[2].Text.ToString();
			string studentID = Session["User"].ToString();
			Section section = new Section(sectionId);
			sectionsList.Populate(section);
			Student student = new Student(studentID);

			studentList.Populate(student);
			int totalHours = scheduleList.TotalValue("Duration", "Section", "Schedule.SectionID", "Section.SectionID", "SectionStudent", "Section.SectionID", "SectionStudent.SectionID", "StudentID", student.getID());
			int sectionTotalHours = scheduleList.TotalValue("Duration", "SectionID", sectionId);
			if (totalHours < 20)
			{

				if (totalHours + sectionTotalHours > 20)
				{
					ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('You can't SignUP for more than 20 hours !')", true);

				}
				else
				{
					scheduleList.Filter("SectionID", section.getID());
					foreach (Schedule schedule in scheduleList.List)
					{
						exist = scheduleList.Exist("Section", "Schedule.SectionID", "Section.SectionID", "SectionStudent", "Section.SectionID", "SectionStudent.SectionID", "Day", schedule.Day, "Time", schedule.Time, "StudentID", student.getID());
						scheduleID = schedule.getID();
						while (Convert.ToInt32(schedule.Duration) > 1 && !exist)

						{
							int newTime = Convert.ToInt32(schedule.Time) + 1;
							schedule.Time = newTime.ToString();
							exist = scheduleList.Exist("Section", "Schedule.SectionID", "Section.SectionID", "SectionStudent", "Section.SectionID", "SectionStudent.SectionID", "Day", schedule.Day, "Time", schedule.Time, "StudentID", student.getID());
							int duration = Convert.ToInt32(schedule.Duration) - 1;
							schedule.Duration = duration.ToString();
						}

						if (exist)
						{
							alreadyExist = true;
						}
					}

					if (alreadyExist)
					{
						ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('You already have a class in that time !')", true);

					}
					else
					{
						sectionStudentList.Filter("SectionID", sectionId);
						int total = sectionStudentList.List.Count;
						total = total + 1;
						Schedule schedule = new Schedule(scheduleID);
						scheduleList.Populate(schedule);
						Location location = new Location(schedule.LocationID);
						locationList.Populate(location);
						if (Convert.ToInt32(location.Capacity) >= total)
						{
							SectionStudent sectionStudent = new SectionStudent(sectionId, studentID);
							SectionStudentList sectionStudentList = new SectionStudentList();
							sectionStudentList.Add(sectionStudent);
							ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Section Added", "alert('You have been Enrolled to this section !')", true);
						}
						else
						{
							ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('The Section is Already Full !')", true);

						}


					}
				}

			}
			else
			{
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('You can't SignUP for more than 20 hours !')", true);

			}
		}
	}
}