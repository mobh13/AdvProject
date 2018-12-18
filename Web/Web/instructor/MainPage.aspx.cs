using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB;
namespace Web.instructor
{
	public partial class MainPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (Session["User"] != null && Session["Account"].ToString() == "Instructor")
			{
				/*
			 * check if the user session exist and Account session value is Instructor
			 */
				string inId = Session["User"].ToString();// get the user id from the session user
				Instructor instructor = new Instructor(inId);  // declare and instantiate new instructor object
				InstructorList instructors = new InstructorList(); //declare and instantiate new InstructorList object
				instructors.Populate(instructor);// Populate the  object 
				name.Text = instructor.FirstName + " " + instructor.LastName;// assign the first and last name to the name lable
			}
			else if (Session["User"] != null && Session["Account"].ToString() != "Instructor")
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