using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Apparatenbeheer.Definitions.Gebruikers;

namespace ApparatenbeheerWeb {
	public partial class WerknemerSite : System.Web.UI.MasterPage {
		protected void Page_Load(object sender, EventArgs e) {

			Gebruiker gebruiker = (Gebruiker)Session["Gebruiker"];

			if (gebruiker == null)
				Server.Transfer("~/Account/Login.aspx");
			else if (!(gebruiker is Apparatenbeheer.Definitions.Gebruikers.Werknemer))
				Server.Transfer("~/Account/Login.aspx");

		}
	}
}