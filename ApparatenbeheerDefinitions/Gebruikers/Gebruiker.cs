using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apparatenbeheer.Definitions {
	namespace Gebruikers {

		public abstract class Gebruiker {

			public int? Id { get; set; }
			public string Naam { get; private set; }
			public string Username { get; private set; }
			public string Password { get; private set; }

			public abstract string Role { get; }

			public Gebruiker(int? id, string naam, string username, string password) {
				Id = id;
				Naam = naam;
				Username = username;

				Password = password;
			}

			public bool CheckPassword(string password) => password == Password;

		}

	}
}
