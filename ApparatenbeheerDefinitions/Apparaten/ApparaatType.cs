using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apparatenbeheer.Definitions.Apparaten {

	public struct ApparaatType {

		public string Omschrijving { get; private set; }
		public ApparaatType(string omschrijving) {
			Omschrijving = omschrijving;
		}

		public override int GetHashCode() => base.GetHashCode();
		public override bool Equals(object obj) 
			=> ((ApparaatType)obj).Omschrijving == Omschrijving;

	}

}
