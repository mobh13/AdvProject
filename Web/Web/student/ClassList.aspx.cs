﻿using System;
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
		protected SectionList sectionsList;
		protected TaughtCourseList taughtList;
		protected CourseList courseList;
		protected ScheduleList scheduleList;
		protected InstructorList instructorList;
		protected LocationList locationList;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["User"] != null && Session["Account"].ToString() == "Student")
			{
				sectionsList = new SectionList();
				taughtList = new TaughtCourseList();
				locationList = new LocationList();
				courseList = new CourseList();
				scheduleList = new ScheduleList();
				scheduleList.Populate();
				instructorList = new InstructorList();
				GenerateGridData();

			}
			else if (Session["User"] != null && Session["Account"].ToString() != "Student")
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
		protected void GenerateGridData()
		{
			DataTable table = new DataTable();
			table.Columns.Add("Course Id");
			table.Columns.Add("Section Id");
			table.Columns.Add("Course Title");
			table.Columns.Add("Location");
			table.Columns.Add("Time");
			table.Columns.Add("Date");
			table.Columns.Add("Instructor Name");
			foreach (Schedule schedule in scheduleList.List)
			{

				sectionsList.Filter("SectionID", schedule.SectionID);
				Section section = (Section)sectionsList.List.ElementAt(0);

				taughtList.Filter("TaughtCourseID", section.TaughtCourseID);
				TaughtCourse taughtcourse = (TaughtCourse)taughtList.List.ElementAt(0);
				taughtList.Populate(taughtcourse);
				courseList.Filter("CourseID", taughtcourse.CourseID);
				Course course = (Course)courseList.List.ElementAt(0);
				courseList.Populate(course);
				locationList.Filter("LocationID", schedule.LocationID);
				Location location = (Location)locationList.List.ElementAt(0);
				locationList.Populate(location);
				instructorList.Filter("InstructorID", section.InstructorID);
				Instructor instructor = (Instructor)instructorList.List.ElementAt(0);
				instructorList.Populate(instructor);
				table.Rows.Add(taughtcourse.CourseID, section.getID(), course.Title, location.Name, schedule.Time, schedule.Day, instructor.FirstName + " " + instructor.LastName);

			}
			classListGrid.DataSource = table;
			classListGrid.DataBind();
		}
		protected void EnrollMeBtn_Click(object sender, EventArgs e)
		{
			bool alreadyExist = false;
			GridViewRow row = classListGrid.SelectedRow;
			string sectionId = row.Cells[2].Text.ToString();
			string studentID = Session["User"].ToString();
			Section section = new Section(sectionId);
			sectionsList.Populate(section);
			Student student = new Student(studentID);
			StudentList studentList = new StudentList();
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

						bool exist = scheduleList.Exist("Section", "Schedule.SectionID", "Section.SectionID", "SectionStudent", "Section.SectionID", "SectionStudent.SectionID", "Day", schedule.Day, "Time", schedule.Time, "StudentID", student.getID());
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
						SectionStudent sectionStudent = new SectionStudent(sectionId, studentID);
						SectionStudentList sectionStudentList = new SectionStudentList();
						sectionStudentList.Add(sectionStudent);
						ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Section Added", "alert('You have been Enrolled to this section !')", true);

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