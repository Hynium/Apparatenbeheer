using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using Apparatenbeheer.Business;
using Apparatenbeheer.Definitions.Gebruikers;

namespace ApparatenbeheerWeb.Account {
	public partial class Login : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void LoginForm_Authenticate(object sender, AuthenticateEventArgs e) {

			Controller controller = (Controller)Session["Controller"];
			Gebruiker gebruiker = controller.Login(LoginForm.UserName, LoginForm.Password);

			if (gebruiker != null) {
				Session["Gebruiker"] = gebruiker;
				FormsAuthentication.RedirectFromLoginPage(LoginForm.UserName, false);
			} else
				LoginForm.FailureText = "Er was een fout bij het aanmelden.";

		}
	}
}