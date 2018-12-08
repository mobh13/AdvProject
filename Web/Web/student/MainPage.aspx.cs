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
			string stId = Session["User"].ToString();
			Student student = new Student(stId);
			StudentList students = new StudentList();
			students.Populate(student);
			name.Text = student.FirstName + " " + student.LastName;
		}
	}
}