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
		protected SectionList sectionsList;
		protected TaughtCoursesList taughtList;
		protected CourseList courseList;
		protected ScheduleList scheduleList;
		protected InstructorList instructorList;
		protected LocationList locationList;
		protected string print;
		protected string InsId;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["User"] != null && Session["Account"].ToString() == "Instructor")
			{

				sectionsList = new SectionList();
				taughtList = new TaughtCoursesList();
				locationList = new LocationList();
				courseList = new CourseList();
				scheduleList = new ScheduleList();
				scheduleList.Populate();
				instructorList = new InstructorList();
				InsId = Session["User"].ToString();
				GenerateAllClassessGridData();
				GenerateMyClassessGridData();
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
		protected void GenerateAllClassessGridData()
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
				TaughtCourses taughtcourse = (TaughtCourses)taughtList.List.ElementAt(0);
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
				table.Rows.Add(taughtcourse.CourseID, section.getID(), course.Title, location.Name, schedule.Time, schedule.Day);

			}
			allclassListGrid.DataSource = table;
			allclassListGrid.DataBind();
		}
		protected void GenerateMyClassessGridData()
		{
			DataTable table = new DataTable();
			table.Columns.Add("Course Id");
			table.Columns.Add("Section Id");
			table.Columns.Add("Course Title");


			sectionsList.Filter("InstructorID", InsId);
			foreach (Section section in sectionsList.List)
			{

				taughtList.Filter("TaughtCourseID", section.TaughtCourseID);
				TaughtCourses taughtcourse = (TaughtCourses)taughtList.List.ElementAt(0);
				taughtList.Populate(taughtcourse);
				courseList.Filter("CourseID", taughtcourse.CourseID);
				Course course = (Course)courseList.List.ElementAt(0);
				courseList.Populate(course);

				table.Rows.Add(taughtcourse.CourseID, section.getID(), course.Title);
			}

			myclassListGrid.DataSource = table;
			myclassListGrid.DataBind();
		}
		protected void MyClasses_CheckedChanged(object sender, EventArgs e)
		{

		}
		protected void MarkClass_Click(object sender, EventArgs e)
		{
			GridViewRow row = myclassListGrid.SelectedRow;
			string classId = row.Cells[2].Text;
			Response.Redirect("MarkClass?cls=" + classId);
		}
	}
}