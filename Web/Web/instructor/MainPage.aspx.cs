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

				string inId = Session["User"].ToString();
				Instructor instructor = new Instructor(inId);
				InstructorList instructors = new InstructorList();
				instructors.Populate(instructor);
				name.Text = instructor.FirstName + " " + instructor.LastName;
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
	}
}