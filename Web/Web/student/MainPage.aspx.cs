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

				string stId = Session["User"].ToString();
				Student student = new Student(stId);
				StudentList students = new StudentList();
				students.Populate(student);
				name.Text = student.FirstName + " " + student.LastName;
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
	}
}