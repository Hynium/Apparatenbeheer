using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Apparatenbeheer.Business;

namespace ApparatenbeheerWeb {
	public partial class Site : System.Web.UI.MasterPage {

		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e) {

			Controller controller = (Controller)Session["Controller"];
			controller.Logout();

			Session["Gebruiker"] = null;

			FormsAuthentication.SignOut();
			Response.Redirect("~/Account/Login.aspx");

		}

	}
}