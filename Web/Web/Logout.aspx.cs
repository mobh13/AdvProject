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
			

			if (Session["User"] != null)
			{
				Session.Abandon();
				Response.Redirect("~/");
			}
			else
			{
				Response.Write("Error please log in before trying to logout..!");
			}
		}
	}
}