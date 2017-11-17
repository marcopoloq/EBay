using System;
using System.Data.SQLite;
using System.IO;

namespace EBay {
	class DBHandler {
		private SQLiteConnection carddbConnection;
		private CreateCardDB mtgApiInterface;

		public DBHandler(CreateCardDB mtgApiInterface) {
			this.mtgApiInterface = mtgApiInterface;

			string path = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\data\carddb.sqlite");
			string password = "password123";
			carddbConnection = new SQLiteConnection(string.Format("Data Source={0}; Version=3; Password={1}; SQLITE_LIMIT_SQL_LENGTH=1000000;", path, password));
			carddbConnection.Open();
		}

		private void Command(string command) {
			SQLiteCommand c = new SQLiteCommand(command, carddbConnection);
			c.ExecuteNonQuery();
		}

		private void InsertCards(CreateCardDB mtgApiInterface) {
			string qstart = "INSERT INTO all_cards (id, layout, name, names, manaCost, cmc, colors, colorIdentity, type, supertypes, types, subtypes, rarity, text, flavor, artist, number, power, toughness, loyalty, multiverseid, variations, imageName, watermark, border, timeshifted, hand, life, reserved, releaseDate, starter, mciNumber, rulings, foreignNames, printings, originalText, originalType, legalities, source) VALUES (";
			string qend = ");";
			string q = "";
			foreach(Card card in mtgApiInterface.cards) {

			}
		}

		private void SelectCard(string card) {
			Command("SELECT * FROM all_cards WHERE name = card;");
		}
	}
}