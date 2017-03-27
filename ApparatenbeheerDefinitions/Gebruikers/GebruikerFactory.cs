using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apparatenbeheer.Definitions {
	namespace Gebruikers {

		public static class GebruikerFactory {

			public static Gebruiker GetGebruiker(GebruikerBuilder builder) => builder.BuildGebruiker();

		}

	}
}