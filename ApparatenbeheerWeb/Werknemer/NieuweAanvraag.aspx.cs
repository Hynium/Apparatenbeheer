using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Apparatenbeheer.Business;
using Apparatenbeheer.Definitions.Apparaten;

namespace ApparatenbeheerWeb.Werknemer {
	public partial class NieuweAanvraag : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void btnAanvragen_Click(object sender, EventArgs e) {

			Controller controller = (Controller)Session["Controller"];

			try {
				controller.ApparaatAanvragen(DropDownList1.SelectedValue, ontvanger.Value, verantwoordelijke.Value != "" ? verantwoordelijke.Value : null);
			} catch (Exception ex) {
				foutboodschap.Text = ex.Message;
			}

		}
	}
}