using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apparatenbeheer.Definitions.Gebruikers;

namespace Apparatenbeheer.Business.Repositories {

	internal class GebruikerRepository : List<Gebruiker> {

		private static GebruikerRepository _instance;
		private GebruikerRepository() : base() { }

		public static GebruikerRepository GetInstance() 
			=> _instance ?? (_instance = new GebruikerRepository());

	}

}
