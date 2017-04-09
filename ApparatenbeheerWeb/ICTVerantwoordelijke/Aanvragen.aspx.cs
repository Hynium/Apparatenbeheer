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
	public partial class Aanvragen : System.Web.UI.Page {

		private void UpdateTable() {

			Controller controller = (Controller)Session["Controller"];

			DataTable dt = new DataTable("aanvragen");
			dt.Columns.Add("id", typeof(int));
			dt.Columns.Add("type", typeof(string));
			dt.Columns.Add("status", typeof(string));

			foreach (Aanvraag a in controller.GetAanvragen()) {

				DataRow row = dt.NewRow();
				row["id"] = a.Id;
				row["type"] = a.Type.Omschrijving;
				row["status"] = a.Status.ToString();

				dt.Rows.Add(row);

			}

			AanvragenGrid.DataSource = dt;
			AanvragenGrid.DataBind();

		}

		protected void Page_Load(object sender, EventArgs e) {

			UpdateTable();
			commentaarForm.Visible = false;

		}

		protected void AanvragenGrid_SelectedIndexChanged(object sender, EventArgs e) {

			Controller controller = (Controller)Session["Controller"];
			Aanvraag aanvraag = controller.GetAanvragen().Find(a => a.Id == (int)AanvragenGrid.SelectedDataKey[0]);

			DataTable dt = new DataTable("selectedAanvraag");
			dt.Columns.Add("aanvrager", typeof(string));
			dt.Columns.Add("ontvanger", typeof(string));
			dt.Columns.Add("ictverantwoordelijke", typeof(string));
			dt.Columns.Add("status", typeof(string));

			DataRow row = dt.NewRow();
			row["aanvrager"] = aanvraag.Aanvrager.Naam;
			row["ontvanger"] = aanvraag.Ontvanger.Naam;
			if (aanvraag.Verantwoordelijke != null)
				row["ictverantwoordelijke"] = aanvraag.Verantwoordelijke.Naam;
			row["status"] = aanvraag.Status.ToString();
			dt.Rows.Add(row);

			SelectedApparaatGrid.DataSource = dt;
			SelectedApparaatGrid.DataBind();

			commentaar.Value = aanvraag.Commentaar;
			commentaarForm.Visible = true;

		}

		protected void btnAccepteren_Click(object sender, EventArgs e) {

			Controller controller = (Controller)Session["Controller"];
			Aanvraag aanvraag = controller.GetAanvragen().Find(a => a.Id == (int)AanvragenGrid.SelectedDataKey[0]);

			controller.AcceptAanvraag(aanvraag, commentaar.Value);

			UpdateTable();

		}

		protected void btnWeigeren_Click(object sender, EventArgs e) {

			Controller controller = (Controller)Session["Controller"];
			Aanvraag aanvraag = controller.GetAanvragen().Find(a => a.Id == (int)AanvragenGrid.SelectedDataKey[0]);

			controller.DeclineAanvraag(aanvraag, commentaar.Value);

			UpdateTable();

		}
	}
}