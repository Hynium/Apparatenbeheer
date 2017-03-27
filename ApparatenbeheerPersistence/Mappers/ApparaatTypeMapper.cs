using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Apparatenbeheer.Definitions.Apparaten;

namespace Apparatenbeheer.Persistence.Mappers {
	internal class ApparaatTypeMapper {

		private string _connectionString;
		public ApparaatTypeMapper(string connectionString) {
			_connectionString = connectionString;
		}

		public List<ApparaatType> GetApparaatTypesFromDB() {

			List<ApparaatType> types = new List<ApparaatType>();

			MySqlConnection connection = new MySqlConnection(_connectionString);
			MySqlCommand command = new MySqlCommand("SELECT * FROM apparaattype;", connection);

			connection.Open();
			MySqlDataReader dataReader = command.ExecuteReader();

			while (dataReader.Read()) {

				types.Add(new ApparaatType(dataReader["ApparaatTypeNaam"].ToString()));

			}

			connection.Close();
			return types;

		}

		public void AddApparaatTypeToDB(ApparaatType type) {

			MySqlConnection connection = new MySqlConnection(_connectionString);
			MySqlCommand command = new MySqlCommand("INSERT INTO apparaattype(ApparaatTypeNaam), VALUES (@type);", connection);

			command.Parameters.AddWithValue("type", type.Omschrijving);

			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();

		}

		public int GetApparaatTypeIdFromDB(ApparaatType type) {

			MySqlConnection connection = new MySqlConnection(_connectionString);
			MySqlCommand command = new MySqlCommand("SELECT * FROM apparaattype WHERE ApparaatTypeNaam=@type;", connection);

			command.Parameters.AddWithValue("type", type.Omschrijving);

            connection.Open();
			MySqlDataReader dataReader = command.ExecuteReader();

			dataReader.Read();
			int result = (int)dataReader["idApparaatType"];

			connection.Close();
			return result;


		}

	}
}
