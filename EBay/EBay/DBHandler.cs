using System;
using System.Data.Sql;
using System.Data.SqlClient;

namespace EBay {
	class DBHandler {
		public DBHandler() {
			string userid = "";
			string pwd = "";
			string server = "localhost";
			string trusted_connection = "true";
			string database = "main";
			int timeout = 10;

			SqlConnection myConnection = new SqlConnection(
				String.Format("user id = {0}; Pwd = {1}; Server = {2}; Trusted_Connection = {3}; Database = {4}; Connect Timeout = {5}", userid, pwd, server, trusted_connection, database, timeout)
			);

			try {
				myConnection.Open();
			} catch(Exception e) {
				Console.WriteLine(e.ToString());
			}
		}
	}
}