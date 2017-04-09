using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Apparatenbeheer.Definitions.Gebruikers;

namespace ApparatenbeheerWeb {
	public partial class _default : System.Web.UI.Page {

		protected void Page_Load(object sender, EventArgs e) {

			Gebruiker gebruiker = (Gebruiker)Session["Gebruiker"];
			if (gebruiker != null) {
				switch (gebruiker.Role) {

					case "Werknemer":
						Response.Redirect("~/Werknemer/WerknemerProfiel.aspx");
						break;
					case "ICTVerantwoordelijke":
						Response.Redirect("~/ICTVerantwoordelijke/ICTVerantwoordelijkeProfiel.aspx");
						break;

				}
			}

		}

	}
}