using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apparatenbeheer.Business.Repositories;
using Apparatenbeheer.Definitions.Apparaten;
using Apparatenbeheer.Definitions.Gebruikers;

namespace Apparatenbeheer.Business.Extensions {

	internal static class GebruikerExtension {

		public static Gebruiker Login(this Gebruiker gebruiker, string password)
			=> gebruiker.CheckPassword(password) ? gebruiker : null;

		public static List<Apparaat> GetApparaten(this Gebruiker gebruiker) {

			ApparaatRepository repository = ApparaatRepository.GetInstance();
			return repository.FindAll(a => a.CurrentGebruiker == gebruiker);

		}

		public static decimal GetTotaleWaarde(this Gebruiker gebruiker)
			=> gebruiker.GetApparaten().ConvertAll(a => a.Prijs).Sum();

	}

}
