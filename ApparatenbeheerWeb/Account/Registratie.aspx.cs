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
	public partial class Registratie : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void btnRegistreren_Click(object sender, EventArgs e) {

			if(paswoord.Value != paswoordHerhaling.Value) {
				foutboodschap.Text = "Het wachtwoord komt niet overeen met de herhaling";
				return;
			}

			try {

				Controller controller = (Controller)Session["Controller"];
				Gebruiker gebruiker = controller.RegisterGebruiker($"{voornaam.Value} {achternaam.Value}",
					gebruikersnaam.Value, paswoord.Value, GebruikerRole.Werknemer);

				FormsAuthentication.RedirectFromLoginPage(gebruiker.Username, false);

			} catch(Exception ex) {
				foutboodschap.Text = ex.Message;
			}
				

		}
	}
}