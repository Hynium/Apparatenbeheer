using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apparatenbeheer.Definitions {
	namespace Gebruikers {

		public abstract class GebruikerBuilder {

			protected Gebruiker Product { get; set; }
			internal Gebruiker BuildGebruiker() => Product;

		}

	}
}