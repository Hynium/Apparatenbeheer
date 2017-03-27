using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apparatenbeheer.Business.Repositories;
using Apparatenbeheer.Definitions.Apparaten;
using Apparatenbeheer.Definitions.Gebruikers;

namespace Apparatenbeheer.Business.Extensions {
    internal static class ICTVerantwoordelijkeExtension {

        public static Tuple<Aanvraag, Apparaat> AcceptAanvraag(this ICTVerantwoordelijke verantwoordelijke, Aanvraag aanvraag, string commentaar) {
            
            if (aanvraag.Verantwoordelijke != null && aanvraag.Verantwoordelijke != verantwoordelijke)
                throw new Exception("Je kan dit niet uitvoeren.");

            Apparaat apparaat = ApparaatRepository.GetInstance().Find(a => a.Type.Omschrijving == aanvraag.Type.Omschrijving && a.CurrentGebruiker == null);

			if (apparaat == null)
				throw new Exception("Geen apparaat gevonden met criteria.");

            apparaat.Toewijzen(aanvraag.Ontvanger);

            aanvraag.SetStatus(AanvraagStatus.Closed, $"{verantwoordelijke.Username} - Accepted: {commentaar}");
			return new Tuple<Aanvraag, Apparaat>(aanvraag, apparaat);

        }

        public static Aanvraag DeclineAanvraag(this ICTVerantwoordelijke verantwoordelijke,Aanvraag aanvraag, string commentaar) {

            if (aanvraag.Verantwoordelijke != null && aanvraag.Verantwoordelijke != verantwoordelijke)
                throw new Exception("Je kan dit niet uitvoeren.");

            aanvraag.SetStatus(AanvraagStatus.Closed, $"{verantwoordelijke.Username} - Declined: {commentaar}");
			return aanvraag;

        }

        public static Aanvraag AanvraagToewijzen(this ICTVerantwoordelijke verantwoordelijke, Aanvraag aanvraag, ICTVerantwoordelijke toegewezen) {
            
            if (aanvraag.Verantwoordelijke != null && aanvraag.Verantwoordelijke != verantwoordelijke)
                throw new Exception("Je kan dit niet uitvoeren.");

            aanvraag.Toewijzen(toegewezen);
			return aanvraag;

        }

        public static Apparaat ApparaatToewijzen(this ICTVerantwoordelijke verantwoordelijke, Apparaat apparaat, Gebruiker gebruiker) {
            
            if (apparaat.CurrentGebruiker != null)
                throw new Exception("Apparaat is al toegewezen.");
            apparaat.Toewijzen(gebruiker);
			return apparaat;

        }

        public static Apparaat ApparaatAfwijzen(this ICTVerantwoordelijke verantwoordelijke, Apparaat apparaat) {
            
            apparaat.Afwijzen();
			return apparaat;

        }

        public static Gebruiker NewAccount(string naam, string username, string password, GebruikerRole rol) {

            GebruikerBuilder builder;

            switch (rol) {
                case GebruikerRole.Werknemer:
                    builder = new WerknemerBuilder(GebruikerRepository.GetInstance().Count, naam, username, password);
                    break;
                case GebruikerRole.ICTVerantwoordelijke:
                    builder = new ICTVerantwoordelijkeBuilder(GebruikerRepository.GetInstance().Count, naam, username, password);
                    break;
                default:
                    throw new Exception("Ongeldige gebruiker rol.");
            }

            return GebruikerFactory.GetGebruiker(builder);

        }

    }
}
