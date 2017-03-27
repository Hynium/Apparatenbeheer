using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apparatenbeheer.Definitions {
	namespace Gebruikers {

		public class ICTVerantwoordelijke : Gebruiker {

			sealed public override string Role => "ICTVerantwoordelijke";
			public ICTVerantwoordelijke(int? id, string naam, string username, string password)
				: base(id, naam, username, password) { }

		}

	}
}
