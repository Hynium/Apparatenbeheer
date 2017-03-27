using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apparatenbeheer.Definitions {
	namespace Gebruikers {

		public class ICTVerantwoordelijkeBuilder : GebruikerBuilder {

			public ICTVerantwoordelijkeBuilder(int? id, string naam, string username, string password) {
				Product = new ICTVerantwoordelijke(id, naam, username, password);
			}

		}

	}
}