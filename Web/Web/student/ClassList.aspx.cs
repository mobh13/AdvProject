using System;
using System.Collections.Generic;
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
		protected TaughtCoursesList taughtList;
		protected CourseList courseList;
		protected ScheduleList scheduleList;
		protected InstructorList instructorList;
		protected LocationList locationList;

		protected void Page_Load(object sender, EventArgs e)
		{
			bool alreadyExist = false; 
			sectionsList = new SectionList();
			taughtList = new TaughtCoursesList();
			locationList = new LocationList();
			courseList = new CourseList();
			scheduleList = new ScheduleList();
			scheduleList.Populate();
			instructorList = new InstructorList();
			if (Request.QueryString["Enr"] !=null && Request.QueryString["Enr"] != "")
			{
				string sectionId = Request.QueryString["Enr"].ToString();
				string studentID = Session["User"].ToString();
				Section section = new Section(sectionId);
				sectionsList.Populate(section);
				Student student = new Student(studentID);
				StudentList studentList = new StudentList();
				studentList.Populate(student);
				int totalHours = scheduleList.TotalValue("Duration","Section","Schedule.SectionID","Section.SectionID","SectionStudent","Section.SectionID","SectionStudent.SectionID","StudentID", student.getID());
				int sectionTotalHours = scheduleList.TotalValue("Duration", "SectionID", sectionId);
				if (totalHours < 20)
				{

					if(totalHours + sectionTotalHours > 20)
					{
						ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Error", "alert('You can't SignUP for more than 20 hours !')", true);

					}
					else
					{
						scheduleList.Filter("SectionID", section.getID());
						foreach(Schedule schedule in scheduleList.List)
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
}