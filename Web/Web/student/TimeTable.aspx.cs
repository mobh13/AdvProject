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
				id = Session["User"].ToString();
				scheduleList = new ScheduleList();
				SectionList = new SectionList();
				SectionStudentList = new SectionStudentList();
				taughtCoursesList = new TaughtCourseList();
				courseList = new CourseList();
				SectionStudentList.Filter("StudentID", id);
				GenerateGridView();

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
		protected void AddToGridByDayAndTime(Section section , Course course , Schedule schedule)
		{

			string textToDispaly = section.getID() + " - " + course.getID() + " - " + course.Title;
			switch (schedule.Day)
			{
				case "Saturday":

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
		protected void GenerateGridView()
		{
			DataTable table = new DataTable();
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
			table.Rows.Add("4","", "", "", "", "", "", "");
			table.Rows.Add("5","", "", "", "", "", "", "");
			timeTableGridView.DataSource = table;
			timeTableGridView.DataBind();
			foreach(SectionStudent sectionStudent in SectionStudentList.List)
			{
				Section section = new Section(sectionStudent.getID());
				SectionList.Populate(section);
				TaughtCourse taught = new TaughtCourse(section.TaughtCourseID);
				taughtCoursesList.Populate(taught);
				Course course = new Course(taught.CourseID);
				courseList.Populate(course);
				
				scheduleList.Filter("SectionID", sectionStudent.getID());
				foreach (Schedule schedule in scheduleList.List)
				{
					AddToGridByDayAndTime(section, course, schedule);
					while (Convert.ToInt32( schedule.Duration) > 1)
					{
						int newTime = Convert.ToInt32(schedule.Time) + 1;
						schedule.Time = newTime.ToString();
						AddToGridByDayAndTime(section, course, schedule);
						int duration = Convert.ToInt32(schedule.Duration) - 1;
						schedule.Duration = duration.ToString();
					}



				}
			}
		}
	}
}