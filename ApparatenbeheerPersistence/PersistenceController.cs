using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apparatenbeheer.Definitions.Apparaten;
using Apparatenbeheer.Definitions.Gebruikers;
using Apparatenbeheer.Persistence.Mappers;

namespace Apparatenbeheer.Persistence {
    public class PersistenceController {

        private static PersistenceController _instance;
        private string _connectionString;

		private List<Gebruiker> _gebruikers;
		private List<Apparaat> _apparaten;
		private List<Aanvraag> _aanvragen;

        private GebruikerMapper _gebruikerMapper;
        private ApparaatMapper _apparaatMapper;
        private AanvraagMapper _aanvraagMapper;
		private ApparaatTypeMapper _apparaatTypeMapper;

        private PersistenceController() {
            _connectionString = ConfigurationManager.ConnectionStrings["apparatenbeheerDB"].ToString();

            _gebruikerMapper = new GebruikerMapper(_connectionString);
            _apparaatMapper = new ApparaatMapper(_connectionString);
            _aanvraagMapper = new AanvraagMapper(_connectionString);
			_apparaatTypeMapper = new ApparaatTypeMapper(_connectionString);
        }

        public static PersistenceController GetInstance()
            => _instance ?? (_instance = new PersistenceController());

		public List<Gebruiker> GetGebruikers()
			=> (_gebruikers = _gebruikerMapper.GetGebruikersFromDB());

		public List<Apparaat> GetApparaten()
			=> (_apparaten = _apparaatMapper.GetApparatenFromDB(_gebruikers));

		public List<Aanvraag> GetAanvragen(Gebruiker currentGebruiker)
			=> (_aanvragen = _aanvraagMapper.GetAanvragenFromDB(currentGebruiker, _gebruikers, _apparaten));

		public List<ApparaatType> GetApparaatTypes()
			=> _apparaatTypeMapper.GetApparaatTypesFromDB();

		public Gebruiker AddGebruiker(Gebruiker gebruiker) {
			_gebruikers.Add(gebruiker);
			return _gebruikerMapper.AddGebruikerToDB(gebruiker);
		}

		public Apparaat AddApparaat(Apparaat apparaat) {
			_apparaten.Add(apparaat);
			return _apparaatMapper.AddApparaatToDB(apparaat);
		}

		public Aanvraag AddAanvraag(Aanvraag aanvraag) {
			_aanvragen.Add(aanvraag);
			return _aanvraagMapper.AddAanvraagToDB(aanvraag);
		}

		public void DeleteApparaat(Apparaat apparaat) {
			_apparaten.Remove(apparaat);
			_apparaatMapper.DeleteApparaatFromDB(apparaat);
		}

		public void DeleteAanvraag(Aanvraag aanvraag) {
			_aanvragen.Remove(aanvraag);
			_aanvraagMapper.DeleteAanvraagFromDB(aanvraag);
		}

        public Aanvraag UpdateAanvraag(Aanvraag aanvraag, Aanvraag updatedAanvraag)
            => _aanvraagMapper.UpdateAanvraag(aanvraag, updatedAanvraag);

        public Apparaat UpdateApparaat(Apparaat currentApparaat, Apparaat newApparaat)
            => _apparaatMapper.UpdateApparaat(currentApparaat, newApparaat);

    }
}
