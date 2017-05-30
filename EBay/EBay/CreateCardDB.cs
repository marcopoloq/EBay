using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EBay {
	public class CreateCardDB {
		public Set[] sets;
		public Card[] cards;

		public CreateCardDB(string sets_path, string cards_path) {
			// Read the JSON file with all sets.
			JObject obj = JsonConvert.DeserializeObject<JObject>(new StreamReader(sets_path).ReadToEnd());
			sets = new Set[obj.Count];
			IEnumerable<JToken> tokens = obj.Values<JToken>();
			int i = 0;
			foreach(JToken token in tokens) {
				sets[i] = new Set(token.First);
				i++;
			}
			// Read the JSON file with all cards.
			obj = JsonConvert.DeserializeObject<JObject>(new StreamReader(cards_path).ReadToEnd());
			cards = new Card[obj.Count];
			tokens = obj.Values<JToken>();
			i = 0;
			foreach(JToken token in tokens) {
				cards[i] = new Card(token.First);
				i++;
			}
		}
	}

	public class Set : JSON_Parser {
		// Standard set fields.
		public string name;
		public string code;
		public string gathererCode;
		public string oldCode;
		public string magicCardsInfoCode;
		public DateTime releaseDate;
		public string border;
		public string type;
		public string block;
		public string onlineOnly;
		public string[] booster;
		public Card[] cards;

		public Set(JToken set) {
			name = parseString(set, "name");
			code = parseString(set, "code");
			gathererCode = parseString(set, "gathererCode");
			oldCode = parseString(set, "oldCode");
			magicCardsInfoCode = parseString(set, "magicCardsInfoCode");
			releaseDate = parseDate(set, "releaseDate");
			border = parseString(set, "border");
			type = parseString(set, "type");
			block = parseString(set, "block");
			onlineOnly = parseString(set, "onlineOnly");
			booster = parseJArray(set, "booster");
			cards = parseJArrayCards(set, "cards");
		}
		//Function to parse Card objects into a Card[]
		private Card[] parseJArrayCards(JToken token, string name) {
			JArray t = token.Value<JArray>(name);
			cards = new Card[t.Count];
			for(int i = 0; i < t.Count; i++) {
				cards[i] = new Card(t[i]);
			}
			return cards;
		}
	}

	public class Card : JSON_Parser {
		// Standard fields
		public string id;
		public string layout;
		public string name;
		public string[] names;
		public string manaCost;
		public string cmc;
		public string[] colors;
		public string[] colorIdentity;
		public string type;
		public string[] supertypes;
		public string[] types;
		public string[] subtypes;
		public string rarity;
		public string text;
		public string flavor;
		public string artist;
		public string number;
		public string power;
		public string toughness;
		public string loyalty;
		public string multiverseid;
		public string[] variations;
		public string imageName;
		public string watermark;
		public string border;
		public string timeshifted;
		public string hand;
		public string life;
		public string reserved;
		public string releaseDate;
		public string starter;
		public string mciNumber;
		// Extra fields
		public Tuple<DateTime, string>[] rulings;
		public string[] foreignNames;
		public string[] printings;
		public string originalText;
		public string originalType;
		public Tuple<string, string>[] legalities;
		public string source;

		public Card(JToken card) {
			// Standard fields
			id = parseString(card, "id");
			layout = parseString(card, "layout");
			name = parseString(card, "name");
			names = parseJArray(card, "names");
			manaCost = parseString(card, "manaCost");
			cmc = parseString(card, "cmc");
			colors = parseJArray(card, "colors");
			colorIdentity = parseJArray(card, "colorIdentity");
			type = parseString(card, "type");
			supertypes = parseJArray(card, "supertypes");
			types = parseJArray(card, "types");
			subtypes = parseJArray(card, "subtypes");
			rarity = parseString(card, "rarity");
			text = parseString(card, "text");
			flavor = parseString(card, "flavor");
			artist = parseString(card, "artist");
			number = parseString(card, "number");
			power = parseString(card, "power");
			toughness = parseString(card, "toughness");
			loyalty = parseString(card, "loyalty");
			multiverseid = parseString(card, "multiverseid");
			variations = parseJArray(card, "variations");
			imageName = parseString(card, "imageName");
			watermark = parseString(card, "watermark");
			border = parseString(card, "border");
			timeshifted = parseString(card, "timeshifted");
			hand = parseString(card, "hand");
			life = parseString(card, "life");
			reserved = parseString(card, "reserved");
			releaseDate = parseString(card, "releaseDate");
			starter = parseString(card, "starter");
			mciNumber = parseString(card, "mciNumber");
			// Extra fields
			rulings = parseJArrayRulings(card, "rulings");
			foreignNames = parseJArray(card, "foreignNames");
			printings = parseJArray(card, "printings");
			originalText = parseString(card, "originalText");
			originalType = parseString(card, "originalType");
			legalities = parseJArrayLegalities(card, "legalities");
			source = parseString(card, "source");
		}
		// Function to parse JArray of rulings to Tuple[]
		private Tuple<DateTime, string>[] parseJArrayRulings(JToken token, string name) {
			if(token.Value<JArray>(name) != null) {
				JArray t = token.Value<JArray>(name);
				JTokenType s = t[0].Type;
				Tuple<DateTime, string>[] res = new Tuple<DateTime, string>[t.Count];
				for(int i = 0; i < t.Count; i++) {
					res[i] = Tuple.Create(parseDate(t[i], "date"), parseString(t[i], "text"));
				}
				return res;
			} else
				return null;
		}
		// Function to parse JArray of legalities to Tuple[]
		private Tuple<string, string>[] parseJArrayLegalities(JToken token, string name) {
			if(token.Value<JArray>(name) != null) {
				JArray t = token.Value<JArray>(name);
				JTokenType s = t[0].Type;
				Tuple<string, string>[] res = new Tuple<string, string>[t.Count];
				for(int i = 0; i < t.Count; i++) {
					res[i] = Tuple.Create(parseString(t[i], "format"), parseString(t[i], "legality"));
				}
				return res;
			} else
				return null;
		}
	}
}
// Class with all of the needed JSON parsers
public abstract class JSON_Parser {
	// Function to parse string JTokens to string
	protected string parseString(JToken token, string name) {
		if(token.Value<string>(name) != null)
			return token.Value<string>(name).Trim();
		else
			return null;
	}
	// Function to parse string JTokens to DateTime
	protected DateTime parseDate(JToken token, string name) {
		if(token.Value<string>(name) != null) {
			string[] res = parseString(token, name).Split('-');
			return new DateTime(int.Parse(res[0]), int.Parse(res[1]), int.Parse(res[2]));
		} else
			return new DateTime();
	}
	// Function to parse JArray JTokens to string[]
	protected string[] parseJArray(JToken token, string name) {
		if(token.Value<JArray>(name) != null) {
			JArray t = token.Value<JArray>(name);
			string[] res = new string[t.Count];
			for(int i = 0; i < t.Count; i++) {
				res[i] = t[i].ToString().Trim();
			}
			return res;
		} else
			return null;
	}
}