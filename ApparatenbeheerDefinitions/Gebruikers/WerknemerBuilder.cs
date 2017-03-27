using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apparatenbeheer.Definitions {
	namespace Gebruikers {

		public class WerknemerBuilder : GebruikerBuilder {

			public WerknemerBuilder(int? id, string naam, string username, string password) {
				Product = new Werknemer(id, naam, username, password);
			}

		}

	}
}