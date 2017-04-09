using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Apparatenbeheer.Business;
using Apparatenbeheer.Definitions.Apparaten;

namespace ApparatenbeheerWeb.ICTVerantwoordelijke {
	public partial class Apparaten : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

			Controller controller = (Controller)Session["Controller"];

			DataTable dt = new DataTable("apparaten");
			dt.Columns.Add("id", typeof(int));
			dt.Columns.Add("type", typeof(string));
			dt.Columns.Add("code", typeof(string));
			dt.Columns.Add("omschrijving", typeof(string));
			dt.Columns.Add("prijs", typeof(decimal));
			dt.Columns.Add("gebruiker", typeof(string));

			foreach (Apparaat a in controller.GetAllApparaten()) {

				DataRow row = dt.NewRow();
				row["id"] = a.Id;
				row["type"] = a.Type.Omschrijving;
				row["code"] = a.Code;
				row["omschrijving"] = a.Omschrijving;
				row["prijs"] = a.Prijs;
				if (a.CurrentGebruiker != null)
					row["gebruiker"] = a.CurrentGebruiker.Username;

				dt.Rows.Add(row);

			}

			ApparatenGrid.DataSource = dt;
			ApparatenGrid.DataBind();

		}

	}
}