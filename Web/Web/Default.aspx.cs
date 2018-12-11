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
			if(Request.Cookies["RememberMe"] != null){
				lg_username.Text = Request.Cookies["RememberMe"].Value;
				lg_remembe.Checked = true;
				if(Request.Cookies["AccoutType"].Value == "instructor")
				{
					instructorAccount.Checked = true;

				}else if (Request.Cookies["AccoutType"].Value == "student")
				{
					studentAccount.Checked = true;
				}

			}
		}
		protected void LoginButton_Click(object sender, EventArgs e)
		{
			bool loggedin = false;
			
			 if (lg_username.Text == "" || lg_password.Text == "")
			{
				errormsg.Text = "Please Complete your account information";
				meassgaePanel.Visible = true;

			}
			else if(!instructorAccount.Checked && !studentAccount.Checked)
			{
				errormsg.Text = "Please Choose  your account type";
				meassgaePanel.Visible = true;

			}
			else if (instructorAccount.Checked && lg_username.Text!="" && lg_password.Text!="")
			{
				meassgaePanel.Visible = false;
				instructors.Filter("InstructorID", lg_username.Text.ToString());
				if (instructors.List.Count == 1)
				{
					Instructor instructor = (Instructor) instructors.List.ElementAt(0);
					instructors.Populate(instructor);
					if (instructor.Password == lg_password.Text.ToString())
					{
						Session["User"] = instructor.getID();
						loggedin = true;
					}
					else
					{
						errormsg.Text = "Wrong password, Please check your password and try again";
						meassgaePanel.Visible = true;
					}
				}
				else
				{
					errormsg.Text = "User Not Found, Please check your userId and account type and try again ";
					meassgaePanel.Visible = true;
				}
			
			}
			else if(studentAccount.Checked && lg_username.Text != "" && lg_password.Text != "")
			{
				meassgaePanel.Visible = false;

				students.Filter("StudentID", lg_username.Text);
				if (students.List.Count == 1)
				{
					Student student = (Student)students.List.ElementAt(0);
					students.Populate(student);
					if (student.Password == lg_password.Text)
					{
						Session["User"] = student.getID();
						loggedin = true;
					}
					else
					{
						errormsg.Text = "Wrong password, Please check your password and try again";
						meassgaePanel.Visible = true;
					}
				}
				else
				{
					errormsg.Text = "User Not Found, Please check your userId and account type and try again ";
					meassgaePanel.Visible = true;
				}

			}
			if(loggedin )
			{
				string id  = lg_username.Text.ToString();
				if (instructorAccount.Checked)
				{
					if (lg_remembe.Checked)
					{
						Response.Cookies["RememberMe"].Value = id;
						Response.Cookies["AccoutType"].Value = "instructor";
					}
					else
					{
						Response.Cookies["RememberMe"].Expires = DateTime.Now.AddDays(-1);
						Response.Cookies["AccoutType"].Expires = DateTime.Now.AddDays(-1);

					}
					Response.Redirect("~/instructor/MainPage.aspx");

				}
				else if (studentAccount.Checked)
				{
					if (lg_remembe.Checked)
					{
						Response.Cookies["RememberMe"].Value = id;
						Response.Cookies["AccoutType"].Value = "student";
					}
					else
					{
						Response.Cookies["RememberMe"].Expires = DateTime.Now.AddDays(-1);
						Response.Cookies["AccoutType"].Expires = DateTime.Now.AddDays(-1);
					}
					Response.Redirect("~/student/MainPage.aspx");

				}
			}
		}
		
	}
}