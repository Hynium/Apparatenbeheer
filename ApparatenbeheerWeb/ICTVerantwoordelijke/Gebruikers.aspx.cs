using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Apparatenbeheer.Business;
using Apparatenbeheer.Definitions.Gebruikers;

namespace ApparatenbeheerWeb.ICTVerantwoordelijke {
	public partial class Gebruikers : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

			Controller controller = (Controller)Session["Controller"];

			DataTable dt = new DataTable("gebruikers");
			dt.Columns.Add("id", typeof(int));
			dt.Columns.Add("gebruikersnaam", typeof(string));
			dt.Columns.Add("naam", typeof(string));

			foreach(Gebruiker g in controller.GetGebruikers()) {

				DataRow row = dt.NewRow();
				row["id"] = g.Id;
				row["gebruikersnaam"] = g.Username;
				row["naam"] = g.Naam;

				dt.Rows.Add(row);

			}

			GebruikerGrid.DataSource = dt;
			GebruikerGrid.DataBind();

		}
	}
}