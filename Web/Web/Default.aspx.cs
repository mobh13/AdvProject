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
		/* 
		 declare class Variables to be used in this page
		*/
		protected StudentList students;
		protected InstructorList instructors;
		protected void Page_Load(object sender, EventArgs e)
		{
			/*
			 instantiate classes when the page loads 
			 */
			students = new StudentList();
			instructors = new InstructorList();
		}
		protected void LoginButton_Click(object sender, EventArgs e)
		{
			/*
			 * when the button login clicked run this code
			 * 
			 */

			if (lg_username.Text == "" || lg_password.Text == "")
			{
				/*
				 * if the username or password are empty then show error message
				 */
				errormsg.Text = "Please Complete your account information";
				meassgaePanel.Visible = true;

			}
			else if (!instructorAccount.Checked && !studentAccount.Checked)
			{
				/* 
				 * if non of the account type radio buttons checked then show error message
				 */
				errormsg.Text = "Please Choose  your account type";
				meassgaePanel.Visible = true;

			}
			else if (instructorAccount.Checked && lg_username.Text != "" && lg_password.Text != "")
			{
				/* 
				 * if the user checked the instructor and the username and password aren't empty then check for information and do the login
				 */

				meassgaePanel.Visible = false; // hide the message panel
				instructors.Filter("InstructorID", lg_username.Text.ToString()); // filter the instructors list with the id the user filed
				if (instructors.List.Count == 1) // if the id is correct the instructors list count should be 1
				{
					Instructor instructor = (Instructor) instructors.List.ElementAt(0); // get the instructor object from the list
					instructors.Populate(instructor); // populate the instructor 
					if (instructor.Password == lg_password.Text.ToString()) // if the password user filled is the same as the instructor object
					{
						Session["User"] = instructor.getID(); // create new session called User with the value of the id of the instructor
						Session["Account"] = "Instructor"; // create new Session called Account with  instructor as value this to make sure that the user dosen't visit pages not allwoed for him/her to visit
						Response.Redirect("~/instructor/MainPage.aspx"); // redirect to main page of the instructor

					}
					else
					{
						/* 
						 * else show error message "password Wrong"
						 */
						errormsg.Text = "Wrong password, Please check your password and try again";
						meassgaePanel.Visible = true;
					}
				}
				else
				{
					/* 
					 * else show error message "User not found"
					 */
					errormsg.Text = "User Not Found, Please check your userId and account type and try again ";
					meassgaePanel.Visible = true;
				}

			}
			else if (studentAccount.Checked && lg_username.Text != "" && lg_password.Text != "")
			{
				/* 
				 * if the user checked the student and the username and password aren't empty then check for information and do the login
				 */
				meassgaePanel.Visible = false; // hide the message panel
				students.Filter("StudentID", lg_username.Text); // filter the students list with the id the user filed
				if (students.List.Count == 1) // if the id is correct the students list count should be 1
				{
					Student student = (Student) students.List.ElementAt(0); // get the student object from the list
					students.Populate(student); // populate the student 
					if (student.Password == lg_password.Text)// if the password user filled is the same as the student object
					{
						Session["User"] = student.getID(); // create new session called User with the value of the id of the student
						Session["Account"] = "Student"; // create new Session called Account with student as value this to make sure that the user dosen't visit pages not allwoed for him/her to visit
						Response.Redirect("~/student/MainPage.aspx"); // Redirect to student's main page
					}
					else
					{
						/* 
						 * else show error message "password Wrong"
						 */
						errormsg.Text = "Wrong password, Please check your password and try again";
						meassgaePanel.Visible = true;
					}
				}
				else
				{
					/* 
					 * else show error message "User not found"
					 */
					errormsg.Text = "User Not Found, Please check your userId and account type and try again ";
					meassgaePanel.Visible = true;
				}

			}

		}

	}
}