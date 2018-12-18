using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
namespace Web.student
{
	public partial class MainPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["User"] != null && Session["Account"].ToString() == "Student")
			{
				/*
				 * check if the user session exist and Account session value is student
				 */
				string stId = Session["User"].ToString(); // get the user id from the session user
				Student student = new Student(stId); // declare and instantiate new student object
				StudentList students = new StudentList(); //declare and instantiate new studentList object
				students.Populate(student); // Populate the student object 
 				name.Text = student.FirstName + " " + student.LastName; // assign the first and last name to the name lable
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
	}
}