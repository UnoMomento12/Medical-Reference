using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace Handbook {
	class Connection {
		private static Connection connectionObject;
		private MySqlConnection connection = null;
		private MySqlCommand command;

		private Connection(string connectionString) {
			connection = new MySqlConnection(connectionString);
		}

		public static Connection GetConnection(string connectionString) {
			if (connectionObject == null)
				connectionObject = new Connection(connectionString);
			return connectionObject;
		}

		private void OpenConnection() {
			try {
				connection.Open();
			}
			catch (MySqlException ex) { throw ex; }
			catch (NullReferenceException ex) { throw ex; }
			catch (Exception ex) { throw ex; }
		}

		private void CloseConnection() {
			try {
				connection.Close();
			}
			catch (MySqlException ex) { throw ex; }
			catch (NullReferenceException ex) { throw ex; }
			catch (Exception ex) { throw ex; }
		}

		public DataSet SelecteQuery (string sql) {
			DataSet ds = new DataSet();
			MySqlDataAdapter adapter = null ;

			try {
				OpenConnection();
				command = new MySqlCommand(sql, connection);
				adapter = new MySqlDataAdapter(command);
				adapter.Fill(ds);
			}
			catch (MySqlException ex) { throw ex; }
			catch (NullReferenceException ex ) { throw ex; }
			finally { CloseConnection(); }
			return ds;	
		}

		public int NonQuery(string sql) {
			try {
				OpenConnection();
				command = new MySqlCommand(sql, connection);
				return command.ExecuteNonQuery();
			}
			catch (MySqlException ex) { throw ex; }
			finally { CloseConnection(); }
		}
	}
}
