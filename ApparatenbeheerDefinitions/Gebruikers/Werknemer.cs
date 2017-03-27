using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apparatenbeheer.Definitions {
	namespace Gebruikers {

		public class Werknemer : Gebruiker {

			sealed public override string Role => "Werknemer";
			public Werknemer(int? id, string naam, string username, string password)
				: base(id, naam, username, password) { }

		}

	}
}
