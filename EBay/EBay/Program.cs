using System;
using System.IO;

namespace EBay {
	class Program {
		//private static DBHandler dbh;
		private static CreateCardDB mtgApiInterface;
		static void Main(string[] args) {
			//dbh = new DBHandler();
			mtgApiInterface = new CreateCardDB(
				Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\AllSets-x.json"), // Json file with all sets
				Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\AllCards-x.json")); // Json file with all cards
			Console.ReadKey();
		}
	}
}
