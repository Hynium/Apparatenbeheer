using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apparatenbeheer.Definitions.Gebruikers;

namespace Apparatenbeheer.Definitions.Apparaten {

    public enum AanvraagStatus {
        Assigned,
        WorkInProgress,
        Closed
    }

    public class Aanvraag {

        /* Aanvraag id */
        public int? Id { get; set; }

        /* De persoon die de aanvraag maakt, kan ook voor iemand anders zijn. */
        public Gebruiker Aanvrager { get; private set; }

        /* De persoon die het aangevraagd apparaat zal ontvangen. */
        public Gebruiker Ontvanger { get; private set; }

        /* De toegewezen ICTVerantwoordelijke, als deze null is kan elke ictverantwoordelijke dit uitvoeren */
        public ICTVerantwoordelijke Verantwoordelijke { get; private set; }

        /* Aangevraagd apparaattype */
        public ApparaatType Type { get; private set; }

        /* Status van de aanvraag */
        public AanvraagStatus Status { get; private set; }

        /* Omschrijving status */
        public string Commentaar { get; private set; }

        public Aanvraag(int? id, Gebruiker aanvrager, Gebruiker ontvanger, ICTVerantwoordelijke verantwoordelijke, ApparaatType type) {
            Id = id;
            Aanvrager = aanvrager;
            Ontvanger = ontvanger;
            Verantwoordelijke = verantwoordelijke;

            Type = type;

            Status = AanvraagStatus.Assigned;
        }

        public void SetStatus(AanvraagStatus status, string commentaar) {
            Status = status;
            Commentaar = commentaar;
        }

        public void Toewijzen(ICTVerantwoordelijke verantwoordelijke) {
            Verantwoordelijke = verantwoordelijke;
        }

    }
}
