using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Apparatenbeheer.Business;
using Apparatenbeheer.Definitions.Apparaten;

namespace ApparatenbeheerWeb.ICTVerantwoordelijke {
	public partial class NieuwApparaat : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {

		}

		protected void btnToevoegen_Click(object sender, EventArgs e) {

			Controller controller = (Controller)Session["Controller"];

			try {
				controller.AddApparaat(code.Value, omschrijving.Value, DropDownList1.SelectedValue, Convert.ToDecimal(prijs.Value));
			} catch(Exception ex) {
				foutboodschap.Text = ex.Message;
			}

		}
	}
}