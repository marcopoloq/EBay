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
			mtgApiInterface = new CreateCardDB(Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\all_cards"), "*.json"));
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
