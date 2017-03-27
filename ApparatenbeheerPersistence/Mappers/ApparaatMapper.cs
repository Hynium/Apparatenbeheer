using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Apparatenbeheer.Definitions.Apparaten;
using Apparatenbeheer.Definitions.Gebruikers;

namespace Apparatenbeheer.Persistence.Mappers {
	internal class ApparaatMapper {

		private string _connectionString;
		public ApparaatMapper(string connectionString) {
			_connectionString = connectionString;
		}

		public List<Apparaat> GetApparatenFromDB(List<Gebruiker> gebruikers) {

			List<Apparaat> apparaten = new List<Apparaat>();

			MySqlConnection connection = new MySqlConnection(_connectionString);
			MySqlCommand command = new MySqlCommand("SELECT * FROM apparaat LEFT JOIN Apparaattype ON apparaat.ApparaatType_idApparaatType=apparaattype.idApparaatType;", connection);

			connection.Open();
			MySqlDataReader dataReader = command.ExecuteReader();

			while (dataReader.Read()) {

				var gebruikerId = dataReader["Gebruiker_idGebruiker"];
                Gebruiker gebruiker = null;

                if (gebruikerId != DBNull.Value)
                    gebruiker = gebruikers.Find(g => g.Id == (int)gebruikerId);

                ApparaatType type = new ApparaatType(dataReader["ApparaatTypeNaam"].ToString());

                Apparaat apparaat = new Apparaat((int)dataReader["idApparaat"], dataReader["ApparaatCode"].ToString(), 
					dataReader["ApparaatNaam"].ToString(), type, (decimal)dataReader["ApparaatPrijs"]);

				if (gebruiker != null)
					apparaat.Toewijzen(gebruiker);

				apparaten.Add(apparaat);

			}

			connection.Close();
			return apparaten;

		}

		public Apparaat AddApparaatToDB(Apparaat apparaat) {

			MySqlConnection connection = new MySqlConnection(_connectionString);
			MySqlCommand command = new MySqlCommand("INSERT INTO gebruiker(idApparaaat, ApparaatCode, ApparaatNaam, ApparaatPrijs, ApparaatType_idApparaatType, Gebruiker_idGebruiker)" +
				" VALUES (@id, @code, @naam, @prijs, @type, @gebruiker);", connection);

			command.Parameters.AddWithValue("id", apparaat.Id);
			command.Parameters.AddWithValue("code", apparaat.Code);
			command.Parameters.AddWithValue("naam", apparaat.Omschrijving);
			command.Parameters.AddWithValue("prijs", apparaat.Prijs);

			ApparaatTypeMapper typeMapper = new ApparaatTypeMapper(_connectionString);
			int typeId = typeMapper.GetApparaatTypeIdFromDB(apparaat.Type);
			command.Parameters.AddWithValue("type", typeId);

			if (apparaat.CurrentGebruiker != null)
				command.Parameters.AddWithValue("gebruiker", apparaat.CurrentGebruiker.Id);

			connection.Open();
			command.ExecuteNonQuery();

            if (apparaat.Id == null)
                apparaat.Id = Services.LastInsertedId(connection);

			connection.Close();

            return apparaat;

		}

		public void DeleteApparaatFromDB(Apparaat apparaat) {

			MySqlConnection connection = new MySqlConnection(_connectionString);
			MySqlCommand command = new MySqlCommand("DELETE FROM apparaat WHERE idApparaat=@id;", connection);

			command.Parameters.AddWithValue("id", apparaat.Id);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();

		}

        public Apparaat UpdateApparaat(Apparaat apparaat, Apparaat updatedApparaat) {

            if (updatedApparaat.Id != apparaat.Id)
                throw new Exception("Cannot update device: Id of the updated device does not match.");

            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand("UPDATE apparaat SET ApparaatCode=@code, ApparaatNaam=@naam, ApparaatPrijs=@prijs, ApparaatType_idApparaatType=@type, Gebruiker_idGebruiker=@gebruiker WHERE idApparaat=@id;", connection);

            ApparaatTypeMapper mapper = new ApparaatTypeMapper(_connectionString);
            int typeId = mapper.GetApparaatTypeIdFromDB(updatedApparaat.Type);

            command.Parameters.AddWithValue("code", updatedApparaat.Code);
            command.Parameters.AddWithValue("naam", updatedApparaat.Omschrijving);
            command.Parameters.AddWithValue("prijs", updatedApparaat.Prijs);
            command.Parameters.AddWithValue("type", typeId);
            command.Parameters.AddWithValue("gebruiker", updatedApparaat.CurrentGebruiker.Id);
            command.Parameters.AddWithValue("id", apparaat.Id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return updatedApparaat;

        }


	}
}
