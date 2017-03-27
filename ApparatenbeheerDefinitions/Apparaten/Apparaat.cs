using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apparatenbeheer.Definitions.Apparaten {

	public class Apparaat {

		public int? Id { get; set; }
		public string Code { get; private set; }
		public string Omschrijving { get; private set; }
		public ApparaatType Type { get; private set; }
		public decimal Prijs { get; private set; }

		public Gebruikers.Gebruiker CurrentGebruiker { get; set; }

		public Apparaat(int? id, string code, string omschrijving, ApparaatType type, decimal prijs) {
			Id = id;
			Code = code;
			Omschrijving = omschrijving;
			Type = type;
			Prijs = prijs;
		}

        public void Toewijzen(Gebruikers.Gebruiker gebruiker) {
            if (CurrentGebruiker != null)
                throw new Exception("Apparaat is al toegewezen.");
            CurrentGebruiker = gebruiker;
        }
        public void Afwijzen() => CurrentGebruiker = null;

	}

}
