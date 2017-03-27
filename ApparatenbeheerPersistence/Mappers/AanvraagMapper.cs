using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Apparatenbeheer.Definitions.Apparaten;
using Apparatenbeheer.Definitions.Gebruikers;

namespace Apparatenbeheer.Persistence.Mappers {
	internal class AanvraagMapper {

		private string _connectionString;
		public AanvraagMapper(string connectionString) {
			_connectionString = connectionString;
		}

		public List<Aanvraag> GetAanvragenFromDB(Gebruiker gebruiker, List<Gebruiker> gebruikers, List<Apparaat> apparaten) {

			List<Aanvraag> aanvragen = new List<Aanvraag>();

			MySqlConnection connection = new MySqlConnection(_connectionString);

            MySqlCommand command = null;
            if (gebruiker is Werknemer)
			    command = new MySqlCommand("SELECT * FROM aanvraag LEFT JOIN apparaattype ON aanvraag.ApparaatType_idApparaatType=ApparaatType.idApparaatType WHERE Gebruiker_idAanvrager=@id OR Gebruiker_idOntvanger=@id;", connection);
            if (gebruiker is ICTVerantwoordelijke)
                command = new MySqlCommand("SELECT * FROM aanvraag LEFT JOIN apparaattype ON aanvraag.ApparaatType_idApparaatType=ApparaatType.idApparaatType WHERE Gebruiker_idVerantwoordelijke=@id OR Gebruiker_idVerantwoordelijke IS NULL;", connection);

			command.Parameters.AddWithValue("id", gebruiker.Id);

			connection.Open();
			MySqlDataReader dataReader = command.ExecuteReader();

			while (dataReader.Read()) {

				int aanvragerId = (int)dataReader["Gebruiker_idAanvrager"];
				Gebruiker aanvrager = gebruikers.Find(g => g.Id == aanvragerId);

                int ontvangerId = (int)dataReader["Gebruiker_idOntvanger"];
				Gebruiker ontvanger = gebruikers.Find(g => g.Id == ontvangerId);

				var verantwoordelijkeId = dataReader["Gebruiker_idVerantwoordelijke"];
                ICTVerantwoordelijke verantwoordelijke = null;

                if (verantwoordelijkeId != DBNull.Value)
				    verantwoordelijke = (ICTVerantwoordelijke)gebruikers.Find(g => g.Id == (int)verantwoordelijkeId);

				Aanvraag aanvraag = new Aanvraag(
						(int)dataReader["idAanvraag"],
						aanvrager,
						ontvanger,
						verantwoordelijke,
						new ApparaatType(dataReader["ApparaatTypeNaam"].ToString())
					);

                if (dataReader["AanvraagCommentaar"] != null)
                    aanvraag.SetStatus((AanvraagStatus)dataReader["Status_idStatus"], dataReader["AanvraagCommentaar"].ToString());

				aanvragen.Add(aanvraag);

			}

			connection.Close();
			return aanvragen;

		}

		public Aanvraag AddAanvraagToDB(Aanvraag aanvraag) {

			MySqlConnection connection = new MySqlConnection(_connectionString);
			MySqlCommand command = new MySqlCommand("INSERT INTO aanvraag(idAanvraag, Gebruiker_idAanvrager, Gebruiker_idOntvanger, Gebruiker_idVerantwoordelijke, idApparaatType)" +
				" VALUES (@id, @aanvrager, @ontvanger, @verantwoordelijke, @type);", connection);

			command.Parameters.AddWithValue("id", aanvraag.Id);
			command.Parameters.AddWithValue("aanvrager", aanvraag.Aanvrager.Id);
            command.Parameters.AddWithValue("ontvanger", aanvraag.Ontvanger.Id);

			if (aanvraag.Verantwoordelijke != null)
				command.Parameters.AddWithValue("verantwoordelijke", aanvraag.Verantwoordelijke.Id);

			ApparaatTypeMapper typeMapper = new ApparaatTypeMapper(_connectionString);
			int typeId = typeMapper.GetApparaatTypeIdFromDB(aanvraag.Type);
			command.Parameters.AddWithValue("type", typeId);
			
			connection.Open();
			command.ExecuteNonQuery();

            if (aanvraag.Id == null)
                aanvraag.Id = Services.LastInsertedId(connection);

			connection.Close();

            return aanvraag;

		}

		public void DeleteAanvraagFromDB(Aanvraag aanvraag) {

			MySqlConnection connection = new MySqlConnection(_connectionString);
			MySqlCommand command = new MySqlCommand("DELETE FROM aanvraag WHERE idAanvraag=@id;", connection);

			command.Parameters.AddWithValue("id", aanvraag.Id);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();

		}

        public Aanvraag UpdateAanvraag(Aanvraag aanvraag, Aanvraag updatedAanvraag) {

            if (aanvraag.Id != updatedAanvraag.Id)
                throw new Exception("Cannot update ticket: Id of updated ticket does not match.");

            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand("UPDATE aanvraag SET Status_idStatus=@status, AanvraagCommentaar=@comment, Gebruiker_idVerantwoordelijke=@verantwoordelijke WHERE idAanvraag=@id;", connection);

            command.Parameters.AddWithValue("status", (int)updatedAanvraag.Status);
            command.Parameters.AddWithValue("comment", updatedAanvraag.Commentaar);

            if (updatedAanvraag.Verantwoordelijke != null)
                command.Parameters.AddWithValue("verantwoordelijke", updatedAanvraag.Verantwoordelijke.Id);

            command.Parameters.AddWithValue("id", aanvraag.Id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return updatedAanvraag;

        }

	}
}
