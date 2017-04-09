using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apparatenbeheer.Business.Repositories;
using Apparatenbeheer.Definitions.Apparaten;
using Apparatenbeheer.Definitions.Gebruikers;

namespace Apparatenbeheer.Business.Extensions {
    public static class WerknemerExtension {

        public static Aanvraag ApparaatAanvragen(this Werknemer werknemer, Gebruiker apparaatOntvanger, ApparaatType type, ICTVerantwoordelijke verantwoordelijke) {
            Aanvraag aanvraag = new Aanvraag(null, werknemer, apparaatOntvanger, verantwoordelijke, type);
			return aanvraag;
        }

    }
}
