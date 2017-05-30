using System;
using System.Diagnostics;
using System.IO;

namespace EBay {
	class Program {
		//private static DBHandler dbh;
		private static CreateCardDB mtgApiInterface;
		static void Main(string[] args) {
			//dbh = new DBHandler();
			Stopwatch sw = new Stopwatch();
			sw.Start();
			mtgApiInterface = new CreateCardDB(
				Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\AllSets-x.json"), // Json file with all sets
				Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\AllCards-x.json")); // Json file with all cards
			sw.Stop();
			TimeSpan ts = sw.Elapsed;
			// Format and display the TimeSpan value.
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
				ts.Hours, ts.Minutes, ts.Seconds,
				ts.Milliseconds / 10);
			Console.WriteLine("RunTime " + elapsedTime);
			Console.ReadKey();
		}
	}
}
