using System.Data.SQLite;
using System.IO;

namespace EBay {
	class DBHandler {
		SQLiteConnection m_dbConnection;
		public DBHandler() {
			string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\data\carddb.sqlite");
			m_dbConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3;Password={1};", path, "password123"));
			m_dbConnection.Open();
		}
	}
}