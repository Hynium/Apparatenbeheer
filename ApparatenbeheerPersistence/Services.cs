using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace Apparatenbeheer.Persistence {
	internal static class Services {

		public static int LastInsertedId(MySqlConnection connection) {
			MySqlCommand command = new MySqlCommand("SELECT LAST_INSERT_ID()", connection);
			return Convert.ToInt32(command.ExecuteScalar());
		}

	}
}
