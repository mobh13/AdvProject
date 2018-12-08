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
			string inId = Session["User"].ToString();
			Instructor instructor = new Instructor(inId);
			InstructorList instructors = new InstructorList();
			instructors.Populate(instructor);
			name.Text = instructor.FirstName + " " + instructor.LastName;
		}
	}
}