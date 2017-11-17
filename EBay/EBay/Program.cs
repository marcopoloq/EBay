using System;
using System.IO;

namespace EBay {
	class Program {
		// Readonly or constant variables.
		private static readonly string all_sets = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\AllSets-x.json");
		private static readonly string all_cards = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\AllCards-x.json");
		// Parts needed to construct the database.
		private static DBHandler dbh;
		private static CreateCardDB mtgApiInterface;

		static void Main(string[] args) {
			mtgApiInterface = new CreateCardDB(all_sets, all_cards);
			dbh = new DBHandler(mtgApiInterface);
			Console.ReadKey();
		}
	}
}
