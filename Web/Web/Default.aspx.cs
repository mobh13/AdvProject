using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;

namespace Web
{
	public partial class _Default : Page
	{
		StudentList students;
		InstructorList instructors;
		protected void Page_Load(object sender, EventArgs e)
		{
			students = new StudentList();
			instructors = new InstructorList();
		}
		protected void LoginButton_Click(object sender, EventArgs e)
		{
			bool loggedin = false;
			if(!instructorAccount.Checked && !studentAccount.Checked)
			{
				lg_username.Text = "error";

			}
			else if (instructorAccount.Checked && lg_username.Text!="" && lg_password.Text!="")
			{
				instructors.Filter("InstructorID", lg_username.Text);
				if (instructors.List.Count == 1)
				{
					Instructor instructor = (Instructor) instructors.List.ElementAt(0);
					instructors.Populate(instructor);
					if (instructor.Password == lg_password.Text)
					{
						Session["User"] = instructor;
						loggedin = true;
					}
					else
					{

					}
				}
				else
				{

				}
			
			}
			else if(studentAccount.Checked && lg_username.Text != "" && lg_password.Text != "")
			{
				students.Filter("StudentID", lg_username.Text);
				if (students.List.Count == 1)
				{
					Student student = (Student)instructors.List.ElementAt(0);
					students.Populate(student);
					if (student.Password == lg_password.Text)
					{
						Session["User"] = student;
						loggedin = true;
					}
					else
					{

					}
				}

			}
			if(loggedin )
			{
				if (lg_remembe.Checked)
				{
					
				}
			}
		}
		
	}
}