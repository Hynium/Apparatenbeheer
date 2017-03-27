using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apparatenbeheer.Business.Extensions;
using Apparatenbeheer.Business.Repositories;
using Apparatenbeheer.Definitions.Apparaten;
using Apparatenbeheer.Definitions.Gebruikers;

using Apparatenbeheer.Persistence;

namespace Apparatenbeheer.Business {

    public class Controller {

        private Gebruiker _currentGebruiker;

        private GebruikerRepository _gebruikerRepository;
        private ApparaatRepository _apparaatRepository;
        private AanvraagRepository _aanvraagRepository;

        private PersistenceController _persistenceController;

        public Controller() {

            _gebruikerRepository = GebruikerRepository.GetInstance();
            _apparaatRepository = ApparaatRepository.GetInstance();
            _aanvraagRepository = AanvraagRepository.GetInstance();

            _persistenceController = PersistenceController.GetInstance();

            foreach (Gebruiker g in _persistenceController.GetGebruikers())
                _gebruikerRepository.Add(g);

            foreach (Apparaat a in _persistenceController.GetApparaten())
                _apparaatRepository.Add(a);

        }

        public bool Login(string username, string password) {
            Gebruiker login = _gebruikerRepository.Find(g => g.Username == username);
            if ((_currentGebruiker = login.Login(password)) != null) {
                _aanvraagRepository.Clear();
                foreach (Aanvraag a in _persistenceController.GetAanvragen(_currentGebruiker))
                    _aanvraagRepository.Add(a);
                return true;
            }
            return false;
        }

        public void RegisterGebruiker(string naam, string username, string password, GebruikerRole role) {

            GebruikerBuilder builder;

            switch (role) {

                case GebruikerRole.Werknemer:
                    builder = new WerknemerBuilder(null, naam, username, password);
                    break;
                case GebruikerRole.ICTVerantwoordelijke:
                    builder = new ICTVerantwoordelijkeBuilder(null, naam, username, password);
                    break;
                default:
                    throw new Exception("Invalid user role.");

            }

            Gebruiker gebruiker = GebruikerFactory.GetGebruiker(builder);
            gebruiker = _persistenceController.AddGebruiker(gebruiker);
            _gebruikerRepository.Add(gebruiker);

        }

        public void AddApparaat(string code, string omschrijving, string type, decimal prijs) {
            Apparaat apparaat = new Apparaat(null, code, omschrijving,
                new ApparaatType(type), prijs);
            apparaat = _persistenceController.AddApparaat(apparaat);
            _apparaatRepository.Add(apparaat);
        }

        #region GebruikerFunctions

        public decimal GetTotaleWaarde() {
            if (_currentGebruiker == null)
                throw new Exception("Niemand is aangemeld.");

            return _currentGebruiker.GetTotaleWaarde();
        }

        public List<Aanvraag> GetAanvragen() {

            if (_currentGebruiker == null)
                throw new Exception("Niemand is aangemeld");

            return _aanvraagRepository;

        }

        #endregion

        #region WerknemerFunctions

        public void ApparaatAanvragen(string type) {
            if (!(_currentGebruiker is Werknemer))
                throw new Exception("Je kan dit niet uitvoeren.");

            Aanvraag aanvraag = ((Werknemer)_currentGebruiker).ApparaatAanvragen(_currentGebruiker, new ApparaatType(type));
            _persistenceController.AddAanvraag(aanvraag);
        }

        #endregion

        #region ICTVerantwoordelijkeFunctions

        public void AcceptAanvraag(Aanvraag aanvraag, string commentaar) {
            if (!(_currentGebruiker is ICTVerantwoordelijke))
                throw new Exception("Je kan dit niet uitvoeren.");

            Aanvraag currentAanvraag = _aanvraagRepository.Find(a => a.Id == aanvraag.Id);

            Tuple<Aanvraag, Apparaat> acceptedAanvraag = ((ICTVerantwoordelijke)_currentGebruiker).AcceptAanvraag(currentAanvraag, commentaar);
            currentAanvraag = _persistenceController.UpdateAanvraag(currentAanvraag, acceptedAanvraag.Item1);

            Apparaat apparaat = _apparaatRepository.Find(a => a.Id == acceptedAanvraag.Item2.Id);
            apparaat = _persistenceController.UpdateApparaat(apparaat, acceptedAanvraag.Item2);

        }

        public void DeclineAanvraag(Aanvraag aanvraag, string commentaar) {
            if (!(_currentGebruiker is ICTVerantwoordelijke))
                throw new Exception("Je kan dit niet uitvoeren.");

            Aanvraag currentAanvraag = _aanvraagRepository.Find(a => a.Id == aanvraag.Id);

            Aanvraag newAanvraag = ((ICTVerantwoordelijke)_currentGebruiker).DeclineAanvraag(aanvraag, commentaar);
            currentAanvraag = _persistenceController.UpdateAanvraag(currentAanvraag, newAanvraag);

        }

        public void AanvraagToewijzen(Aanvraag aanvraag, string verantwoordelijkeUsername) {
            if (!(_currentGebruiker is ICTVerantwoordelijke))
                throw new Exception("Je kan dit niet uitvoeren.");

            ICTVerantwoordelijke verantwoordelijke = (ICTVerantwoordelijke)_gebruikerRepository.Find(i
                => i.Username == verantwoordelijkeUsername);
            Aanvraag newAanvraag = ((ICTVerantwoordelijke)_currentGebruiker).AanvraagToewijzen(aanvraag, verantwoordelijke);

            Aanvraag currentAanvraag = _aanvraagRepository.Find(a => a.Id == aanvraag.Id);
            currentAanvraag = _persistenceController.UpdateAanvraag(currentAanvraag, newAanvraag);

        }

        public void ApparaatToewijzen(Apparaat apparaat, Gebruiker gebruiker) {
            if (!(_currentGebruiker is ICTVerantwoordelijke))
                throw new Exception("Je kan dit niet uitvoeren.");

            Apparaat currentApparaat = _apparaatRepository.Find(a => a.Id == apparaat.Id);

            Apparaat newApparaat = ((ICTVerantwoordelijke)_currentGebruiker).ApparaatToewijzen(apparaat, gebruiker);
            currentApparaat = _persistenceController.UpdateApparaat(currentApparaat, newApparaat);

        }

        public void ApparaatAfwijzen(Apparaat apparaat) {
            if (!(_currentGebruiker is ICTVerantwoordelijke))
                throw new Exception("Je kan dit niet uitvoeren.");

            Apparaat currentApparaat = _apparaatRepository.Find(a => a.Id == apparaat.Id);

            Apparaat newApparaat = ((ICTVerantwoordelijke)_currentGebruiker).ApparaatAfwijzen(currentApparaat);
            currentApparaat = _persistenceController.UpdateApparaat(currentApparaat, newApparaat);

        }

        #endregion

    }

}
