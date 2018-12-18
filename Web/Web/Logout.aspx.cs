using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
	public partial class Logout : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			/*
			 In this code we are checking if there are a session called User to make sure that the user
			 is signed in and to prevent an excuption rasing. If the session exist then abandon the sessions.
			 
			 */
			if (Session["User"] != null) // if Session User Exist
			{
				Session.Abandon(); // Abandon sessions
				Response.Redirect("~/"); // Redirect to Main page (login)
			}
			else
			{
				Response.Write("Error please log in before trying to logout..!"); // Show Error Meesage that the user needs to sign in.
			}
		}
	}
}