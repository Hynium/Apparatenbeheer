using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Apparatenbeheer.Definitions.Gebruikers;

namespace Apparatenbeheer.Persistence.Mappers {
    internal class GebruikerMapper {

        private string _connectionString;
        public GebruikerMapper(string connectionString) {
            _connectionString = connectionString;
        }

        public List<Gebruiker> GetGebruikersFromDB() {

            List<Gebruiker> gebruikers = new List<Gebruiker>();

            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand("SELECT * FROM gebruiker;", connection);

            connection.Open();
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read()) {

                GebruikerBuilder builder;
                string gebruikerRole = dataReader["GebruikerRol"].ToString();

                switch (gebruikerRole) {
                    case "Werknemer":
                        builder = new WerknemerBuilder(
                                (int)dataReader["idGebruiker"],
                                dataReader["GebruikerNaam"].ToString(),
                                dataReader["GebruikerUserNaam"].ToString(),
                                dataReader["GebruikerPassword"].ToString()
                            );
                        break;
                    case "ICTVerantwoordelijke":
                        builder = new ICTVerantwoordelijkeBuilder(
                                (int)dataReader["idGebruiker"],
                                dataReader["GebruikerNaam"].ToString(),
                                dataReader["GebruikerUserNaam"].ToString(),
                                dataReader["GebruikerPassword"].ToString()
                            );
                        break;
					default:
						continue;
                }

                gebruikers.Add(GebruikerFactory.GetGebruiker(builder));

            }

            connection.Close();
            return gebruikers;

        }

        public Gebruiker AddGebruikerToDB(Gebruiker gebruiker) {

            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(
                "INSERT INTO gebruiker (idGebruiker, GebruikerNaam, GebruikerUserNaam, GebruikerPassword, GebruikerRol)" 
                + " VALUES (@id, @naam, @username, @password, @role);", connection);

            command.Parameters.AddWithValue("id", gebruiker.Id);
            command.Parameters.AddWithValue("naam", gebruiker.Naam);
            command.Parameters.AddWithValue("username", gebruiker.Username);
            command.Parameters.AddWithValue("password", gebruiker.Password);
            command.Parameters.AddWithValue("role", gebruiker.Role);

			connection.Open();
			command.ExecuteNonQuery();

            if (gebruiker.Id == null)
                gebruiker.Id = Services.LastInsertedId(connection);

            connection.Close();

            return gebruiker;

        }

        public void UpdateGebruiker(Gebruiker gebruiker, Gebruiker updatedGebruiker) {

            if (gebruiker.Id != updatedGebruiker.Id)
                throw new Exception("Cannot update user: Id of updated user does not match.");

            MySqlConnection connection = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand("UPDATE gebruiker SET GebruikerNaam=@naam, GebruikerUserNaam=@username, GebruikerPassword=@password, GebruikerRol=@role WHERE idGebruiker=@id;", connection);

            command.Parameters.AddWithValue("naam", updatedGebruiker.Naam);
            command.Parameters.AddWithValue("username", updatedGebruiker.Username);
            command.Parameters.AddWithValue("password", updatedGebruiker.Password);
            command.Parameters.AddWithValue("role", updatedGebruiker.Role);
            command.Parameters.AddWithValue("id", gebruiker.Id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

    }
}
